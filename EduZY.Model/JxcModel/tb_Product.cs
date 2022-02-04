using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Product
	{
		public tb_Product()
		{}
		#region Model
		private int _id;
		private string _productname;
		private string _imgurl;
		private string _hhno;
		private string _gg;
		private string _other;
		private string _unit;
        private decimal? _stocknum = 0;
		private decimal? _memberprice=0;
        private decimal? _jinprice = 0;
        private decimal _salesprice = 0;
        private decimal _minprice = 0;
		private int? _isallowchange=0;
        private decimal? _TJPrice = 0;
        private decimal? _SumPrice = 0;
        
		private int? _classid;
		private string _classcode;
		private string _productsingename;
		private string _productjj;
		private string _brandcode;
		private int? _brandid;
		private string _supcode;
		private int? _supid;
		private decimal _jingg=1M;
		private string _productstatus="正常";
        private string _producttype = "普通";
        private string _jjway = "普通";
		private string _remark;

        private string _TJWay = "不提成";
        public string TJWay
        {
            set { _TJWay = value; }
            get { return _TJWay; }
        }

        private int? _Count = 0;

        public int? Count
        {
            set { _Count = value; }
            get { return _Count; }
        }

		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 图片
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
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
		/// 
		/// </summary>
		public string other
		{
			set{ _other=value;}
			get{return _other;}
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
		///  初始库存
		/// </summary>
        public decimal? StockNum
		{
			set{ _stocknum=value;}
			get{return _stocknum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
		}

        public decimal? SumPrice
        {
            set { _SumPrice = value; }
            get { return _SumPrice; }
        }
		/// <summary>
		/// 进货价
		/// </summary>
		public decimal? jinPrice
		{
			set{ _jinprice=value;}
			get{return _jinprice;}
		}
		/// <summary>
		/// 零售价
		/// </summary>
		public decimal SalesPrice
		{
			set{ _salesprice=value;}
			get{return _salesprice;}
		}
		/// <summary>
		/// 最低售价
		/// </summary>
		public decimal MinPrice
		{
			set{ _minprice=value;}
			get{return _minprice;}
		}

        public decimal? TJPrice
        {
            set { _TJPrice = value; }
            get { return _TJPrice; }
        }


		/// <summary>
		/// 允许改价折扣
		/// </summary>
		public int? IsAllowChange
		{
			set{ _isallowchange=value;}
			get{return _isallowchange;}
		}
		/// <summary>
		/// 类别Id
		/// </summary>
		public int? ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 类别编码
		/// </summary>
		public string ClassCode
		{
			set{ _classcode=value;}
			get{return _classcode;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string ProductSingeName
		{
			set{ _productsingename=value;}
			get{return _productsingename;}
		}
		/// <summary>
		/// 产品助记码
		/// </summary>
		public string ProductJJ
		{
			set{ _productjj=value;}
			get{return _productjj;}
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
		/// 品牌Id
		/// </summary>
		public int? BrandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 供应商编码
		/// </summary>
		public string SupCode
		{
			set{ _supcode=value;}
			get{return _supcode;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int? SupId
		{
			set{ _supid=value;}
			get{return _supid;}
		}
		/// <summary>
		/// 进货规格
		/// </summary>
		public decimal JinGG
		{
			set{ _jingg=value;}
			get{return _jingg;}
		}
		/// <summary>
		/// 商品状态
		/// </summary>
		public string ProductStatus
		{
			set{ _productstatus=value;}
			get{return _productstatus;}
		}
		/// <summary>
		/// 商品类型
		/// </summary>
		public string ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}
		/// <summary>
		/// 计价方式
		/// </summary>
		public string JJWay
		{
			set{ _jjway=value;}
			get{return _jjway;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model


        public string ClassName { get; set; }

        public string BrandName { get; set; }

        public string SupName { get; set; }




        public string IsAllowChangeName { get; set; }
        public string unitlist { get; set; }

        public string barcodelist { get; set; }

        public string goodscode { get; set; }

        public Decimal? Num { get; set; }

        public Decimal? TCPrice { get; set; }
    }
}

