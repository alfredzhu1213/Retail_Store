/**  版本信息模板在安装目录下，可自行修改。
* tb_PosSaleGoodsTypeSummary.cs
*
* 功 能： N/A
* 类 名： tb_PosSaleGoodsTypeSummary
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
	/// tb_PosSaleGoodsTypeSummary:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleGoodsTypeSummary
	{
		public tb_PosSaleGoodsTypeSummary()
		{}
		#region Model
		private Int64 _id;
		private int? _storeid;
		private string _storecode;
		private string _storename;
		private int? _goodstypeid;
		private string _goodstypecode;
		private string _goodstypename;
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
		/// 商品类别ID
		/// </summary>
		public int? GoodsTypeID
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

