using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////View_SelectStockReport_StockDetail_RptStmMonthly
		public class View_SelectStockReport_StockDetail_RptStmMonthly
        {
            private string _brandname;
            public string BrandName
            {
                set { _brandname = value; }
                get { return _brandname; }
            }
            /// <summary>
            /// 
            /// </summary>
            private string _productclassname;
            public string ProductClassName
            {
                set { _productclassname = value; }
                get { return _productclassname; }
            }
   		     
      	/// <summary>
		/// StoreName
        /// </summary>		
		private string _storename;
        public string StoreName
        {
            get{ return _storename; }
            set{ _storename = value; }
        }        
		/// <summary>
		/// CreateDate
        /// </summary>		
		private string _createdate;
        public string CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// HHNo
        /// </summary>		
		private string _hhno;
        public string HHNo
        {
            get{ return _hhno; }
            set{ _hhno = value; }
        }        
		/// <summary>
		/// ProductName
        /// </summary>		
		private string _productname;
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
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
		/// Unit
        /// </summary>		
		private string _unit;
        public string Unit
        {
            get{ return _unit; }
            set{ _unit = value; }
        }        
		/// <summary>
		/// Num
        /// </summary>		
		private decimal _num;
        public decimal Num
        {
            get{ return _num; }
            set{ _num = value; }
        }        
		/// <summary>
		/// Price
        /// </summary>		
		private decimal _price;
        public decimal Price
        {
            get{ return _price; }
            set{ _price = value; }
        }        
		/// <summary>
		/// OutNum
        /// </summary>		
		private decimal _outnum;
        public decimal OutNum
        {
            get{ return _outnum; }
            set{ _outnum = value; }
        }        
		/// <summary>
		/// SumPrice
        /// </summary>		
		private decimal _sumprice;
        public decimal SumPrice
        {
            get{ return _sumprice; }
            set{ _sumprice = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

   
	}
}