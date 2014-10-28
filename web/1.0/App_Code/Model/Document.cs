using System;
namespace Kpages.Model
{
	/// <summary>
	/// 实体类Document 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Document
	{
		public Document()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _cateid;
		private string _contents;
		private DateTime _postdate;
		private int _post;
		private string _seotitle;
		private string _keys;
		private string _descr;
		private int _sort;
		private int _state;
		private int _builded;
		/// <summary>
		/// 唯一标记
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 栏目ID
		/// </summary>
		public int cateID
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 发表日期
		/// </summary>
		public DateTime postDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// 点击量
		/// </summary>
		public int post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// seo 标题
		/// </summary>
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// 关键字
		/// </summary>
		public string keys
		{
			set{ _keys=value;}
			get{return _keys;}
		}
		/// <summary>
		/// 页面描述
		/// </summary>
		public string descr
		{
			set{ _descr=value;}
			get{return _descr;}
		}
		/// <summary>
		/// 同栏目排序号
		/// </summary>
		public int sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 控制状态
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 生成状态
		/// </summary>
		public int builded
		{
			set{ _builded=value;}
			get{return _builded;}
		}
		#endregion Model

	}
}

