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
using System.IO;

public partial class kpagesAdmin_document_ProImg :FileMaster
{
    static Kpages.Model.File item;
    static int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (Request.QueryString["ID"] != null)
        {
            ID= Convert.ToInt32(Request.QueryString["ID"].ToString());
            if (!IsPostBack)
            {
                Bind();

                showBn();
            }
        }
    }

    protected void New(object sender, EventArgs e)
    {
        item = null;
        showBn();
    }

    protected void Add(object sender, EventArgs e)
    {
        item = new Kpages.Model.File();
        item.title = tbTitle.Value.Trim();
        item.url = tbUrl.Value.Trim();
        item.DocID = ID;
        item.type = Convert.ToInt32(ddlType.SelectedValue);

        add(item);
        successInfo.InnerHtml = msg;
        Bind();

        item = null;
        showBn();
    }

    protected void Update(object sender, EventArgs e)
    {
        item.title = tbTitle.Value.Trim();
        item.url = tbUrl.Value.Trim();
        item.type = Convert.ToInt32(ddlType.SelectedValue);

        Update(item);
        successInfo.InnerHtml = msg;
        item = null;
        showBn();
        Bind();
    }

    public void Bind()
    {
        dl.DataSource = GetList("DocID=" + ID);
        dl.DataBind();
    }



    public void showBn()
    {
        if (item == null)
        {
            bnAdd.Visible = true;
            bnUpdate.Visible = false;

            tbUrl.Value = "";
            tbTitle.Value = "";
            successInfo.InnerHtml = "";
            tbTitleInfo.InnerHtml = "";
        }
        else
        {
            bnAdd.Visible = false;
            bnUpdate.Visible = true;
        }
    }
    protected void upimage(object sender, EventArgs e)
    {
        upFile(FileUpload1);
    }

    public void upFile(FileUpload fu)
    {
        if (fu.HasFile)
        {
            string fileContentType = fu.PostedFile.ContentType;
            string type = fu.FileName.Split(char.Parse("."))[1];

            if (type == "bmp" || type == "gif" || type == "jpeg" || type == "jpg")
            {
                string name = fu.PostedFile.FileName;                  // 客户端文件路径

                FileInfo file = new FileInfo(name);
                string fileName = file.Name;                                    // 文件名称

                if (!Directory.Exists(Server.MapPath("../../uploads/proImg/")))
                {
                    Directory.CreateDirectory(Server.MapPath("../../uploads/proImg/"));
                }
                string webFilePath = Server.MapPath("../../uploads/proImg/" + DateTime.Now.Minute + fileName);        // 服务器端文件路径


                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        fu.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件


                        tbUrlInfo.InnerHtml = "提示：文件“" + fileName + "”成功上传!“";

                        tbUrl.Value = "uploads/proImg/" + DateTime.Now.Minute + fileName;

                    }
                    catch (Exception ex)
                    {
                        tbUrlInfo.InnerHtml = "提示：文件上传失败，失败原因：" + ex.Message;
                    }
                }
                else
                {
                    tbUrlInfo.InnerHtml = "提示：文件已经存在，请重命名后上传";
                }
            }
            else
            {
                tbUrlInfo.InnerHtml = "提示：文件类型不符";
            }
        }
    }

    protected void bnDelete_Command(object sender, CommandEventArgs e)
    {
        Delete(Convert.ToInt32(e.CommandArgument));
        Bind();
    }
    protected void bnUpdate_Command(object sender, CommandEventArgs e)
    {
        item = GetModel(Convert.ToInt32(e.CommandArgument));

        tbUrl.Value = item.url;
        tbTitle.Value = item.title;

        showBn();


    }
}
