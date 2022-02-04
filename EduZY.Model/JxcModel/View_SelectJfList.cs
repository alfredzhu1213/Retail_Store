using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// View_SelectJfList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_SelectJfList
	{
		public View_SelectJfList()
		{}
		#region Model
		private string _code;
		private string _cardcode;
		private string _membertypename;
		private int? _membertypeid;
		private int? _score;
		private int? _shenscore;
		private string _biao;
		private string _type;
		private int? _orderid;
		private string _remark;
		private DateTime? _addtime;
		private int? _userid;
		private int _goldid;
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemberTypeName
		{
			set{ _membertypename=value;}
			get{return _membertypename;}
		}
        public string StoreName
		{
            set;
            get;
		}
        public string TrueName
        {
            set;
            get;
        }
        
		/// <summary>
		/// 
		/// </summary>
		public int? MemberTypeId
		{
			set{ _membertypeid=value;}
			get{return _membertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? shenScore
		{
			set{ _shenscore=value;}
			get{return _shenscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string biao
		{
			set{ _biao=value;}
			get{return _biao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GoldId
		{
			set{ _goldid=value;}
			get{return _goldid;}
		}
		#endregion Model

	}
}

