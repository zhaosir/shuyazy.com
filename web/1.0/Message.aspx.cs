using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class corp_Message :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        keywords.Content = Keyword;
        desrc.Content = Descr;
    }
    
    /// <summary>
    /// 留言提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        bool isOk = true;
        Message msg = new Message();
        string title = txt_title.Value.ToString().Trim();
        string name = txt_title.Value.ToString().Trim();
        string address = txt_address.Value.ToString().Trim();
        string phone = txt_phone.Value.ToString().Trim();
        string emali = txt_email.Value.ToString().Trim();
        string content = FCKeditor1.Value.ToString().Trim();
        #region 服务器验证
        if (title == "")
        {
            isOk = false;
            this.check_title.IsValid = false;
            txt_title.Focus();
        }
        if (name == "")
        {
            isOk = false;
            this.check_name.IsValid = false;
            txt_name.Focus();
        }
        if (phone == "")
        {
            isOk = false;
            this.check_phonenull.IsValid = false;
            txt_phone.Focus();
        }
        else
        {
            
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (!reg.IsMatch(phone))
            {
                isOk = false;
                this.check_phonefor.IsValid = false;
                txt_phone.Focus();
            }
        }
        if (emali == "")
        {
            isOk = false;
            this.check_emalinull.IsValid = false;
            txt_email.Focus();
        }
        else
        {
            Regex reg = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(emali))
            {
                isOk = false;
                this.check_emalifor.IsValid = false;
                txt_phone.Focus();
            }
        }
        if (content == "")
        {
            isOk = false;
            this.RequiredFieldValidator1.IsValid = false;
            FCKeditor1.Focus();
        }
        #endregion
        if (isOk)
        {
            msg.Title = title;
            msg.Name = name;
            msg.Address = address;
            msg.Phone = phone;
            msg.Email = emali;
            msg.IpAddress = this.Request.UserHostAddress;
            msg.Content = content;
            Bll_Message bll_message = new Bll_Message();
            int type = -2;
            bool result = bll_message.AddNewMessage(msg,out type);
            if (result == true && type == 0)//成功
            {
                lab_result.Text = "留言成功！";
            }
            else
            {
                if (type == 1)
                {
                    //同一IP留言间隔小
                    lab_result.Text = "您不能频繁留言，请一分钟后重试！";
                }
                else
                    lab_result.Text = "可能由于网络原因，留言失败！";
                if (type == -1)
                {
                    //Msg为空
                }
                else
                { 
                    //失败
                }

            }
        }
    }
}
