using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseOrderAcceptDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PurchaseOrderAcceptDetail
	{
		public tb_PurchaseOrderAcceptDetail()
		{}
		#region Model
		private int _id;
		private int? _poid;
		private string _productname;
		private string _hhno;
		private string _gg;
		private string _unit;
        private decimal? _boxnum=0;
        private decimal? _num = 0;
        private decimal? _sendnum = 0;
        private decimal? _price = 0;
		private string _remark;
		private DateTime? _addtime= DateTime.Now;
		private int? _productid;
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
		public int? POId
		{
			set{ _poid=value;}
			get{return _poid;}
		}
		/// <summary>
		/// 产品名
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
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
		/// 箱量
		/// </summary>
        public decimal? BoxNum
		{
			set{ _boxnum=value;}
			get{return _boxnum;}
		}
		/// <summary>
		/// 数量
		/// </summary>
        public decimal? Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 赠送数量
		/// </summary>
		public decimal? SendNum
		{
			set{ _sendnum=value;}
			get{return _sendnum;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		#endregion Model


        public decimal? SumPrice { get; set; }
        public bool DeleteFlag { get; set; }
        
    }
}

