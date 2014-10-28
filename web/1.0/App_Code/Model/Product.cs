using System;
using System.Data;

/// <summary>
///Product 的摘要说明
/// </summary>
namespace Kpages.Model 
{
    public class Product
    {
        private Document _doc;
        private Kpages.Model.File _docFile;
        public Product()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public Document doc
        {
            set { _doc = value; }
            get { return _doc; }
        }

        public Kpages.Model.File docFile
        {
            set { _docFile = value; }
            get { return _docFile; }
        }


    }

}