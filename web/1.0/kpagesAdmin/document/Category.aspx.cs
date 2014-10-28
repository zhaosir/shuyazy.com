using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class kpagesAdmin_document_Category :CategoryMaster
{
    public string selectValue; //当前选择文本
    public string selecText; //当前选择值
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            /*
            DataSet ds = GetList(0);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //如果此节点为最后一级，则为其加上链接
                if (GetList(Convert.ToInt32(dr["ID"].ToString())).Tables[0].Rows.Count > 0)
                {
                    string str = "<div class='treeItem'><span>" + dr["category"].ToString() + "</span><a href='CateInfo.aspx?upID="
                    + dr["ID"].ToString() + "&act=add'>增加</a><a href='CateInfo.aspx?upID="
                    + dr["upID"].ToString() + "&ID=" + dr["ID"].ToString() + "&act=update'>修改</a></div>";
                    TreeNode node = new TreeNode(str, dr["ID"].ToString());

                    inputChilds(node, GetList(Convert.ToInt32(dr["ID"].ToString())).Tables[0]);

                    tvCate.Nodes.Add(node);
                }
                else
                {
                    string str = "<div class='treeItem'><span>" + dr["category"].ToString() + "</span><a href='CateInfo.aspx?upID="
                    + dr["ID"].ToString() + "&act=add'>增加</a><a href='CateInfo.aspx?upID="
                    + dr["upID"].ToString() + "&ID=" + dr["ID"].ToString() + "&act=update'>修改</a><a href='CateInfo.aspx?ID="
                    + dr["ID"].ToString() + "&act=delete'>删除</a><a href='DocumentInfo.aspx?upID=" + dr["ID"].ToString() + "'>添加文档</a></div>";
                    TreeNode node = new TreeNode(str, dr["ID"].ToString());
                    tvCate.Nodes.Add(node);
                }
            }


            tvCate.ExpandAll();
             */ 
        }
    }

    /// <summary>
    /// 给指定的节点添加子节点
    /// </summary>
    /// <param name="tn"></param>
    /// <param name="dt"></param>
    public void inputChilds(TreeNode tn, DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {

            //如果此节点为最后一级，则为其加上链接
            if (GetList(Convert.ToInt32(dr["ID"].ToString())).Tables[0].Rows.Count > 0)
            {
                string str = "<div class='treeItem'><span>" + dr["category"].ToString() + "</span><a href='CateInfo.aspx?upID="
                + dr["ID"].ToString() + "&act=add'>增加</a><a href='CateInfo.aspx?upID="
                + dr["upID"].ToString() + "&ID=" + dr["ID"].ToString() + "&act=update'>修改</a></div>";
                TreeNode node = new TreeNode(str, dr["ID"].ToString());
                tn.ChildNodes.Add(node);
            }
            else
            {
                string str = "<div class='treeItem'><span>" + dr["category"].ToString() + "</span><a href='CateInfo.aspx?upID="
                + dr["ID"].ToString() + "&act=add'>增加</a><a href='CateInfo.aspx?upID="
                + dr["upID"].ToString() + "&ID=" + dr["ID"].ToString() + "&act=update'>修改</a><a href='CateInfo.aspx?ID="
                + dr["ID"].ToString() + "&act=delete'>删除</a><a href='DocumentInfo.aspx?upID=" + dr["ID"].ToString() + "'>添加文档</a></div>";
                TreeNode node = new TreeNode(str, dr["ID"].ToString());

                DataSet nextds = GetList(Convert.ToInt32(dr["ID"].ToString()));
                if (nextds.Tables[0].Rows.Count > 0)
                {
                    inputChilds(tn, nextds.Tables[0]);
                }

                tn.ChildNodes.Add(node);
            }

            tn.ExpandAll();

        }
    }

    /// <summary>
    /// 打开下一级
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView tv = (TreeView)sender;
        TreeNode tn = tv.SelectedNode;
        selecText = tn.Text;
        selectValue = tn.Value;

        //tvCate.CollapseAll();

        //如果此节点下为空，则添加子节点
        if (tn.ChildNodes.Count == 0)
        {
            int upID = Convert.ToInt32(tn.Value);

            DataSet ds = GetList(upID);
            inputChilds(tn, ds.Tables[0]);
        }
        tn.ExpandAll();

    }

}
