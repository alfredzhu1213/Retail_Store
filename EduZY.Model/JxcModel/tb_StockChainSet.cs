using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_StockChainSet
		public class tb_StockChainSet
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
		/// 调拨单据需要收货方审核（连锁设置）
        /// </summary>		
		private int _isenable;
        public int IsEnable
        {
            get{ return _isenable; }
            set{ _isenable = value; }
        }        
				
	    public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

        public string StoreName { get; set; }
   
	}
}