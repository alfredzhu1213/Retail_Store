using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// View_SelectStockReport_StockRptStmCost_GroupBy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_SelectStockReport_StockRptStmCost_GroupBy
	{
		public View_SelectStockReport_StockRptStmCost_GroupBy()
		{}
		#region Model
		private string _storename;
		private string _productname;
		private string _hhno;
		private string _gg;
		private string _unit;
		private decimal _jinprice;
		private string _suppliername;
		private string _brandname;
		private string _productclassname;
		private decimal? _num;
		/// <summary>
		/// 
		/// </summary>
		public string StoreName
		{
			set{ _storename=value;}
			get{return _storename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GG
		{
			set{ _gg=value;}
			get{return _gg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal jinPrice
		{
			set{ _jinprice=value;}
			get{return _jinprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BrandName
		{
			set{ _brandname=value;}
			get{return _brandname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductClassName
		{
			set{ _productclassname=value;}
			get{return _productclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Num
		{
			set{ _num=value;}
			get{return _num;}
		}

        public decimal? SumPrice
        {
            set;
            get;
        }
		#endregion Model

	}
}

