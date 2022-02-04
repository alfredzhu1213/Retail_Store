using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_MemberIntegralSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_MemberIntegralSet
	{
		public tb_MemberIntegralSet()
		{}
		#region Model
		private int _id;
		private decimal? _xfprice;
		private int? _ispayintegralenable=0;
		private decimal? _integral;
		private decimal? _diprice;
		private int? _isscorepayingnoscoring=0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 消费金额每 1元积1分（0表示不积分）
		/// </summary>
		public decimal? xfPrice
		{
			set{ _xfprice=value;}
			get{return _xfprice;}
		}
		/// <summary>
		/// 开启积分付款功能
		/// </summary>
		public int? IsPayIntegralEnable
		{
			set{ _ispayintegralenable=value;}
			get{return _ispayintegralenable;}
		}
		/// <summary>
		/// 每 100 分
		/// </summary>
		public decimal? Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 可抵用 10元
		/// </summary>
		public decimal? diPrice
		{
			set{ _diprice=value;}
			get{return _diprice;}
		}
		/// <summary>
		/// 积分付款的金额不再积分
		/// </summary>
		public int? IsScorePayingNoScoring
		{
			set{ _isscorepayingnoscoring=value;}
			get{return _isscorepayingnoscoring;}
		}
		#endregion Model

	}
}

