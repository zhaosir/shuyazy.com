using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;


/// <summary>
/// XML 文档操作工具
/// </summary>
namespace Kpages.IO
{

    public enum ParameterDirection
    {
        Insert,
        Update,
        Equal,
        NotEqual,
        Little,
        Great,
        Like
    }

    public sealed class XmlParamter
    {
        public XmlParamter() { }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string value;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private ParameterDirection direction;
        public ParameterDirection Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }
    }

    public class IOHelperXml
    {
        static string _filePath;
        static private XmlDocument _doc;
        public IOHelperXml()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadFile(string filePath)
        {
            _doc = new XmlDocument();
            try
            {   ///导入XML文档
                _doc.Load(filePath);
                _filePath = filePath;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Save()
        {
            _doc.Save(_filePath);
        }

        /// <summary>
        /// 用路轻初使用化一个使用助手
        /// </summary>
        /// <param name="filePath"></param>
        public IOHelperXml(string filePath)
        {
            _doc = new XmlDocument();
            try
            {   ///导入XML文档
                _doc.Load(filePath);
                _filePath = filePath;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 从文档中搜索并返回一个节点
        /// </summary>
        /// <param name="xpath">xpath</param>
        /// <returns></returns>
        public XmlNode SelectNode(string xpath)
        {
            return _doc.SelectSingleNode(xpath);
        }

        /// <summary>
        /// 从节点中搜索并返回一个节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="xpath">xpath</param>
        /// <returns></returns>
        public XmlNode SeleteNode(XmlNode node, string xpath)
        {
            return node.SelectSingleNode(xpath);
        }

        /// <summary>
        /// 从文档中搜索并反回节点列表
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XmlNodeList SelectNodeList(string xpath)
        {
            return _doc.SelectNodes(xpath);

        }

        /// <summary>
        /// 从节点中搜索并反回节点列表
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public XmlNodeList SelectNodeList(XmlNode node, string xpath)
        {
            return node.SelectNodes(xpath);
        }

        public DataTable GetTableFromNode(XmlNode rootNode, string nodeName)
        {
            DataTable dt = new DataTable();
            ///获取根节点
            if (rootNode == null) return null;
            if (rootNode.ChildNodes.Count <= 0) return null;
            ///创建保存记录的数据列
            foreach (XmlAttribute attr in rootNode.ChildNodes[0].Attributes)
            {

                dt.Columns.Add(new DataColumn(attr.Name, typeof(string)));

            }

            ///创新获取数据节点的XPath
            string xmlPath = nodeName;
            XmlNodeList nodeList = rootNode.SelectNodes(xmlPath);
            ///添加节点的数据
            foreach (XmlNode node in nodeList)
            {
                DataRow row = dt.NewRow();
                foreach (DataColumn column in dt.Columns)
                {   ///读取每一个属性
                    row[column.ColumnName] = node.Attributes[column.ColumnName].Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="newNode"></param>
        public void AddNode(XmlNode rootNode,XmlNode newNode)
        {
            
            try
            {
                rootNode.AppendChild(newNode);
                ///保存XML文档
                _doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// 创造一个节点
        /// </summary>
        /// <param name="NodeName"></param>
        /// <returns></returns>
        public XmlNode CreateNode(string NodeName)
        {
           return _doc.CreateElement(NodeName);
        }


        /// <summary>
        /// 为一节点添加属性
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddAttribute(XmlNode node, string name, string value)
        {
            XmlAttribute attribute = _doc.CreateAttribute(name, null);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        #region 添加数据

        public static void AddData(XmlNode node, string tableName, params XmlParamter[] param)
        {

            XmlNode newNode = _doc.CreateNode(XmlNodeType.Element, tableName, null);
            ///添加新节点的属性
            foreach (XmlParamter p in param)
            {
                newNode.Attributes.Append(CreateNodeAttribute(_doc, p.Name, p.Value));
            }
            ///将新节点追加到根节点中
            node.AppendChild(newNode);

            try
            {   ///保存XML文档
                _doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        #endregion

        #region 更新数据

        public static int UpdateData(XmlNode node, string tableName, params XmlParamter[] param)
        {


            ///创新选择被修改节点的XPath
            string xmlPath = "/" + tableName;
            int operationCount = 0;
            StringBuilder operation = new StringBuilder();
            foreach (XmlParamter p in param)
            {
                if (p.Direction == ParameterDirection.Insert
                    || p.Direction == ParameterDirection.Update)
                {
                    continue;
                }
                switch (p.Direction)
                {
                    case ParameterDirection.Equal:
                        operation.Append("@" + p.Name + "='" + p.Value + "'");
                        break;
                    case ParameterDirection.NotEqual:
                        operation.Append("@" + p.Name + "<>'" + p.Value + "'");
                        break;
                    case ParameterDirection.Little:
                        operation.Append("@" + p.Name + "<'" + p.Value + "'");
                        break;
                    case ParameterDirection.Great:
                        operation.Append("@" + p.Name + ">'" + p.Value + "'");
                        break;
                    case ParameterDirection.Like:
                        operation.Append("contains(@" + p.Name + ",'" + p.Value + "')");
                        break;
                    default: break;
                }
                operationCount++;
                operation.Append(" and ");
            }
            if (operationCount > 0)
            {
                operation.Remove(operation.Length - 5, 5);
                xmlPath += "[" + operation.ToString() + "]";
            }

            XmlNodeList nodeList = node.SelectNodes(xmlPath);
            if (nodeList == null) return -1;
            ///修改节点的属性
            foreach (XmlNode n in nodeList)
            {	///修改单个节点的属性
                foreach (XmlParamter p in param)
                {
                    if (p.Direction == ParameterDirection.Update)
                    {
                        n.Attributes[p.Name].Value = p.Value;
                    }
                }
            }

            try
            {   ///保存XML文档
                _doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return nodeList.Count;
        }

        #endregion



        #region 创建参数

        private static XmlAttribute CreateNodeAttribute(XmlDocument doc, String name, String value)
        {
            XmlAttribute attribute = doc.CreateAttribute(name, null);
            attribute.Value = value;
            return attribute;
        }

        private static XmlParamter CreateParameter(string name, string value, ParameterDirection direciton)
        {
            XmlParamter p = new XmlParamter();
            p.Name = name;
            p.Value = value;
            p.Direction = direciton;

            return p;
        }

        public static XmlParamter CreateInsertParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Insert);
        }
        public static XmlParamter CreateUpdateParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Update);
        }
        public static XmlParamter CreateEqualParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Equal);
        }
        public static XmlParamter CreateGreatParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Great);
        }
        public static XmlParamter CreateLittleParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Little);
        }
        public static XmlParamter CreateNotEqualParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.NotEqual);
        }
        public static XmlParamter CreateLikeParameter(string name, string value)
        {
            return CreateParameter(name, value, ParameterDirection.Like);
        }

        #endregion

    }
}
