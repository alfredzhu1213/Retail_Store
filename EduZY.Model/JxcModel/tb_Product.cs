using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Product:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		private string _productstatus="����";
        private string _producttype = "��ͨ";
        private string _jjway = "��ͨ";
		private string _remark;

        private string _TJWay = "�����";
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
		/// ��Ʒ��
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// ͼƬ
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string HHNo
		{
			set{ _hhno=value;}
			get{return _hhno;}
		}
		/// <summary>
		/// ���
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
		/// ��λ
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		///  ��ʼ���
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
		/// ������
		/// </summary>
		public decimal? jinPrice
		{
			set{ _jinprice=value;}
			get{return _jinprice;}
		}
		/// <summary>
		/// ���ۼ�
		/// </summary>
		public decimal SalesPrice
		{
			set{ _salesprice=value;}
			get{return _salesprice;}
		}
		/// <summary>
		/// ����ۼ�
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
		/// ����ļ��ۿ�
		/// </summary>
		public int? IsAllowChange
		{
			set{ _isallowchange=value;}
			get{return _isallowchange;}
		}
		/// <summary>
		/// ���Id
		/// </summary>
		public int? ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string ClassCode
		{
			set{ _classcode=value;}
			get{return _classcode;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public string ProductSingeName
		{
			set{ _productsingename=value;}
			get{return _productsingename;}
		}
		/// <summary>
		/// ��Ʒ������
		/// </summary>
		public string ProductJJ
		{
			set{ _productjj=value;}
			get{return _productjj;}
		}
		/// <summary>
		/// Ʒ�Ʊ���
		/// </summary>
		public string BrandCode
		{
			set{ _brandcode=value;}
			get{return _brandcode;}
		}
		/// <summary>
		/// Ʒ��Id
		/// </summary>
		public int? BrandId
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// ��Ӧ�̱���
		/// </summary>
		public string SupCode
		{
			set{ _supcode=value;}
			get{return _supcode;}
		}
		/// <summary>
		/// ��Ӧ��ID
		/// </summary>
		public int? SupId
		{
			set{ _supid=value;}
			get{return _supid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public decimal JinGG
		{
			set{ _jingg=value;}
			get{return _jingg;}
		}
		/// <summary>
		/// ��Ʒ״̬
		/// </summary>
		public string ProductStatus
		{
			set{ _productstatus=value;}
			get{return _productstatus;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}
		/// <summary>
		/// �Ƽ۷�ʽ
		/// </summary>
		public string JJWay
		{
			set{ _jjway=value;}
			get{return _jjway;}
		}
		/// <summary>
		/// ˵��
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

