using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	/////////////////////tb_Stocktransfer
		public class tb_Stocktransfer
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
		/// ��ˮ��
        /// </summary>		
		private string _serialnum;
        public string SerialNum
        {
            get{ return _serialnum; }
            set{ _serialnum = value; }
        }        
		/// <summary>
		/// ��Ӧ��id
        /// </summary>		
		private int _supid;
        public int SupId
        {
            get{ return _supid; }
            set{ _supid = value; }
        }        
		/// <summary>
		/// ��Ӧ��
        /// </summary>		
		private string _supcode;
        public string SupCode
        {
            get{ return _supcode; }
            set{ _supcode = value; }
        }        
		/// <summary>
		/// �����ŵ�ID
        /// </summary>		
		private int _instoreid;
        public int InStoreId
        {
            get{ return _instoreid; }
            set{ _instoreid = value; }
        }        
		/// <summary>
		/// �����ŵ����
        /// </summary>		
		private string _instorecode;
        public string InStoreCode
        {
            get{ return _instorecode; }
            set{ _instorecode = value; }
        }        
		/// <summary>
		/// �����ŵ�ID
        /// </summary>		
		private int _outinstoreid;
        public int OutStoreId
        {
            get{ return _outinstoreid; }
            set{ _outinstoreid = value; }
        }        
		/// <summary>
		/// �����ŵ����
        /// </summary>		
		private string _outstorecode;
        public string OutStoreCode
        {
            get{ return _outstorecode; }
            set{ _outstorecode = value; }
        }        
		/// <summary>
		/// ��ע
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		/// <summary>
		/// ����״̬
        /// </summary>		
		private string _status;
        public string Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		/// <summary>
		/// �Ƶ���Ա
        /// </summary>		
		private string _createusername;
        public string CreateUserName
        {
            get{ return _createusername; }
            set{ _createusername = value; }
        }        
		/// <summary>
		/// �Ƶ�����
        /// </summary>		
		private DateTime? _createdate;
        public DateTime? CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// ���������
        /// </summary>		
		private string _apprusername;
        public string ApprUserName
        {
            get{ return _apprusername; }
            set{ _apprusername = value; }
        }        
		/// <summary>
		/// �����������
        /// </summary>		
		private DateTime? _apprdate;
        public DateTime? ApprDate
        {
            get{ return _apprdate; }
            set{ _apprdate = value; }
        }        
		/// <summary>
		/// ���������
        /// </summary>		
		private string _apprusernamein;
        public string ApprUserNameIn
        {
            get{ return _apprusernamein; }
            set{ _apprusernamein = value; }
        }        
		/// <summary>
		/// �����������
        /// </summary>		
		private DateTime? _apprdatein;
        public DateTime? ApprDateIn
        {
            get{ return _apprdatein; }
            set{ _apprdatein = value; }
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

        public string OutStoreName { get; set; }


        public string InStoreName { get; set; }
    }
}