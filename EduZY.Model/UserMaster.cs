using System;
namespace EduJXC.Model
{
	/// <summary>
	/// UserMaster:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class UserMaster
	{
		public UserMaster()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private string _status="1";
		private string _roleid;
		private DateTime? _regstatedate;
		private string _sign="0";
		private DateTime? _lastdate;
		private DateTime? _dateupdated;
		private int? _genearchuserid=0;
		private int? _uid=0;
		private string _usersource;

        //用户详细信息
        private string _truename;
        private string _workunit;
        private DateTime? _birthday;
        private string _mobile;
        private string _phone;
        private string _email;
        private string _qq;
        private string _address;
        private string _picaddresss;
        private string _pictype = "0";
        private int? _bumenid;
        private string _zhicheng;

        private bool _sex = false;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}

        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegStateDate
		{
			set{ _regstatedate=value;}
			get{return _regstatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sign
		{
			set{ _sign=value;}
			get{return _sign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastDate
		{
			set{ _lastdate=value;}
			get{return _lastdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateUpdated
		{
			set{ _dateupdated=value;}
			get{return _dateupdated;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GenearchUserID
		{
			set{ _genearchuserid=value;}
			get{return _genearchuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserSource
		{
			set{ _usersource=value;}
			get{return _usersource;}
		}

        //用户详细信息
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkUnit
        {
            set { _workunit = value; }
            get { return _workunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BirthDay
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMail
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicAddresss
        {
            set { _picaddresss = value; }
            get { return _picaddresss; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PicType
        {
            set { _pictype = value; }
            get { return _pictype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BuMenId
        {
            set { _bumenid = value; }
            get { return _bumenid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZhiCheng
        {
            set { _zhicheng = value; }
            get { return _zhicheng; }
        }

        public bool IsDelete
        {
            set  ; 
            get ; 
        }
        public DateTime ActivationDate { get; set; }

        public int CreateUserID { get; set; }
		#endregion Model


        public string WorkUnitName { get; set; }



        public string RoleName { get; set; }

        public string DBName { get; set; }

        public string OldPassword { get; set; }

        public string Password1 { get; set; }

        public string Password2 { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public string StoreIdList { get; set; }

        public string StoreNameList { get; set; }
    }
}

