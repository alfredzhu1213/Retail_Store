using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosClient:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosClient
	{
		public tb_PosClient()
		{}
		#region Model
		private int _id;
        private string _guidid;
		private string _code;
		private string _name;
		private string _status;
		private string _remark;
		private int? _storeid;
		private int? _adduserid;
		private DateTime? _addtime;
		private int? _updateuserid;
		private DateTime? _updatetime;

        public string _AddUserName;
        public string _UpdateUserName;
        public string _StoreName;



        public string AddUserName
        {
            set { _AddUserName = value; }
            get { return _AddUserName; }
        }

        public string UpdateUserName
        {
            set { _UpdateUserName = value; }
            get { return _UpdateUserName; }
        }

        public string StoreName
        {
            set { _StoreName = value; }
            get { return _StoreName; }
        }
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 唯一码
		/// </summary>
		public string GuidID
		{
			set{ _guidid=value;}
			get{return _guidid;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public int? AddUserId
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// 登记时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public int? UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

