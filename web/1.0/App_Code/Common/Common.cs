
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Globalization;
using System.Web.SessionState;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Kpages.Common
{
    /// <summary>
    /// ͨ����
    /// </summary>
    public class Common
    {



        #region "js��Ϣ��ʾ��"
        /// <summary>
        /// js��Ϣ��ʾ��
        /// </summary>
        /// <param name="Message">��ʾ��Ϣ����</param>
        /// <param name="ReturnUrl">���ص�ַ</param>
        /// <param name="rq"></param>
        public static void MessBox(string Message, string ReturnUrl, HttpContext rq)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("parent.location.href='" + ReturnUrl + "';\n");
            msgScript.Append("</script>\n");
            rq.Response.Write(msgScript.ToString());
            rq.Response.End();
        }

        /// <summary>
        /// ����Alert��Ϣ��
        /// </summary>
        /// <param name="Message">��Ϣ����</param>
        public static void MessBox(string Message)
        {
            System.Text.StringBuilder msgScript = new System.Text.StringBuilder();
            msgScript.Append("<script language=JavaScript>\n");
            msgScript.Append("alert(\"" + Message + "\");\n");
            msgScript.Append("</script>\n");
            HttpContext.Current.Response.Write(msgScript.ToString());
        }

        #endregion

        #region ��ʽ���ַ���,����SQL���
        /// <summary>
        /// ��ʽ���ַ���,����SQL���
        /// </summary>
        /// <param name="formatStr">��Ҫ��ʽ�����ַ���</param>
        /// <returns>�ַ���</returns>
        public static string inSQL(string formatStr)
        {
            string rStr = formatStr;
            if (formatStr != null && formatStr != string.Empty)
            {
                rStr = rStr.Replace("'", "''");
                rStr = rStr.Replace("\"", "\"\"");
            }
            return rStr;
        }
        /// <summary>
        /// ��ʽ���ַ���,��inSQL�ķ���
        /// </summary>
        /// <param name="formatStr"></param>
        /// <returns></returns>
        public static string outSQL(string formatStr)
        {
            string rStr = formatStr;
            if (rStr != null)
            {
                rStr = rStr.Replace("''", "'");
                rStr = rStr.Replace("\"\"", "\"");
            }
            return rStr;
        }

        /// <summary>
        /// ��ѯSQL���,ɾ��һЩSQLע������
        /// </summary>
        /// <param name="formatStr">��Ҫ��ʽ�����ַ���</param>
        /// <returns></returns>
        public static string querySQL(string formatStr)
        {
            string rStr = formatStr;
            if (rStr != null && rStr != "")
            {
                rStr = rStr.Replace("'", "");
            }
            return rStr;
        }
        #endregion

        #region ��ȡ�ַ���
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="str_value"></param>
        /// <param name="str_len"></param>
        /// <returns></returns>
        public static string leftx(string str_value, int str_len)
        {
            int p_num = 0;
            int i;
            string New_Str_value = "";

            if (str_value == "")
            {
                New_Str_value = "";
            }
            else
            {
                int Len_Num = str_value.Length;
                for (i = 0; i <= Len_Num - 1; i++)
                {
                    if (i > Len_Num) break;
                    char c = Convert.ToChar(str_value.Substring(i, 1));
                    if (((int)c > 255) || ((int)c < 0))
                        p_num = p_num + 2;
                    else
                        p_num = p_num + 1;



                    if (p_num >= str_len)
                    {

                        New_Str_value = str_value.Substring(0, i + 1);
                        break;
                    }
                    else
                    {
                        New_Str_value = str_value;
                    }

                }

            }
            return New_Str_value;
        }
        #endregion

        #region ����û��ύҳ��
        /// <summary>
        /// ����û��ύҳ��
        /// </summary>
        /// <param name="rq"></param>
        public static void Check_Post_Url(HttpContext rq)
        {
            string WebHost = "";
            if (rq.Request.ServerVariables["SERVER_NAME"] != null)
            {
                WebHost = rq.Request.ServerVariables["SERVER_NAME"].ToString();
            }

            string From_Url = "";
            if (rq.Request.UrlReferrer != null)
            {
                From_Url = rq.Request.UrlReferrer.ToString();
            }

            if (From_Url == "" || WebHost == "")
            {
                rq.Response.Write("��ֹ�ⲿ�ύ����!");
                rq.Response.End();
            }
            else
            {
                WebHost = "HTTP://" + WebHost.ToUpper();
                From_Url = From_Url.ToUpper();
                int a = From_Url.IndexOf(WebHost);
                if (From_Url.IndexOf(WebHost) < 0)
                {
                    rq.Response.Write("��ֹ�ⲿ�ύ����!");
                    rq.Response.End();
                }
            }

        }
        #endregion

        #region ���ڴ���
        /// <summary>
        /// ��ʽ������Ϊ2006-12-22
        /// </summary>
        /// <param name="dTime"></param>
        /// <returns></returns>
        public static string formatDate(DateTime dTime)
        {
            string rStr;
            rStr = dTime.Year + "-" + dTime.Month + "-" + dTime.Day;
            return rStr;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public static string getWeek(DateTime sDate)
        {
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;


            string rStr = "";
            switch (myCal.GetDayOfWeek(sDate).ToString())
            {
                case "Sunday":
                    rStr = "������";
                    break;
                case "Monday":
                    rStr = "����һ";
                    break;
                case "Tuesday":
                    rStr = "���ڶ�";
                    break;
                case "Wednesday":
                    rStr = "������";
                    break;
                case "Thursday":
                    rStr = "������";
                    break;
                case "Friday":
                    rStr = "������";
                    break;
                case "Saturday":
                    rStr = "������";
                    break;
            }
            return rStr;
        }
        #endregion

        #region �����ɫ����

        /// <summary>
        /// �����ɫ����
        /// </summary>
        /// <returns></returns>
        public static string getStrColor()
        {
            int length = 6;
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "����IP��ַ���һλ��*�Ŵ���"
        /// <summary>
        /// ����IP��ַ���һλ��*�Ŵ���
        /// </summary>
        /// <param name="Ipaddress">IP��ַ:192.168.34.23</param>
        /// <returns></returns>
        public static string HidenLastIp(string Ipaddress)
        {
            return Ipaddress.Substring(0, Ipaddress.LastIndexOf(".")) + ".*";
        }
        #endregion

        #region "��ˢ�¼��"
        /// <summary>
        /// ��ˢ�¼��
        /// </summary>
        /// <param name="Second">���ʼ����</param>
        /// <param name="UserSession"></param>
        public static bool CheckRefurbish(int Second, HttpSessionState UserSession)
        {

            bool i = true;
            if (UserSession["RefTime"] != null)
            {
                DateTime d1 = Convert.ToDateTime(UserSession["RefTime"]);
                DateTime d2 = Convert.ToDateTime(DateTime.Now.ToString());
                TimeSpan d3 = d2.Subtract(d1);
                if (d3.Seconds < Second)
                {
                    i = false;
                }
                else
                {
                    UserSession["RefTime"] = DateTime.Now.ToString();
                }
            }
            else
            {
                UserSession["RefTime"] = DateTime.Now.ToString();
            }

            return i;
        }
        #endregion

        #region "�ж��Ƿ���Decimal����"
        /// <summary>
        /// �ж��Ƿ���Decimal����
        /// </summary>
        /// <param name="TBstr0">�ж������ַ�</param>
        /// <returns>true��false��</returns>
        public static bool IsDecimal(string TBstr0)
        {
            bool IsBool = false;
            string Intstr0 = "1234567890";
            string IntSign0, StrInt, StrDecimal;
            int IntIndex0, IntSubstr, IndexInt;
            int decimalbool = 0;
            int db = 0;
            bool Bf, Bl;
            if (TBstr0.Length > 2)
            {
                IntIndex0 = TBstr0.IndexOf(".");
                if (IntIndex0 != -1)
                {
                    string StrArr = ".";
                    char[] CharArr = StrArr.ToCharArray();
                    string[] NumArr = TBstr0.Split(CharArr);
                    IndexInt = NumArr.GetUpperBound(0);
                    if (IndexInt > 1)
                    {
                        decimalbool = 1;
                    }
                    else
                    {
                        StrInt = NumArr[0].ToString();
                        StrDecimal = NumArr[1].ToString();
                        //--- �������֣���������
                        if (StrInt.Length > 0)
                        {
                            if (StrInt.Length == 1)
                            {
                                IntSubstr = Intstr0.IndexOf(StrInt);
                                if (IntSubstr != -1)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                            else
                            {
                                for (int i = 0; i <= StrInt.Length - 1; i++)
                                {
                                    IntSign0 = StrInt.Substring(i, 1).ToString();
                                    IntSubstr = Intstr0.IndexOf(IntSign0);
                                    if (IntSubstr != -1)
                                    {
                                        db = db + 0;
                                    }
                                    else
                                    {
                                        db = i + 1;
                                        break;
                                    }
                                }

                                if (db == 0)
                                {
                                    Bf = true;
                                }
                                else
                                {
                                    Bf = false;
                                }
                            }
                        }
                        else
                        {
                            Bf = true;
                        }
                        //----С�����֣�������
                        if (StrDecimal.Length > 0)
                        {
                            for (int j = 0; j <= StrDecimal.Length - 1; j++)
                            {
                                IntSign0 = StrDecimal.Substring(j, 1).ToString();
                                IntSubstr = Intstr0.IndexOf(IntSign0);
                                if (IntSubstr != -1)
                                {
                                    db = db + 0;
                                }
                                else
                                {
                                    db = j + 1;
                                    break;
                                }
                            }
                            if (db == 0)
                            {
                                Bl = true;
                            }
                            else
                            {
                                Bl = false;
                            }
                        }
                        else
                        {
                            Bl = false;
                        }
                        if ((Bf && Bl) == true)
                        {
                            decimalbool = 0;
                        }
                        else
                        {
                            decimalbool = 1;
                        }

                    }

                }
                else
                {
                    decimalbool = 1;
                }

            }
            else
            {
                decimalbool = 1;
            }

            if (decimalbool == 0)
            {
                IsBool = true;
            }
            else
            {
                IsBool = false;
            }

            return IsBool;
        }
        #endregion

        #region "��ȡ�����"
        /// <summary>
        /// ��ȡ�����
        /// </summary>
        /// <param name="length">���������</param>
        /// <returns></returns>
        public static string GetRandomPassword(int length)
        {
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region "��ȡ�û�IP��ַ"
        /// <summary>
        /// ��ȡ�û�IP��ַ
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {

            string user_IP = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }
        #endregion

        #region "3des�����ַ���"
        /// <summary>
        /// 3des�����ַ���
        /// </summary>
        /// <param name="Value">Ҫ�����ַ���</param>
        /// <param name="sKey">��Կ</param>
        /// <param name="sIV">ʸ����ʸ������Ϊ��</param>
        /// <returns></returns>
        public static string EncryptString(string Value, string sKey, string sIV)
        {
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            try
            {
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                byte[] byt;
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                //ָ�����ܵ�����ģʽ
                mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
                //��ȡ�����ü����㷨�����ģʽ
                mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
                byt = Encoding.UTF8.GetBytes(Value);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }

        }

        #endregion

        #region "3des�����ַ���"

        /// <summary>
        /// 3des�����ַ���
        /// </summary>
        /// <param name="Value">Ҫ���ܵ��ַ�</param>
        /// <param name="sKey">��Կ</param>
        /// <param name="sIV">ʸ����ʸ������Ϊ��</param>
        /// <returns></returns>
        public static string DecryptString(string Value, string sKey, string sIV)
        {
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            try
            {
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                byte[] byt;
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
                mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                byt = Convert.FromBase64String(Value);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        #endregion

        #region "MD5����"
        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="str">�����ַ�</param>
        /// <param name="code">����λ��16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }
        #endregion

        #region �ű���ʾ��Ϣ,������ת�����ϲ���
        /// <summary>
        /// �ű���ʾ��Ϣ
        /// </summary>
        /// <param name="Msg">��Ϣ����,����Ϊ��,Ϊ�ձ�ʾ��������ʾ����</param>
        /// <param name="Url">��ת��ַ</param>
        public static string Hint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='javascript'>");
            if (Msg != "")
                rStr.Append("	alert('" + Msg + "');");

            if (Url != "")
                rStr.Append("	window.top.location.href = '" + Url + "';");

            rStr.Append("</script>");

            return rStr.ToString();
        }
        #endregion

        #region �ű���ʾ��Ϣ,������ת����ǰ�����
        /// <summary>
        /// �ű���ʾ��Ϣ
        /// </summary>
        /// <param name="Msg">��Ϣ����,����Ϊ��,Ϊ�ձ�ʾ��������ʾ����</param>
        /// <param name="Url">��ת��ַ,���ѿ���д��ű�</param>
        /// <returns></returns>
        public static string LocalHintJs(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.Append(Url + "\n");
            rStr.Append("</script>");

            return rStr.ToString();
        }

        #endregion

        #region �ű���ʾ��Ϣ,������ת����ǰ�����,��ַΪ��ʱ,������ҳ
        /// <summary>
        /// �ű���ʾ��Ϣ
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string LocalHint(string Msg, string Url)
        {
            System.Text.StringBuilder rStr = new System.Text.StringBuilder();

            rStr.Append("<script language='JavaScript'>\n");
            if (Msg != "")
                rStr.AppendFormat("	alert('{0}');\n", Msg);

            if (Url != "")
                rStr.AppendFormat("	window.location.href = '" + Url + "';\n");
            else
                rStr.AppendFormat(" window.history.back();");

            rStr.Append("</script>\n");

            return rStr.ToString();
        }
        #endregion

        #region "����ǰ���ں�ʱ�����������"
        /// <summary>
        /// ����ǰ���ں�ʱ�����������
        /// </summary>
        /// <param name="Num">�������������</param>
        /// <returns></returns>
        public static string sRndNum(int Num)
        {
            string sTmp_Str = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00") + System.DateTime.Today.Day.ToString("00") + System.DateTime.Now.Hour.ToString("00") + System.DateTime.Now.Minute.ToString("00") + System.DateTime.Now.Second.ToString("00");
            return sTmp_Str + RndNum(Num);
        }
        #endregion

        #region ����0-9�����
        /// <summary>
        /// ����0-9�����
        /// </summary>
        /// <param name="VcodeNum">���ɳ���</param>
        /// <returns></returns>
        public static string RndNum(int VcodeNum)
        {
            StringBuilder sb = new StringBuilder(VcodeNum);
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region "ͨ��RNGCryptoServiceProvider ��������� 0-9"
        /// <summary>
        /// ͨ��RNGCryptoServiceProvider ��������� 0-9 
        /// </summary>
        /// <param name="length">���������</param>
        /// <returns></returns>
        public static string RndNumRNG(int length)
        {
            byte[] bytes = new byte[16];
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                r.GetBytes(bytes);
                sb.AppendFormat("{0}", (int)((decimal)bytes[0] / 256 * 10));
            }
            return sb.ToString();

        }
        #endregion

        #region "�ڵ�ǰ·���ϴ������ڸ�ʽĿ¼(20060205)"
        /// <summary>
        /// �ڵ�ǰ·���ϴ������ڸ�ʽĿ¼(20060205)
        /// </summary>
        /// <param name="sPath">����Ŀ¼��</param>
        /// <returns></returns>
        public static string CreateDir(string sPath)
        {
            string sTemp = System.DateTime.Today.Year.ToString() + System.DateTime.Today.Month.ToString("00") + System.DateTime.Today.Day.ToString("00");
            sPath += sTemp;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@sPath); //���캯������Ŀ¼
            if (di.Exists == false)
            {
                di.Create();
            }

            return sTemp;
        }
        #endregion

        #region "����Ƿ�Ϊ��Ч�ʼ���ַ��ʽ"
        /// <summary>
        /// ����Ƿ�Ϊ��Ч�ʼ���ַ��ʽ
        /// </summary>
        /// <param name="strIn">�����ʼ���ַ</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region "�ʼ�����"
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="strto">�����ʼ���ַ</param>
        /// <param name="strSubject">����</param>
        /// <param name="strBody">����</param>
        public static void SendSMTPEMail(string strto, string strSubject, string strBody)
        {
            string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"];
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
            string SMTPUser = ConfigurationManager.AppSettings["SMTPUser"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            string MailFrom = ConfigurationManager.AppSettings["MailFrom"];
            string MailSubject = ConfigurationManager.AppSettings["MailSubject"];

            SmtpClient client = new SmtpClient(SMTPHost);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(SMTPUser, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
            message.IsBodyHtml = true;

            client.Send(message);
        }
        #endregion

        #region "ת������"
        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {

                return System.Web.HttpUtility.UrlEncode(Encoding.GetEncoding(54936).GetBytes(str));
            }
        }
        #endregion

        #region "��ǰ��ʾӦ��ģ��"
        /// <summary>
        /// ��ʾӦ��ģ��
        /// </summary>
        public static int ApplicationID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationID"]);
                }
                catch
                {
                    return 0;
                }
            }
        }
        #endregion

        #region "��ȡ��½�û�UserID"
        /// <summary>
        /// ��ȡ��½�û�UserID,���δ��½Ϊ0
        /// </summary>
        public static int Get_UserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? Convert.ToInt32(HttpContext.Current.User.Identity.Name) : 0;
            }

        }
        #endregion

        #region "��ȡ��ǰ�û�SessionID"
        /// <summary>
        /// ��ȡ��ǰ�û�SessionID
        /// </summary>
        public static string Get_SessionID
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }
        #endregion

        #region "��ȡ��ǰCookies����"
        /// <summary>
        /// "��ȡ��ǰCookies����
        /// </summary>
        public static string Get_CookiesName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "��ȡWEBCache����ǰ�"
        /// <summary>
        /// ��ȡWEBCache����ǰ�
        /// </summary>
        public static string Get_WebCacheName
        {
            get
            {
                return "FrameWork_YOYO_Lzppcc";
            }
        }
        #endregion

        #region "����ҳ�治������"
        /// <summary>
        /// ����ҳ�治������
        /// </summary>
        public static void SetPageNoCache()
        {

            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Pragma", "No-Cache");
        }
        #endregion
                
        #region "��ȡҳ��url"
        /// <summary>
        /// ��ȡ��ǰ����ҳ���ַ
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }

        /// <summary>
        /// ��⵱ǰurl�Ƿ����ָ�����ַ�
        /// </summary>
        /// <param name="sChar">Ҫ�����ַ�</param>
        /// <returns></returns>
        public static bool CheckScriptNameChar(string sChar)
        {
            bool rBool = false;
            if (GetScriptName.ToLower().LastIndexOf(sChar) >= 0)
                rBool = true;
            return rBool;
        }

        /// <summary>
        /// ��ȡ��ǰҳ�����չ��
        /// </summary>
        public static string GetScriptNameExt
        {
            get {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }

        /// <summary>
        /// ��ȡ��ǰ����ҳ���ַ����
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }

        /// <summary>
        /// ��ȡ��ǰ����ҳ��Url
        /// </summary>
        public static string GetScriptUrl
        {
            get
            {
                return Common.GetScriptNameQueryString == "" ? Common.GetScriptName : string.Format("{0}?{1}", Common.GetScriptName, Common.GetScriptNameQueryString);
            }
        }

        /// <summary>
        /// ���ص�ǰҳ��Ŀ¼��url
        /// </summary>
        /// <param name="FileName">�ļ���</param>
        /// <returns></returns>
        public static string GetHomeBaseUrl(string FileName)
        {
            string Script_Name = Common.GetScriptName;
            return string.Format("{0}/{1}", Script_Name.Remove(Script_Name.LastIndexOf("/")), FileName);
        }
        #endregion

        #region "���ַ���λ����0"
        /// <summary>
        /// ���ַ���λ����0
        /// </summary>
        /// <param name="CharTxt">�ַ���</param>
        /// <param name="CharLen">�ַ�����</param>
        /// <returns></returns>
        public static string FillZero(string CharTxt, int CharLen)
        {
            if (CharTxt.Length < CharLen)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < CharLen - CharTxt.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(CharTxt);
                return sb.ToString();
            }
            else
            {
                return CharTxt;
            }
        }

        #endregion

        #region "�滻JS�������ַ�"
        /// <summary>
        /// ��JS�е������ַ��滻
        /// </summary>
        /// <param name="str">Ҫ�滻�ַ�</param>
        /// <returns></returns>
        public static string ReplaceJs(string str)
        {

            if (str != null)
            {
                str = str.Replace("\"", "&quot;");
                str = str.Replace("(", "&#40;");
                str = str.Replace(")", "&#41;");
                str = str.Replace("%", "&#37;");
            }

            return str;

        }
        #endregion

        #region "��ʽ���ʽ��֤"
        /// <summary>
        /// ��ʽ���ʽ��֤
        /// </summary>
        /// <param name="C_Value">��֤�ַ�</param>
        /// <param name="C_Str">��ʽ���ʽ</param>
        /// <returns>����true������false</returns>
        public static bool CheckRegEx(string C_Value, string C_Str)
        {
            Regex objAlphaPatt;
            objAlphaPatt = new Regex(C_Str, RegexOptions.Compiled);


            return objAlphaPatt.Match(C_Value).Success;
        }
        #endregion

        #region "��⵱ǰ�ַ��Ƿ�����,�ŷֿ����ַ�����(xx,sss,xaf,fdsf)"
        /// <summary>
        /// ��⵱ǰ�ַ��Ƿ�����,�ŷֿ����ַ�����(xx,sss,xaf,fdsf)
        /// </summary>
        /// <param name="TempChar">�����ַ�</param>
        /// <param name="TempStr">������ַ���</param>
        /// <returns>����true,������false</returns>
        public static bool Check_Char_Is(string TempChar, string TempStr)
        {
            bool rBool = false;
            if (TempChar != null && TempStr != null)
            {
                string[] TempStrArray = TempStr.Split(',');
                for (int i = 0; i < TempStrArray.Length; i++)
                {
                    if (TempChar == TempStrArray[i].Trim())
                    {
                        rBool = true;
                        break;
                    }
                }
            }
            return rBool;
        }
        #endregion

        #region "�ϴ��ļ�����"
        /// <summary>
        /// �ϴ�Ŀ¼����
        /// </summary>
        public static string UpLoadDir
        {
            get
            {
                try
                {
                    return new System.Web.UI.Control().ResolveUrl("~/Public/");
                }
                catch
                {
                    return "/Public/";
                }
            }
        }

        #endregion

        #region "ǰ̨����"

        /// <summary>
        /// �˵���� 0:���� 1:���� 2:����
        /// </summary>
        public static int MenuStyle
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["MenuStyle"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["MenuStyle"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["MenuStyle"].Value = value.ToString();
            }
        }

        /// <summary>
        /// ��ҳÿҳ��¼��(Ĭ��10)
        /// </summary>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["PageSize"] == null)
                {
                    return 10;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["PageSize"].Value);
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["PageSize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// �����ʽ(Ĭ��default)
        /// </summary>
        public static string TableSink
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["TableSink"] == null)
                {
                    return "default";
                }
                else
                {
                    return HttpContext.Current.Request.Cookies["TableSink"].Value.ToString();
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["TableSink"].Value = value;
            }
        }

        /// <summary>
        /// �û����߹���ʱ�� (��)Ĭ��30�� ����û��ڵ�ǰ�趨��ʱ����û���κβ���,���ᱻϵͳ�Զ��˳�
        /// </summary>
        public static int OnlineMinute
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["OnlineMinute"]);
                }
                catch
                {
                    return 30;
                }
            }
        }

        #endregion

        #region "���ݿ�����"

        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        public static string GetDBType
        {
            get
            {
                return ConfigurationManager.AppSettings["DBType"];
            }
        }

        /// <summary>
        /// ��ȡ���ݿ������ַ���
        /// </summary>
        public static string GetConnString
        {
            get
            {
                return ConfigurationManager.AppSettings[GetDBType];
            }
        }
        #endregion

        #region "����GUID"
        /// <summary>
        /// ��ȡһ��GUID��HashCode
        /// </summary>
        public static int GetGUIDHashCode
        {
            get
            {
                return GetGUID.GetHashCode();
            }
        }
        /// <summary>
        /// ��ȡһ��GUID�ַ���
        /// </summary>
        public static string GetGUID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        #endregion

        #region "����Cookies�洢��GUID hashCode"
        /// <summary>
        /// ����Cookies�洢��GUID hashCode
        /// </summary>
        public static int CookiesGuid
        {
            get
            {
                string cookiesname = Get_CookiesName + "CookiesGuid";
                int rInt = GetGUIDHashCode;
                if (HttpContext.Current.Request.Cookies[cookiesname] == null)
                {
                    HttpContext.Current.Response.Cookies[cookiesname].Value = rInt.ToString();
                }
                else
                {
                    rInt = Convert.ToInt32(HttpContext.Current.Request.Cookies[cookiesname].Value);

                }
                return rInt;
            }
            set
            {
                string cookiesname = Get_CookiesName + "CookiesGuid";
                if (value == 0)
                    HttpContext.Current.Response.Cookies[cookiesname].Expires = DateTime.Now.AddDays(-30);
                else
                    HttpContext.Current.Response.Cookies[cookiesname].Value = value.ToString();
            }
        }
        #endregion

        #region "����ˢ�²����б�js"
        /// <summary>
        /// ����ˢ�²����б�js
        /// </summary>
        public static string BuildJs
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language=javascript>");
                sb.Append("window.parent.leftbody.location.reload();");
                sb.Append("</script>");

                return sb.ToString();
            }
        }
        #endregion

        #region "��ȡ������IP"
        /// <summary>
        /// ��ȡ������IP
        /// </summary>
        public static string GetServerIp
        {
            get {
                return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"].ToString();
            }
        }
        #endregion

        #region "��ȡ����������ϵͳ"
        /// <summary>
        /// ��ȡ����������ϵͳ
        /// </summary>
        public static string GetServerOS
        {
            get {
                return Environment.OSVersion.VersionString;
            }
        }
        #endregion

        #region "��ȡ����������"
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public static string GetServerHost
        {
            get {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            }
        }
        #endregion

        #region "��ʾ������ϸ��Ϣ���û�ҳ��(�û���������,����������������Ϊfalse)"
        /// <summary>
        /// ��ʾ������ϸ��Ϣ���û�ҳ��(�û���������,����������������Ϊfalse)
        /// </summary>
        public static bool DispError
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["DispError"]);
            }
        }


        #endregion


        public static string ParseTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        ///   ȡ���ı��е�ͼƬ��ַ
        /**/
        ///   <summary>
        ///   ȡ���ı��е�ͼƬ��ַ
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }


        ///   <summary>
        ///   ȥ��HTML���
        ///   </summary>
        public static string NoHTML(string Htmlstring)
        {
            //ɾ���ű�
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //ɾ��HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }



    }


    /// <summary>
    /// ��ȡ��ʽ
    /// </summary>
    public enum MethodType
    {
        /// <summary>
        /// Post��ʽ
        /// </summary>
        Post = 1,
        /// <summary>
        /// Get��ʽ
        /// </summary>
        Get = 2
    }

    /// <summary>
    /// ��ȡ��������
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// �ַ�
        /// </summary>
        Str = 1,
        /// <summary>
        /// ����
        /// </summary>
        Dat = 2,
        /// <summary>
        /// ����
        /// </summary>
        Int = 3,
        /// <summary>
        /// ������
        /// </summary>
        Long = 4,
        /// <summary>
        /// ˫����С��
        /// </summary>
        Double = 5,
        /// <summary>
        /// ֻ���ַ�������
        /// </summary>
        CharAndNum = 6,
        /// <summary>
        /// ֻ���ʼ���ַ
        /// </summary>
        Email = 7,
        /// <summary>
        /// ֻ���ַ������ֺ�����
        /// </summary>
        CharAndNumAndChinese = 8

    }
}