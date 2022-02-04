using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// View_SelectChuxiaoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_SelectChuxiaoList
	{
		public View_SelectChuxiaoList()
		{}
		#region Model
		private int _id;
		private string _hhno;
		private string _productname;
		private decimal _oldprice;
		private decimal _memberprice;
		private decimal _jingg;
		private decimal? _tjprice;
		private decimal? _zk;
		private string _storename;
		private int? _storeid;
		private string _promotionstyles;
		private DateTime? _startdate;
		private DateTime? _enddate;
		private string _memtypename;
		private string _effectweeklist;
		private string _remark;
		private string _createusername;
		private string _status;
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
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal OldPrice
		{
			set{ _oldprice=value;}
			get{return _oldprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal JinGG
		{
			set{ _jingg=value;}
			get{return _jingg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tjPrice
		{
			set{ _tjprice=value;}
			get{return _tjprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ZK
		{
			set{ _zk=value;}
			get{return _zk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreName
		{
			set{ _storename=value;}
			get{return _storename;}
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
		/// 
		/// </summary>
		public string PromotionStyles
		{
			set{ _promotionstyles=value;}
			get{return _promotionstyles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemTypeName
		{
			set{ _memtypename=value;}
			get{return _memtypename;}
		}
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model
        public string Title
        {
            set;
            get;
        }
	}
}

