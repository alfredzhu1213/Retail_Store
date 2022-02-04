using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseOrderReturn:实体类(属性说明自动提取数据库字段的描述信息)
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
		/// 流水号
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// 收货单号
		/// </summary>
		public string AcceptSerialNum
		{
			set{ _acceptserialnum=value;}
			get{return _acceptserialnum;}
		}
		/// <summary>
		/// 供应商id
		/// </summary>
		public int? SupId
		{
			set{ _supid=value;}
			get{return _supid;}
		}
		/// <summary>
		/// 供应商
		/// </summary>
		public string SupCode
		{
			set{ _supcode=value;}
			get{return _supcode;}
		}
		/// <summary>
		/// 门店ID
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 门店
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 单据状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 制单人员
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 制单日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string ApprUserName
		{
			set{ _apprusername=value;}
			get{return _apprusername;}
		}
		/// <summary>
		/// 审核日期
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

