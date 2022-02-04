using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////View_SelectStockReport_StockDetail_RptStmIODetail
		public class View_SelectStockReport_StockDetail_RptStmIODetail
	{
   		     
      	/// <summary>
		/// SumPrice
        /// </summary>		
		private decimal _sumprice;
        public decimal SumPrice
        {
            get{ return _sumprice; }
            set{ _sumprice = value; }
        }        
		/// <summary>
		/// CreateDate
        /// </summary>		
		private DateTime _createdate;
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// Type
        /// </summary>		
		private string _type;
        public string Type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
		/// <summary>
		/// StockType
        /// </summary>		
		private string _stocktype;
        public string StockType
        {
            get{ return _stocktype; }
            set{ _stocktype = value; }
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
		/// HHNo
        /// </summary>		
		private string _hhno;
        public string HHNo
        {
            get{ return _hhno; }
            set{ _hhno = value; }
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
		/// SupId
        /// </summary>		
		private int _supid;
        public int SupId
        {
            get{ return _supid; }
            set{ _supid = value; }
        }        
		/// <summary>
		/// SupplierName
        /// </summary>		
		private string _suppliername;
        public string SupplierName
        {
            get{ return _suppliername; }
            set{ _suppliername = value; }
        }        
		/// <summary>
		/// SupplierCode
        /// </summary>		
		private string _suppliercode;
        public string SupplierCode
        {
            get{ return _suppliercode; }
            set{ _suppliercode = value; }
        }        
		/// <summary>
		/// BrandCode
        /// </summary>		
		private string _brandcode;
        public string BrandCode
        {
            get{ return _brandcode; }
            set{ _brandcode = value; }
        }        
		/// <summary>
		/// BrandName
        /// </summary>		
		private string _brandname;
        public string BrandName
        {
            get{ return _brandname; }
            set{ _brandname = value; }
        }        
		/// <summary>
		/// ProductClassCode
        /// </summary>		
		private string _productclasscode;
        public string ProductClassCode
        {
            get{ return _productclasscode; }
            set{ _productclasscode = value; }
        }        
		/// <summary>
		/// ProductClassName
        /// </summary>		
		private string _productclassname;
        public string ProductClassName
        {
            get{ return _productclassname; }
            set{ _productclassname = value; }
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
		/// OutNum
        /// </summary>		
		private decimal _outnum;
        public decimal OutNum
        {
            get{ return _outnum; }
            set{ _outnum = value; }
        }        
		/// <summary>
		/// Status
        /// </summary>		
		private string _status;
        public string Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// StoreId
        /// </summary>		
		private int _storeid;
        public int StoreId
        {
            get{ return _storeid; }
            set{ _storeid = value; }
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
		/// SerialNum
        /// </summary>		
		private string _serialnum;
        public string SerialNum
        {
            get{ return _serialnum; }
            set{ _serialnum = value; }
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
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }


   
	}
}