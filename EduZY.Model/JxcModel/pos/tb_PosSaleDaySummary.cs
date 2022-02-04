/**  版本信息模板在安装目录下，可自行修改。
* tb_PosSaleDaySummary.cs
*
* 功 能： N/A
* 类 名： tb_PosSaleDaySummary
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/23 20:06:42   N/A    初版
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
	/// tb_PosSaleDaySummary:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleDaySummary
	{
		public tb_PosSaleDaySummary()
		{}
		#region Model
		private Int64 _id;
		private int? _storeid;
		private string _storecode;
		private string _storename;
		private string _s_datetime;
		private string _hhno;
		private int? _goodsid;
		private string _goodscode;
		private string _goodsname;
		private string _gg;
		private string _unit;
		private int? _salecount;
		private decimal? _saleaccount;
		private int? _returncount;
		private decimal? _returnaccount;
		private int? _countsubtotal;
		private decimal? _accountsubtotal;
		/// <summary>
		/// 
		/// </summary>
        public Int64 id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 门店ID
		/// </summary>
		public int? StoreID
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 门店编码
		/// </summary>
		public string StoreCode
		{
			set{ _storecode=value;}
			get{return _storecode;}
		}
		/// <summary>
		/// 门店名称
		/// </summary>
		public string StoreName
		{
			set{ _storename=value;}
			get{return _storename;}
		}
		/// <summary>
		/// 日期
		/// </summary>
        public string S_DateTime
		{
			set{ _s_datetime=value;}
			get{return _s_datetime;}
		}
		/// <summary>
		/// 货号
		/// </summary>
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
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
		/// 单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 销售数量
		/// </summary>
		public int? SaleCount
		{
			set{ _salecount=value;}
			get{return _salecount;}
		}
		/// <summary>
		/// 销售金额
		/// </summary>
		public decimal? SaleAccount
		{
			set{ _saleaccount=value;}
			get{return _saleaccount;}
		}
		/// <summary>
		/// 退货数量
		/// </summary>
		public int? ReturnCount
		{
			set{ _returncount=value;}
			get{return _returncount;}
		}
		/// <summary>
		/// 退货金额
		/// </summary>
		public decimal? ReturnAccount
		{
			set{ _returnaccount=value;}
			get{return _returnaccount;}
		}
		/// <summary>
		/// 数量小计
		/// </summary>
		public int? CountSubtotal
		{
			set{ _countsubtotal=value;}
			get{return _countsubtotal;}
		}
		/// <summary>
		/// 金额小计
		/// </summary>
		public decimal? AccountSubtotal
		{
			set{ _accountsubtotal=value;}
			get{return _accountsubtotal;}
		}
		#endregion Model

	}
}

