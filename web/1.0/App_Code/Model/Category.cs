using System;
namespace Kpages.Model
{
	/// <summary>
	/// 实体类Category 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Category
	{
		public Category()
		{}
		#region Model
		private int _id;
		private string _category;
		private int _upid;
		private int _linktype;
		private int _type;
		private string _link;
		private int _sort;
		/// <summary>
		/// 唯一标记
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 栏目名称
		/// </summary>
		public string category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 上级ID
		/// </summary>
		public int upID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// 链接类型(0,到文档;1,到指定Link)
		/// </summary>
		public int linkType
		{
			set{ _linktype=value;}
			get{return _linktype;}
		}
		/// <summary>
		/// 栏目文档类型(0,新闻;1,产品;2,相册)
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 指定栏目链接地址
		/// </summary>
		public string link
		{
			set{ _link=value;}
			get{return _link;}
		}
		/// <summary>
		/// 同父级排序号
		/// </summary>
		public int sort
		{
			set{ _sort= value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

