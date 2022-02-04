using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Maticsoft.Model
{
    //View_SelectPurchaseOrder
    public class View_SelectPurchaseOrder
    {

        /// <summary>
        /// SerialNum
        /// </summary>		
        private string _serialnum;
        public string SerialNum
        {
            get { return _serialnum; }
            set { _serialnum = value; }
        }
        /// <summary>
        /// StoreCode
        /// </summary>		
        private string _storecode;
        public string StoreCode
        {
            get { return _storecode; }
            set { _storecode = value; }
        }
        /// <summary>
        /// StoreName
        /// </summary>		
        private string _storename;
        public string StoreName
        {
            get { return _storename; }
            set { _storename = value; }
        }
        /// <summary>
        /// SupplierCode
        /// </summary>		
        private string _suppliercode;
        public string SupplierCode
        {
            get { return _suppliercode; }
            set { _suppliercode = value; }
        }
        /// <summary>
        /// SupplierName
        /// </summary>		
        private string _suppliername;
        public string SupplierName
        {
            get { return _suppliername; }
            set { _suppliername = value; }
        }
        /// <summary>
        /// StoreId
        /// </summary>		
        private int _storeid;
        public int StoreId
        {
            get { return _storeid; }
            set { _storeid = value; }
        }
        /// <summary>
        /// SupId
        /// </summary>		
        private int _supid;
        public int SupId
        {
            get { return _supid; }
            set { _supid = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// CreateUserName
        /// </summary>		
        private string _createusername;
        public string CreateUserName
        {
            get { return _createusername; }
            set { _createusername = value; }
        }
        /// <summary>
        /// ApprUserName
        /// </summary>		
        private string _apprusername;
        public string ApprUserName
        {
            get { return _apprusername; }
            set { _apprusername = value; }
        }
        /// <summary>
        /// ApprDate
        /// </summary>		
        private DateTime? _apprdate=null;
        public DateTime? ApprDate
        {
            get { return _apprdate; }
            set { _apprdate = value; }
        }
        /// <summary>
        /// CreateDate
        /// </summary>		
        private DateTime _createdate;
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// HandledUserName
        /// </summary>		
        private string _handledusername;
        public string HandledUserName
        {
            get { return _handledusername; }
            set { _handledusername = value; }
        }
        private Decimal? _SumPrice=0;
         public Decimal? SumPrice
        {
            get { return _SumPrice; }
            set { _SumPrice = value; }
        }


         private string _Outstorename;
         public string OutStoreName
         {
             get { return _Outstorename; }
             set { _Outstorename = value; }
         }

         private string _Instorename;
         public string InStoreName
         {
             get { return _Instorename; }
             set { _Instorename = value; }
         }
        
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _ApprUserNameIn;
        public string ApprUserNameIn
        {
            get { return _ApprUserNameIn; }
            set { _ApprUserNameIn = value; }
        }
        /// <summary>
        /// ApprDate
        /// </summary>		
        private DateTime? _ApprDateIn = null;
        public DateTime? ApprDateIn
        {
            get { return _ApprDateIn; }
            set { _ApprDateIn = value; }
        }

    }
}