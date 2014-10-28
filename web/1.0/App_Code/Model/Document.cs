using System;
namespace Kpages.Model
{
	/// <summary>
	/// ʵ����Document ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// Ψһ���
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��ĿID
		/// </summary>
		public int cateID
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime postDate
		{
			set{ _postdate=value;}
			get{return _postdate;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// seo ����
		/// </summary>
		public string seoTitle
		{
			set{ _seotitle=value;}
			get{return _seotitle;}
		}
		/// <summary>
		/// �ؼ���
		/// </summary>
		public string keys
		{
			set{ _keys=value;}
			get{return _keys;}
		}
		/// <summary>
		/// ҳ������
		/// </summary>
		public string descr
		{
			set{ _descr=value;}
			get{return _descr;}
		}
		/// <summary>
		/// ͬ��Ŀ�����
		/// </summary>
		public int sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// ����״̬
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// ����״̬
		/// </summary>
		public int builded
		{
			set{ _builded=value;}
			get{return _builded;}
		}
		#endregion Model

	}
}

