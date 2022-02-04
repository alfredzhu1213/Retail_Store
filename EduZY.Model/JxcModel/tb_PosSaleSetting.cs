using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosSaleSetting:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleSetting
	{
		public tb_PosSaleSetting()
		{}
		#region Model
		private int _id;
		private int? _isautofreshnogroup=0;
		private int? _isautobarcode=0;
		private int? _isdefineitemno=0;
		private int? _isautopricecreate=0;
		private int? _smallchangeround=1;
		private int? _isprintitemshortname=0;
		private int? _isprintsumdiscount=0;
		private string _billprinttitle;
		private string _billprintbranch;
		private string _billprintfooter1;
		private string _billprintfooter2;
		private string _billprintfooter3;
		private string _billprintfooter4;
		private string _billprintfooter5;
		private string _billprintfooter6;
		private string _billprintfooter7;
		private string _billprintfooter8;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 开启电子秤码无档销售
		/// </summary>
		public int? IsAutoFreshNoGroup
		{
			set{ _isautofreshnogroup=value;}
			get{return _isautofreshnogroup;}
		}
		/// <summary>
		/// 开启国标条码无档销售
		/// </summary>
		public int? IsAutoBarcode
		{
			set{ _isautobarcode=value;}
			get{return _isautobarcode;}
		}
		/// <summary>
		/// 开启自编码无档销售
		/// </summary>
		public int? IsDefineItemNo
		{
			set{ _isdefineitemno=value;}
			get{return _isdefineitemno;}
		}
		/// <summary>
		/// 开启输入价格销售
		/// </summary>
		public int? IsAutoPriceCreate
		{
			set{ _isautopricecreate=value;}
			get{return _isautopricecreate;}
		}
		/// <summary>
		/// 1实款实收(默认)2抹掉角以下的金额3抹掉元以下的金额4元以下的金额四舍五入5角以下的金额四舍五入
		/// </summary>
		public int? SmallChangeRound
		{
			set{ _smallchangeround=value;}
			get{return _smallchangeround;}
		}
		/// <summary>
		/// 打印小票是否使用商品简称
		/// </summary>
		public int? IsPrintItemShortName
		{
			set{ _isprintitemshortname=value;}
			get{return _isprintitemshortname;}
		}
		/// <summary>
		/// 是否打印优惠合计
		/// </summary>
		public int? IsPrintSumDiscount
		{
			set{ _isprintsumdiscount=value;}
			get{return _isprintsumdiscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BillPrintTitle
		{
			set{ _billprinttitle=value;}
			get{return _billprinttitle;}
		}
		/// <summary>
		/// 小票打印门店信息
		/// </summary>
		public string BillPrintBranch
		{
			set{ _billprintbranch=value;}
			get{return _billprintbranch;}
		}
		/// <summary>
		/// 小票打印票尾信息一
		/// </summary>
		public string BillPrintFooter1
		{
			set{ _billprintfooter1=value;}
			get{return _billprintfooter1;}
		}
		/// <summary>
		/// 小票打印票尾信息二
		/// </summary>
		public string BillPrintFooter2
		{
			set{ _billprintfooter2=value;}
			get{return _billprintfooter2;}
		}
		/// <summary>
		/// 小票打印票尾信息三
		/// </summary>
		public string BillPrintFooter3
		{
			set{ _billprintfooter3=value;}
			get{return _billprintfooter3;}
		}
		/// <summary>
		/// 小票打印票尾信息四
		/// </summary>
		public string BillPrintFooter4
		{
			set{ _billprintfooter4=value;}
			get{return _billprintfooter4;}
		}
		/// <summary>
		/// 小票打印票尾信息五
		/// </summary>
		public string BillPrintFooter5
		{
			set{ _billprintfooter5=value;}
			get{return _billprintfooter5;}
		}
		/// <summary>
		/// 小票打印票尾信息六
		/// </summary>
		public string BillPrintFooter6
		{
			set{ _billprintfooter6=value;}
			get{return _billprintfooter6;}
		}
		/// <summary>
		/// 小票打印票尾信息七
		/// </summary>
		public string BillPrintFooter7
		{
			set{ _billprintfooter7=value;}
			get{return _billprintfooter7;}
		}
		/// <summary>
		/// 小票打印票尾信息八
		/// </summary>
		public string BillPrintFooter8
		{
			set{ _billprintfooter8=value;}
			get{return _billprintfooter8;}
		}
		#endregion Model

	}
}

