using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class kpagesAdmin_document_ProAddAndEdit : System.Web.UI.Page
{
    string proid = "";
    string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
            this.Response.Redirect(@"~\kpagesAdmin\Login.aspx");
        type = this.Request.Params["type"];
        if (type == null || type == "")
            this.Response.Redirect(@"ProManage.aspx");
        proid = this.Request.Params["pid"];
        if (type == "edit_shuya")
        {
            Button1.Text = "产品修改";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (type == "edit_shuya")
        { }
        else if (type == "add_shuya")
        {
            string title = TextBox1.Text.Trim();
            string Content =FCKeditor1.Value;
            if (title == "" || Content == "")
            {
                Label1.Text = "请填写产品信息！";
                return;
            }
            if (FileUpload1.HasFile)
            {
                string fileContentType = FileUpload1.PostedFile.ContentType;
                if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/jpeg")
                {
                    string name = FileUpload1.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);
                    string fileName = file.Name;                                    // 文件名称
                    string fileName_s = "s_" + file.Name;                           // 缩略图文件名称
                    string fileName_sy = "sy_" + file.Name;                         // 水印图文件名称（文字）
                    string fileName_syp = "syp_" + file.Name;                       // 水印图文件名称（图片）
                    string webFilePath = Server.MapPath("../../ProImg/" + fileName);        // 服务器端文件路径
                    string webFilePath_s = Server.MapPath("../../ProImg/" + fileName_s);　　// 服务器端缩略图路径
                    string webFilePath_sy = Server.MapPath("../../ProImg/" + fileName_sy);　// 服务器端带水印图路径(文字)
                    string webFilePath_syp = Server.MapPath("../../ProImg/" + fileName_syp);　// 服务器端带水印图路径(图片)
                    string webFilePath_sypf = Server.MapPath("../../ProImg/shuiyin.jpg");　// 服务器端水印图路径(图片)

                    if (!File.Exists(webFilePath))
                    {
                        try
                        {
                            try
                            {
                                FileUpload1.SaveAs(webFilePath);
                            }
                            catch(Exception e1)
                            {}
                            try
                            {
                                AddShuiYinWord(webFilePath, webFilePath_sy);
                            }
                            catch (Exception e1)
                            { }
                            try
                            {
                                //AddShuiYinPic(webFilePath, webFilePath_syp, webFilePath_sypf);
                            }
                            catch (Exception e1)
                            { }
                            try
                            {
                                MakeThumbnail(webFilePath, webFilePath_s, 140, 100, "Cut");     // 生成缩略图方法
                            }
                            catch (Exception e1)
                            { }
                            Label1.Text = "提示：文件“" + fileName + "”成功上传，并生成“" + fileName_s + "”缩略图，文件类型为：" + FileUpload1.PostedFile.ContentType + "，文件大小为：" + FileUpload1.PostedFile.ContentLength + "B";

                            #region 增加产品
                            string img = fileName;
                            Kpages.Model.Product pro = new Kpages.Model.Product();
                            Kpages.Model.Document doc = new Kpages.Model.Document();
                            Kpages.Model.File docFile = new Kpages.Model.File();
                            doc.title = title;
                            doc.contents = Content;
                            docFile.url = fileName;
                            doc.cateID = 4;
                            pro.doc = doc;
                            pro.docFile = docFile;
                            Bll_Model bll_model = new Bll_Model();
                            bll_model.AddProInfo(pro);
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = "提示：文件上传失败，失败原因：" + ex.Message;
                        }
                    }
                    else
                    {
                        Label1.Text = "提示：文件已经存在，请重命名后上传";
                    }
                }
                else
                {
                    Label1.Text = "提示：文件类型不符";
                }
            }
        }
    }



    /**//// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /**//// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
    protected void AddShuiYinWord(string Path, string Path_sy)
    {
        string addText = "舒雅" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("楷体_GB2312", 10, System.Drawing.FontStyle.Regular);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

        g.DrawString(addText, f, b, image.Width - 150, image.Height - 20);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }

    /**//// <summary>
    /// 在图片上生成图片水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_syp">生成的带图片水印的图片路径</param>
    /// <param name="Path_sypf">水印图片路径</param>
    protected void AddShuiYinPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width,copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();

        image.Save(Path_syp);
        image.Dispose();
    }
}
