

using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Member:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Member
	{
		public tb_Member()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _cardcode;
		private string _pwd;
		private decimal? _amount=0M;
		private decimal? _xfamount=0M;
		private int? _xfsum=0;
		private int? _sumintegral=0;
		private int? _keyongintegral=0;
		private int? _usedintegral=0;
		private string _truename;
		private int? _membertypeid;
		private string _membertypename;
		private string _sex;
		private string _mobile;
		private string _birthdate;
		private string _email;
		private string _status;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 会员号
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 会员卡号
		/// </summary>
		public string CardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 储值金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 消费金额
		/// </summary>
		public decimal? XfAmount
		{
			set{ _xfamount=value;}
			get{return _xfamount;}
		}
		/// <summary>
		/// 消费次数
		/// </summary>
		public int? XfSum
		{
			set{ _xfsum=value;}
			get{return _xfsum;}
		}
		/// <summary>
		/// 累计积分
		/// </summary>
		public int? SumIntegral
		{
			set{ _sumintegral=value;}
			get{return _sumintegral;}
		}
		/// <summary>
		/// 可用积分
		/// </summary>
		public int? keYongIntegral
		{
			set{ _keyongintegral=value;}
			get{return _keyongintegral;}
		}
		/// <summary>
		/// 已使用积分
		/// </summary>
		public int? UsedIntegral
		{
			set{ _usedintegral=value;}
			get{return _usedintegral;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 会员类别ID
		/// </summary>
		public int? MemberTypeId
		{
			set{ _membertypeid=value;}
			get{return _membertypeid;}
		}
		/// <summary>
		/// 会员类别
		/// </summary>
		public string MemberTypeName
		{
			set{ _membertypename=value;}
			get{return _membertypename;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public string BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        public int Result { get; set; }
		#endregion Model

	}
}

