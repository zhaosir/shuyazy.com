using System;
namespace Kpages.Model
{
	/// <summary>
	/// 实体类File 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class File
	{
		public File()
		{}
		#region Model
		private int _id;
		private int _docid;
		private string _title;
		private string _url;
		private int _type;
		private int? _sort;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 所属文档ID
		/// </summary>
		public int DocID
		{
			set{ _docid=value;}
			get{return _docid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 文件地址
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 文件类型(0:图像,1:下载)
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 同文档排序号
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

