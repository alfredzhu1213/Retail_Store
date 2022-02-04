using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PromotionPlanSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PromotionPlanSheet
	{
		public tb_PromotionPlanSheet()
		{}
		#region Model
		private int _id;
		private string _serialnum;
		private string _title;
		private int? _storeid;
		private string _storecode;
        private string _promotionstyles = "直接特价";
		private DateTime? _startdate;
		private DateTime? _enddate;
		private string _memtypecode;
		private string _memtypename;
		private string _effectweeklist="-";
		private string _remark;
		private string _createusername;
		private DateTime? _createdate= DateTime.Now;
		private string _apprusername;
		private DateTime? _appdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SerialNum
		{
			set{ _serialnum=value;}
			get{return _serialnum;}
		}
		/// <summary>
		/// 促销名称
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 促销门店ID
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 促销门店编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 促销模式
		/// </summary>
		public string PromotionStyles
		{
			set{ _promotionstyles=value;}
			get{return _promotionstyles;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 会员类别
		/// </summary>
		public string MemTypeCode
		{
			set{ _memtypecode=value;}
			get{return _memtypecode;}
		}
		/// <summary>
		/// 会员类别名
		/// </summary>
		public string MemTypeName
		{
			set{ _memtypename=value;}
			get{return _memtypename;}
		}
		/// <summary>
		/// 每周生效
		/// </summary>
		public string EffectWeekList
		{
			set{ _effectweeklist=value;}
			get{return _effectweeklist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		///  制单人
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
		public DateTime? AppDate
		{
			set{ _appdate=value;}
			get{return _appdate;}
		}
		#endregion Model


        public string Status { get; set; }

        public string JsonString { get; set; }

        public string StoreName { get; set; }
    }
}

