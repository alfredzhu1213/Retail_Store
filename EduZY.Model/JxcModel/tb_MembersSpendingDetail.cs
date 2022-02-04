using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_MembersSpendingDetail
		public class tb_MembersSpendingDetail
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 会员ID
        /// </summary>		
		private int _memberid;
        public int MemberID
        {
            get{ return _memberid; }
            set{ _memberid = value; }
        }        
		/// <summary>
		/// 会员编码
        /// </summary>		
		private string _membercode;
        public string MemberCode
        {
            get{ return _membercode; }
            set{ _membercode = value; }
        }        
		/// <summary>
		/// 会员姓名
        /// </summary>		
		private string _membername;
        public string MemberName
        {
            get{ return _membername; }
            set{ _membername = value; }
        }        
		/// <summary>
		/// 门店ID
        /// </summary>		
		private int _storeid;
        public int StoreID
        {
            get{ return _storeid; }
            set{ _storeid = value; }
        }        
		/// <summary>
		/// 门店编码
        /// </summary>		
		private string _storecode;
        public string StoreCode
        {
            get{ return _storecode; }
            set{ _storecode = value; }
        }        
		/// <summary>
		/// 门店名称
        /// </summary>		
		private string _storename;
        public string StoreName
        {
            get{ return _storename; }
            set{ _storename = value; }
        }        
		/// <summary>
		/// 票号
        /// </summary>		
		private string _billno;
        public string BillNo
        {
            get{ return _billno; }
            set{ _billno = value; }
        }        
		/// <summary>
		/// 货号
        /// </summary>		
		private string _hhno;
        public string HHNo
        {
            get{ return _hhno; }
            set{ _hhno = value; }
        }        
		/// <summary>
		/// 商品ID
        /// </summary>		
		private int _goodsid;
        public int GoodsID
        {
            get{ return _goodsid; }
            set{ _goodsid = value; }
        }        
		/// <summary>
		/// 商品编码
        /// </summary>		
		private string _goodscode;
        public string GoodsCode
        {
            get{ return _goodscode; }
            set{ _goodscode = value; }
        }        
		/// <summary>
		/// 商品名称
        /// </summary>		
		private string _goodsname;
        public string GoodsName
        {
            get{ return _goodsname; }
            set{ _goodsname = value; }
        }        
		/// <summary>
		/// 规格
        /// </summary>		
		private string _gg;
        public string GG
        {
            get{ return _gg; }
            set{ _gg = value; }
        }        
		/// <summary>
		/// 单位
        /// </summary>		
		private string _unit;
        public string Unit
        {
            get{ return _unit; }
            set{ _unit = value; }
        }        
		/// <summary>
		/// Count
        /// </summary>		
		private int _count;
        public int Count
        {
            get{ return _count; }
            set{ _count = value; }
        }        
		/// <summary>
		/// 原价
        /// </summary>		
		private decimal _primeprice;
        public decimal PrimePrice
        {
            get{ return _primeprice; }
            set{ _primeprice = value; }
        }        
		/// <summary>
		/// 售价
        /// </summary>		
		private decimal _price;
        public decimal Price
        {
            get{ return _price; }
            set{ _price = value; }
        }        
		/// <summary>
		/// 交易方式
        /// </summary>		
		private string _tradetype;
        public string TradeType
        {
            get{ return _tradetype; }
            set{ _tradetype = value; }
        }        
		/// <summary>
		/// 销售金额
        /// </summary>		
		private decimal _saleaccount;
        public decimal SaleAccount
        {
            get{ return _saleaccount; }
            set{ _saleaccount = value; }
        }        
		/// <summary>
		/// 商品类别ID
        /// </summary>		
		private int _goodstypeid;
        public int GoodsTypeId
        {
            get{ return _goodstypeid; }
            set{ _goodstypeid = value; }
        }        
		/// <summary>
		/// 商品类别编码
        /// </summary>		
		private string _goodstypecode;
        public string GoodsTypeCode
        {
            get{ return _goodstypecode; }
            set{ _goodstypecode = value; }
        }        
		/// <summary>
		/// 商品类别名称
        /// </summary>		
		private string _goodstypename;
        public string GoodsTypeName
        {
            get{ return _goodstypename; }
            set{ _goodstypename = value; }
        }        
		/// <summary>
		/// 收银员ID
        /// </summary>		
		private int _syerid;
        public int SYerID
        {
            get{ return _syerid; }
            set{ _syerid = value; }
        }        
		/// <summary>
		/// 收银员编码
        /// </summary>		
		private string _syercode;
        public string SYerCode
        {
            get{ return _syercode; }
            set{ _syercode = value; }
        }        
		/// <summary>
		/// 收银员姓名
        /// </summary>		
		private string _syername;
        public string SYerName
        {
            get{ return _syername; }
            set{ _syername = value; }
        }        
		/// <summary>
		/// 交易时间
        /// </summary>		
		private DateTime? _tradedatetime;
        public DateTime? TradeDateTime
        {
            get{ return _tradedatetime; }
            set{ _tradedatetime = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }


   
	}
}