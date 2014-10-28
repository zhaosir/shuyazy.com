using System;
namespace Kpages.Model
{
	/// <summary>
	/// 实体类UserInfo 。(属性说明自动提取数据库字段的描述信息)
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
		/// 唯一标记
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名，不能重复
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? regDate
		{
			set{ _regdate=value;}
			get{return _regdate;}
		}
		/// <summary>
		/// 性别(0:男,1:女)
		/// </summary>
		public int? sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string mail
		{
			set{ _mail=value;}
			get{return _mail;}
		}
		/// <summary>
		/// 权限(0:普通用户,1:管理员)
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model

	}
}

