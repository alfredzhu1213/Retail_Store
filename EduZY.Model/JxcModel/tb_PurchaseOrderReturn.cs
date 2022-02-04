using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseOrderReturn:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_PurchaseOrderReturn
	{
		public tb_PurchaseOrderReturn()
		{}
		#region Model
		private int _id;
		private string _serialnum;
		private string _acceptserialnum;
		private int? _supid;
		private string _supcode;
		private int? _storeid;
		private string _storecode;
		private string _remark;
		private string _status;
		private string _createusername;
		private DateTime? _createdate= DateTime.Now;
		private string _apprusername;
		private DateTime? _apprdate;
		private string _handledusername;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��ˮ��
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// �ջ�����
		/// </summary>
		public string AcceptSerialNum
		{
			set{ _acceptserialnum=value;}
			get{return _acceptserialnum;}
		}
		/// <summary>
		/// ��Ӧ��id
		/// </summary>
		public int? SupId
		{
			set{ _supid=value;}
			get{return _supid;}
		}
		/// <summary>
		/// ��Ӧ��
		/// </summary>
		public string SupCode
		{
			set{ _supcode=value;}
			get{return _supcode;}
		}
		/// <summary>
		/// �ŵ�ID
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// �ŵ�
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
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
		/// ����״̬
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �Ƶ���Ա
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// �Ƶ�����
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public string ApprUserName
		{
			set{ _apprusername=value;}
			get{return _apprusername;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public DateTime? ApprDate
		{
			set{ _apprdate=value;}
			get{return _apprdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HandledUserName
		{
			set{ _handledusername=value;}
			get{return _handledusername;}
		}
		#endregion Model


        public string JsonString { get; set; }

        public string SupName { get; set; }

        public string StoreName { get; set; }
    }
}

