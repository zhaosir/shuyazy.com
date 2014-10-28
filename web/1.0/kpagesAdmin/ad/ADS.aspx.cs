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

public partial class kpagesAdmin_ad_ADS :ADHelperBase
{
    static ADItem item;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        if (!IsPostBack)
        {
            Bind(gv);

            showBn();
        }
    }

    protected void Delete(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                string str = row.Cells[0].Text;
                Delete(Convert.ToInt32(row.Cells[0].Text.ToString()));
            }
        }

        Bind(gv);
    }

    protected void New(object sender, EventArgs e)
    {
        item = null;
        showBn();
    }

    protected void Add(object sender, EventArgs e)
    {
        Add(tbTitle.Value.Trim(), tbSite.Value.Trim());
        Bind(gv);

        item = null;
        showBn();
    }

    protected void Update(object sender, EventArgs e)
    {
        Update(item.id, tbTitle.Value.Trim(), tbSite.Value.Trim());
        Bind(gv);
    }

    public void Bind(GridView gv)
    {
        gv.DataSource = GetList();
        gv.DataBind();
    }

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        item = GetItem(e.CommandArgument.ToString());

        tbTitle.Value = item.item_url;
        tbSite.Value = item.link;
        showBn();

    }

    public void showBn()
    {
        if (item == null)
        {
            bnAdd.Visible = true;
            bnUpdate.Visible = false;

            tbSite.Value = "";
            tbTitle.Value = "";
            successInfo.InnerHtml = "";
            titleInfo.InnerHtml = "";
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
                string webFilePath = Server.MapPath("../../ad/images/" + DateTime.Now.Minute + fileName);        // 服务器端文件路径


                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        fu.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件

                        titleInfo.InnerHtml = "提示：文件“" + fileName + "”成功上传!“";

                        tbTitle.Value = "images/" + DateTime.Now.Minute + fileName;

                    }
                    catch (Exception ex)
                    {
                        titleInfo.InnerHtml = "提示：文件上传失败，失败原因：" + ex.Message;
                    }
                }
                else
                {
                    titleInfo.InnerHtml = "提示：文件已经存在，请重命名后上传";
                }
            }
            else
            {
                titleInfo.InnerHtml = "提示：文件类型不符";
            }
        }
    }
}
