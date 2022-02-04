using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosClient:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_PosClient
	{
		public tb_PosClient()
		{}
		#region Model
		private int _id;
        private string _guidid;
		private string _code;
		private string _name;
		private string _status;
		private string _remark;
		private int? _storeid;
		private int? _adduserid;
		private DateTime? _addtime;
		private int? _updateuserid;
		private DateTime? _updatetime;

        public string _AddUserName;
        public string _UpdateUserName;
        public string _StoreName;



        public string AddUserName
        {
            set { _AddUserName = value; }
            get { return _AddUserName; }
        }

        public string UpdateUserName
        {
            set { _UpdateUserName = value; }
            get { return _UpdateUserName; }
        }

        public string StoreName
        {
            set { _StoreName = value; }
            get { return _StoreName; }
        }
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ψһ��
		/// </summary>
		public string GuidID
		{
			set{ _guidid=value;}
			get{return _guidid;}
		}
		/// <summary>
		/// ���
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
		/// ״̬
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// ����Ա
		/// </summary>
		public int? AddUserId
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// �Ǽ�ʱ��
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �޸���
		/// </summary>
		public int? UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

