using System;
namespace Kpages.Model
{
	/// <summary>
	/// ʵ����UserInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private DateTime? _regdate;
		private int? _sex;
		private DateTime? _birthday;
		private string _mail;
		private int? _type;
		private string _tel;
		/// <summary>
		/// Ψһ���
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û����������ظ�
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// ע��ʱ��
		/// </summary>
		public DateTime? regDate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		/// <summary>
		/// �Ա�(0:��,1:Ů)
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string mail
		{
			set{ _mail=value;}
			get{return _mail;}
		}
		/// <summary>
		/// Ȩ��(0:��ͨ�û�,1:����Ա)
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model

	}
}

