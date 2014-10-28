using System;
namespace Kpages.Model
{
	/// <summary>
	/// ʵ����File ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �����ĵ�ID
		/// </summary>
		public int DocID
		{
			set{ _docid=value;}
			get{return _docid;}
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
		/// �ļ���ַ
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// �ļ�����(0:ͼ��,1:����)
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// ͬ�ĵ������
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

