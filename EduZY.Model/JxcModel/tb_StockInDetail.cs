using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Maticsoft.Model
{
    /////////////////////tb_StockInDetail
    public class tb_StockInDetail
    {

        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// StockInId
        /// </summary>		
        private int _stockinid;
        public int StockInId
        {
            get { return _stockinid; }
            set { _stockinid = value; }
        }
        /// <summary>
        /// 产品名
        /// </summary>		
        private string _productname;
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// 货号
        /// </summary>		
        private string _hhno="0";
        public string HHNo
        {
            get { return _hhno; }
            set { _hhno = value; }
        }
        /// <summary>
        /// 规格
        /// </summary>		
        private string _gg;
        public string GG
        {
            get { return _gg; }
            set { _gg = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>		
        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        /// <summary>
        /// 箱数
        /// </summary>		
        private decimal? _boxnum;
        public decimal? BoxNum
        {
            get { return _boxnum; }
            set { _boxnum = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>		
        private decimal? _num;
        public decimal? Num
        {
            get { return _num; }
            set { _num = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>		
        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 说明
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime? _addtime;
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// ProductId
        /// </summary>		
        private int _productid;
        public int ProductId
        {
            get { return _productid; }
            set { _productid = value; }
        }

        public string JsonString { get; set; }
        public bool DeleteFlag { get; set; }
        public string SupName { get; set; }

        public string StoreName { get; set; }


        public decimal? SumPrice { get; set; }
    }
}