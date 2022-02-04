using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tb_PosSaleSyerTCDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_PosSaleSyerTCDetail
    {
        public tb_PosSaleSyerTCDetail()
        { }
        #region Model
        private Int64 _id;
        private int? _storeid;
        private string _storecode;
        private string _storename;
        private int? _yyerid;
        private string _yyercode;
        private string _yyername;
        private string _billno;
        private DateTime? _saledatetime;
        private string _hhno;
        private int? _goodsid;
        private string _goodscode;
        private string _goodsname;
        private string _gg;
        private string _tradetype;
        private decimal? _saleaccount;
        private decimal? _tcaccount;
        private int? _goodstypeid;
        private string _goodstypecode;
        private string _goodstypename;
        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 门店编号
        /// </summary>
        public int? StoreID
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 门店编码
        /// </summary>
        public string StoreCode
        {
            set { _storecode = value; }
            get { return _storecode; }
        }
        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName
        {
            set { _storename = value; }
            get { return _storename; }
        }
        /// <summary>
        /// 营业员ID
        /// </summary>
        public int? YYerID
        {
            set { _yyerid = value; }
            get { return _yyerid; }
        }
        /// <summary>
        /// 营业员编码
        /// </summary>
        public string YYerCode
        {
            set { _yyercode = value; }
            get { return _yyercode; }
        }
        /// <summary>
        /// 营业员姓名
        /// </summary>
        public string YYerName
        {
            set { _yyername = value; }
            get { return _yyername; }
        }
        /// <summary>
        /// 票号
        /// </summary>
        public string BillNo
        {
            set { _billno = value; }
            get { return _billno; }
        }
        /// <summary>
        /// 销售时间
        /// </summary>
        public DateTime? SaleDateTime
        {
            set { _saledatetime = value; }
            get { return _saledatetime; }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string HHNo
        {
            set { _hhno = value; }
            get { return _hhno; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int? GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsCode
        {
            set { _goodscode = value; }
            get { return _goodscode; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string GG
        {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 交易方式
        /// </summary>
        public string TradeType
        {
            set { _tradetype = value; }
            get { return _tradetype; }
        }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal? SaleAccount
        {
            set { _saleaccount = value; }
            get { return _saleaccount; }
        }
        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal? TCAccount
        {
            set { _tcaccount = value; }
            get { return _tcaccount; }
        }
        /// <summary>
        /// 商品类别ID
        /// </summary>
        public int? GoodsTypeId
        {
            set { _goodstypeid = value; }
            get { return _goodstypeid; }
        }
        /// <summary>
        /// 商品类别编码
        /// </summary>
        public string GoodsTypeCode
        {
            set { _goodstypecode = value; }
            get { return _goodstypecode; }
        }
        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string GoodsTypeName
        {
            set { _goodstypename = value; }
            get { return _goodstypename; }
        }
        #endregion Model

    }
}

