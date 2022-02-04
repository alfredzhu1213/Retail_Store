using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tb_PromotionPlanSheetDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_PromotionPlanSheetDetail
    {
        public tb_PromotionPlanSheetDetail()
        { }
        #region Model
        private int _id;
        private int _ppsdid;
        private string _hhno;
        private string _productname;
        private decimal _oldprice;
        private decimal _memberprice;
        private decimal _jingg;
        private decimal? _tjprice;
        private decimal? _zk = 0M;
        private DateTime? _addtime = DateTime.Now;
        private int? _productid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 促销ID
        /// </summary>
        public int ppsdId
        {
            set { _ppsdid = value; }
            get { return _ppsdid; }
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
        /// 产品名
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal OldPrice
        {
            set { _oldprice = value; }
            get { return _oldprice; }
        }
        /// <summary>
        /// 会员价
        /// </summary>
        public decimal MemberPrice
        {
            set { _memberprice = value; }
            get { return _memberprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal JinGG
        {
            set { _jingg = value; }
            get { return _jingg; }
        }
        /// <summary>
        /// 特价
        /// </summary>
        public decimal? tjPrice
        {
            set { _tjprice = value; }
            get { return _tjprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ZK
        {
            set { _zk = value; }
            get { return _zk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        #endregion Model


        public bool DeleteFlag { get; set; }
    }
}

