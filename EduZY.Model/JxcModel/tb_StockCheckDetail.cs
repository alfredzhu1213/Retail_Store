using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_StockCheckDetail
		public class tb_StockCheckDetail
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
		/// StocOutId
        /// </summary>		
		private int _stocoutid;
        public int StocOutId
        {
            get{ return _stocoutid; }
            set{ _stocoutid = value; }
        }        
		/// <summary>
		/// 产品名
        /// </summary>		
		private string _productname;
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
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
		/// 箱数
        /// </summary>		
		private decimal? _boxnum;
        public decimal? BoxNum
        {
            get{ return _boxnum; }
            set{ _boxnum = value; }
        }        
		/// <summary>
		/// 数量
        /// </summary>		
		private decimal? _num;
        public decimal? Num
        {
            get{ return _num; }
            set{ _num = value; }
        }        
		/// <summary>
		/// 系统库存
        /// </summary>		
		private decimal? _sysstocknum;
        public decimal? SysStockNum
        {
            get{ return _sysstocknum; }
            set{ _sysstocknum = value; }
        }        
		/// <summary>
		/// 盈亏数量
        /// </summary>		
		private decimal? _phasesnum;
        public decimal? PhasesNum
        {
            get{ return _phasesnum; }
            set{ _phasesnum = value; }
        }        
		/// <summary>
		/// 零售单价
        /// </summary>		
		private decimal? _salesprice;
        public decimal? SalesPrice
        {
            get{ return _salesprice; }
            set{ _salesprice = value; }
        }        
		/// <summary>
		/// 盈亏售价
        /// </summary>		
		private decimal? _phasesprice;
        public decimal? PhasesPrice
        {
            get{ return _phasesprice; }
            set{ _phasesprice = value; }
        }        
		/// <summary>
		/// 说明
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// AddTime
        /// </summary>		
		private DateTime? _addtime;
        public DateTime? AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
		/// <summary>
		/// ProductId
        /// </summary>		
		private int _productid;
        public int ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

        public string StoreName { get; set; }
   
	}
}