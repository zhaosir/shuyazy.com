using System;
namespace Kpages.Model
{
	/// <summary>
	/// ʵ����Category ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// Ψһ���
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public string category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// �ϼ�ID
		/// </summary>
		public int upID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// ��������(0,���ĵ�;1,��ָ��Link)
		/// </summary>
		public int linkType
		{
			set{ _linktype=value;}
			get{return _linktype;}
		}
		/// <summary>
		/// ��Ŀ�ĵ�����(0,����;1,��Ʒ;2,���)
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ָ����Ŀ���ӵ�ַ
		/// </summary>
		public string link
		{
			set{ _link=value;}
			get{return _link;}
		}
		/// <summary>
		/// ͬ���������
		/// </summary>
		public int sort
		{
			set{ _sort= value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

