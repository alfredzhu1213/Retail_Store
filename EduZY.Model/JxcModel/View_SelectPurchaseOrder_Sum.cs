using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// View_SelectPurchaseOrder_Sum:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_SelectPurchaseOrder_Sum
	{
		public View_SelectPurchaseOrder_Sum()
		{}
		#region Model
        private Int64 _KeyID;
		private string _createusername;
        private string _createdate;
		private string _productname;
		private string _hhno;
		private string _gg;
		private string _unit;
		private decimal _boxnum;
		private decimal _num;
		private decimal? _sendnum;
		private decimal? _price;
		private decimal? _sumprice;
		private int? _productid;
		private int? _storeid;
		private int? _supid;
		private string _productclassname;
		private string _productbrandname;
		private int? _classid;
		private int? _brandid;
		private string _serialnum;
		private decimal? _thnum;
		private decimal? _thsendnum;
		private decimal? _thprice;
		/// <summary>
		/// 
		/// </summary>
        public Int64 KeyID
		{
            set { _KeyID = value; }
            get { return _KeyID; }
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
        public string CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GG
		{
			set{ _gg=value;}
			get{return _gg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BoxNum
		{
			set{ _boxnum=value;}
			get{return _boxnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SendNum
		{
			set{ _sendnum=value;}
			get{return _sendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SumPrice
		{
			set{ _sumprice=value;}
			get{return _sumprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public int? SupId
		{
			set{ _supid=value;}
			get{return _supid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductClassName
		{
			set{ _productclassname=value;}
			get{return _productclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductBrandName
		{
			set{ _productbrandname=value;}
			get{return _productbrandname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BrandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
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
		/// 
		/// </summary>
		public decimal? THNum
		{
			set{ _thnum=value;}
			get{return _thnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? THSendNum
		{
			set{ _thsendnum=value;}
			get{return _thsendnum;}
		}
        public decimal? THSumPrice
		{
            set;
            get;
		}
        


		/// <summary>
		/// 
		/// </summary>
		public decimal? THPrice
		{
			set{ _thprice=value;}
			get{return _thprice;}
		}

        /// </summary>
        public string StoreName
        {
            set { _StoreName = value; }
            get { return _StoreName; }
        }

        private string _StoreName;
        public string ProductClassCode
        {
            set ;
            get;
        }
        public string BrandCode
        {
            set ;
            get;
        }
        public string SupplierCode
        {
            set;
            get;
        }
        public string SupplierName
        {
            set;
            get;
        }
        public string CGType
        {
            set;
            get;
        }
        public string Remark
        {
            set;
            get;
        }
  
		#endregion Model

	}
    public partial class View_SelectPurchaseOrder_SumMX
    {
        public View_SelectPurchaseOrder_SumMX()
        { }
        #region Model
        private Int64 _KeyID;
        private string _createusername;

        private string _productname;
        private string _hhno;
        private string _gg;
        private string _unit;
        private decimal _boxnum;
        private decimal _num;
        private decimal? _sendnum;
        private decimal? _price;
        private decimal? _sumprice;
        private int? _productid;
        private int? _storeid;
        private int? _supid;
        private string _productclassname;
        private string _productbrandname;
        private int? _classid;
        private int? _brandid;
        private string _serialnum;
        private decimal? _thnum;
        private decimal? _thsendnum;
        private decimal? _thprice;
        /// <summary>
        /// 
        /// </summary>
        public Int64 KeyID
        {
            set { _KeyID = value; }
            get { return _KeyID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HHNo
        {
            set { _hhno = value; }
            get { return _hhno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GG
        {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal BoxNum
        {
            set { _boxnum = value; }
            get { return _boxnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SendNum
        {
            set { _sendnum = value; }
            get { return _sendnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SumPrice
        {
            set { _sumprice = value; }
            get { return _sumprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? StoreId
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SupId
        {
            set { _supid = value; }
            get { return _supid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductClassName
        {
            set { _productclassname = value; }
            get { return _productclassname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductBrandName
        {
            set { _productbrandname = value; }
            get { return _productbrandname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BrandId
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SerialNum
        {
            set { _serialnum = value; }
            get { return _serialnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? THNum
        {
            set { _thnum = value; }
            get { return _thnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? THSendNum
        {
            set { _thsendnum = value; }
            get { return _thsendnum; }
        }
        public decimal? THSumPrice
        {
            set;
            get;
        }



        /// <summary>
        /// 
        /// </summary>
        public decimal? THPrice
        {
            set { _thprice = value; }
            get { return _thprice; }
        }

        /// </summary>
        public string StoreName
        {
            set { _StoreName = value; }
            get { return _StoreName; }
        }

        private string _StoreName;
        public string ProductClassCode
        {
            set;
            get;
        }
        public string BrandCode
        {
            set;
            get;
        }
        public string SupplierCode
        {
            set;
            get;
        }
        public string SupplierName
        {
            set;
            get;
        }
        public string CGType
        {
            set;
            get;
        }
        public string Remark
        {
            set;
            get;
        }

        #endregion Model

    }
}

