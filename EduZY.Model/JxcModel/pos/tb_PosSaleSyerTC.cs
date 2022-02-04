/**  版本信息模板在安装目录下，可自行修改。
* tb_PosSaleSyerTC.cs
*
* 功 能： N/A
* 类 名： tb_PosSaleSyerTC
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/23 20:06:44   N/A    初版
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
	/// tb_PosSaleSyerTC:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleSyerTC
	{
		public tb_PosSaleSyerTC()
		{}
		#region Model
		private Int64 _id;
		private int? _storeid;
		private string _storecode;
		private string _storename;
		private int? _yyerid;
		private string _yyercode;
		private string _yyername;
		private decimal? _saleaccount;
		private decimal? _tcaccount;
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
		/// 收银员ID
		/// </summary>
		public int? YYerID
		{
			set{ _yyerid=value;}
			get{return _yyerid;}
		}
		/// <summary>
		/// 收银员编码
		/// </summary>
		public string YYerCode
		{
			set{ _yyercode=value;}
			get{return _yyercode;}
		}
		/// <summary>
		/// 收银员名称
		/// </summary>
		public string YYerName
		{
			set{ _yyername=value;}
			get{return _yyername;}
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
		/// 提成金额
		/// </summary>
		public decimal? TCAccount
		{
			set{ _tcaccount=value;}
			get{return _tcaccount;}
		}
		#endregion Model

	}
}

