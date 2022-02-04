using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosSaleMan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleMan
	{
		public tb_PosSaleMan()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _status;
		private string _remark;
		private int? _adduserid;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 营业员编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 营业员姓名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string status
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
		/// 添加用户
		/// </summary>
		public int? AddUserId
		{
			set{ _adduserid=value;}
			get{return _adduserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model


        public int? StoreId { get; set; }

        public string StoreName { get; set; }
    }
}

