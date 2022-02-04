using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_StockCheck
		public class tb_StockCheck
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
		/// 流水号
        /// </summary>		
		private string _serialnum;
        public string SerialNum
        {
            get{ return _serialnum; }
            set{ _serialnum = value; }
        }        
		/// <summary>
		/// 门店ID
        /// </summary>		
		private int _storeid;
        public int StoreId
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
		/// 备注
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// 单据状态
        /// </summary>		
		private string _status;
        public string Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// 制单人员
        /// </summary>		
		private string _createusername;
        public string CreateUserName
        {
            get{ return _createusername; }
            set{ _createusername = value; }
        }        
		/// <summary>
		/// 制单日期
        /// </summary>		
		private DateTime? _createdate;
        public DateTime? CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// 审核人
        /// </summary>		
		private string _apprusername;
        public string ApprUserName
        {
            get{ return _apprusername; }
            set{ _apprusername = value; }
        }        
		/// <summary>
		/// 审核日期
        /// </summary>		
		private DateTime? _apprdate;
        public DateTime? ApprDate
        {
            get{ return _apprdate; }
            set{ _apprdate = value; }
        }        
		/// <summary>
		/// HandledUserName
        /// </summary>		
		private string _handledusername;
        public string HandledUserName
        {
            get{ return _handledusername; }
            set{ _handledusername = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

        public string StoreName { get; set; }
   
	}
}