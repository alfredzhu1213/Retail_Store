using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Store:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_Store
	{
		public tb_Store()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _lxr;
		private string _tel;
		private string _address;
		private DateTime? _addtime= DateTime.Now;
     

		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        private string _text;
        public string text
        {
            set { _text = value; }
            get { return _text; }
        }
     
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string lxr
		{
			set{ _lxr=value;}
			get{return _lxr;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// ��ϵ��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

