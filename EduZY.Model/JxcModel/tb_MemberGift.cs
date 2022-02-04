using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_MemberGift:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_MemberGift
	{
		public tb_MemberGift()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _code;
		private string _name;
		private decimal _num;
		private int _integralnum;
		private string _startdate;
		private string _enddate;
		private string _createusername;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 礼品编码
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 礼品名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 兑换数量
		/// </summary>
		public decimal Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 需要积分
		/// </summary>
		public int IntegralNum
		{
			set{ _integralnum=value;}
			get{return _integralnum;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public string StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public string EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

