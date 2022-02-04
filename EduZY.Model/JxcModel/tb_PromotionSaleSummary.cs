using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_PromotionSaleSummary
		public class tb_PromotionSaleSummary
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
		/// 货号
        /// </summary>		
		private string _hhno;
        public string HHNo
        {
            get{ return _hhno; }
            set{ _hhno = value; }
        }        
		/// <summary>
		/// 商品id
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
		/// GG
        /// </summary>		
		private string _gg;
        public string GG
        {
            get{ return _gg; }
            set{ _gg = value; }
        }        
		/// <summary>
		/// TradeType
        /// </summary>		
		private string _tradetype;
        public string TradeType
        {
            get{ return _tradetype; }
            set{ _tradetype = value; }
        }        
		/// <summary>
		/// 销售数量
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
		/// 销售金额
        /// </summary>		
		private decimal _saleaccount;
        public decimal SaleAccount
        {
            get{ return _saleaccount; }
            set{ _saleaccount = value; }
        }        
		/// <summary>
		/// RLAccount
        /// </summary>		
		private decimal _rlaccount;
        public decimal RLAccount
        {
            get{ return _rlaccount; }
            set{ _rlaccount = value; }
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
		/// 品牌ID
        /// </summary>		
		private int _brandid;
        public int BrandID
        {
            get{ return _brandid; }
            set{ _brandid = value; }
        }        
		/// <summary>
		/// 品牌编码
        /// </summary>		
		private string _brandcode;
        public string BrandCode
        {
            get{ return _brandcode; }
            set{ _brandcode = value; }
        }        
		/// <summary>
		/// 品牌名称
        /// </summary>		
		private string _brandname;
        public string BrandName
        {
            get{ return _brandname; }
            set{ _brandname = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

        public string StoreName { get; set; }
   
	}
}