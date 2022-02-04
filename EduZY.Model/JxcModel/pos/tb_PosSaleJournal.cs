/**  版本信息模板在安装目录下，可自行修改。
* tb_PosSaleJournal.cs
*
* 功 能： N/A
* 类 名： tb_PosSaleJournal
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/23 20:06:43   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosSaleJournal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleJournal
	{
		public tb_PosSaleJournal()
		{}
		#region Model
		private int _id;
		private string _billno;
		private DateTime? _saledatetime;
		private string _hhno;
		private int? _goodsid;
		private string _goodscode;
		private string _goodsname;
		private string _gg;
		private string _tradetype;
		private int? _count;
		private decimal? _primeprice;
		private decimal? _price;
		private decimal? _subtotal;
		private int? _yyerid;
		private string _yyercode;
		private string _yyername;
		private int? _syerid;
		private string _syercode;
		private string _syername;
		private int? _goodstypeid;
		private string _goodstypecode;
		private string _goodstypename;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 票号
		/// </summary>
		public string BillNo
		{
			set{ _billno=value;}
			get{return _billno;}
		}
		/// <summary>
		/// 销售时间
		/// </summary>
		public DateTime? SaleDateTime
		{
			set{ _saledatetime=value;}
			get{return _saledatetime;}
		}
		/// <summary>
		/// 货号
		/// </summary>
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
        private string _PosCode;
        public string PosCode
		{
            set { _PosCode = value; }
            get { return _PosCode; }
		}

        private string _StoreName;
        public string StoreName
		{
            set { _StoreName = value; }
            get { return _StoreName; }
		}
        
        
		/// <summary>
		/// 商品id
		/// </summary>
		public int? GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 商品编码
		/// </summary>
		public string GoodsCode
		{
			set{ _goodscode=value;}
			get{return _goodscode;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string GoodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string GG
		{
			set{ _gg=value;}
			get{return _gg;}
		}
		/// <summary>
		/// 交易方式
		/// </summary>
		public string TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// 销售数量
		/// </summary>
		public int? Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 原价
		/// </summary>
		public decimal? PrimePrice
		{
			set{ _primeprice=value;}
			get{return _primeprice;}
		}
		/// <summary>
		/// 售价
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 小计金额
		/// </summary>
		public decimal? Subtotal
		{
			set{ _subtotal=value;}
			get{return _subtotal;}
		}
		/// <summary>
		/// 营业员ID
		/// </summary>
		public int? YYerID
		{
			set{ _yyerid=value;}
			get{return _yyerid;}
		}
		/// <summary>
		/// 营业员编码
		/// </summary>
		public string YYerCode
		{
			set{ _yyercode=value;}
			get{return _yyercode;}
		}
		/// <summary>
		/// 营业员姓名
		/// </summary>
		public string YYerName
		{
			set{ _yyername=value;}
			get{return _yyername;}
		}
		/// <summary>
		/// 收银员ID
		/// </summary>
		public int? SYerID
		{
			set{ _syerid=value;}
			get{return _syerid;}
		}
		/// <summary>
		/// 收银员编码
		/// </summary>
		public string SYerCode
		{
			set{ _syercode=value;}
			get{return _syercode;}
		}
		/// <summary>
		/// 收银员姓名
		/// </summary>
		public string SYerName
		{
			set{ _syername=value;}
			get{return _syername;}
		}

        public string PayType
        {
            set;
            get;
        }

		/// <summary>
		/// 商品类别ID
		/// </summary>
		public int? GoodsTypeId
		{
			set{ _goodstypeid=value;}
			get{return _goodstypeid;}
		}
		/// <summary>
		/// 商品类别编码
		/// </summary>
		public string GoodsTypeCode
		{
			set{ _goodstypecode=value;}
			get{return _goodstypecode;}
		}
		/// <summary>
		/// 商品类别名称
		/// </summary>
		public string GoodsTypeName
		{
			set{ _goodstypename=value;}
			get{return _goodstypename;}
		}
		#endregion Model

	}
}

