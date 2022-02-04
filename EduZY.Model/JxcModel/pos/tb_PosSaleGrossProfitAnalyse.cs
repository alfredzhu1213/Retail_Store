/**  版本信息模板在安装目录下，可自行修改。
* tb_PosSaleGrossProfitAnalyse.cs
*
* 功 能： N/A
* 类 名： tb_PosSaleGrossProfitAnalyse
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
	/// tb_PosSaleGrossProfitAnalyse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleGrossProfitAnalyse
	{
		public tb_PosSaleGrossProfitAnalyse()
		{}
		#region Model
		private int _id;
		private int? _storeid;
		private string _storecode;
		private string _storename;
		private string _hhno;
		private int? _goodsid;
		private string _goodscode;
		private string _goodsname;
		private string _gg;
		private string _unit;
		private int? _salecount;
		private decimal? _saleprice;
		private decimal? _saleaccount;
		private decimal? _grossprofit;
        private decimal?     _grossprofitrate;
		private decimal? _costprice;
		private decimal? _salecostprice;
		private int? _goodstypeid;
		private string _goodstypecode;
		private string _goodstypename;
		private int? _brandid;
		private string _brandcode;
		private string _brandname;
		private int? _supplierid;
		private string _suppliercode;
		private string _suppliername;
		/// <summary>
		/// 
		/// </summary>
		public int id
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
		/// 货号
		/// </summary>
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
		/// <summary>
		/// 商品ID
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
		/// 销售单价
		/// </summary>
		public decimal? SalePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
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
		/// 毛利
		/// </summary>
		public decimal? GrossProfit
		{
			set{ _grossprofit=value;}
			get{return _grossprofit;}
		}
        
		/// <summary>
		/// 毛利率
		/// </summary>
        public decimal? GrossProfitRate
		{
          
			set{ _grossprofitrate=value;}
			get{return _grossprofitrate;}
		}
		/// <summary>
		/// 成本单价
		/// </summary>
		public decimal? CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 成本金额价
		/// </summary>
		public decimal? SaleCostPrice
		{
			set{ _salecostprice=value;}
			get{return _salecostprice;}
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
		/// <summary>
		/// 品牌ID
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 品牌编码
		/// </summary>
		public string BrandCode
		{
			set{ _brandcode=value;}
			get{return _brandcode;}
		}
		/// <summary>
		/// 品牌名称
		/// </summary>
		public string BrandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 供应商编码
		/// </summary>
		public string SupplierCode
		{
			set{ _suppliercode=value;}
			get{return _suppliercode;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		#endregion Model

	}
}

