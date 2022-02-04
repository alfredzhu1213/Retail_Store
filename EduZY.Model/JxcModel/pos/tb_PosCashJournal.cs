/**  版本信息模板在安装目录下，可自行修改。
* tb_PosCashJournal.cs
*
* 功 能： N/A
* 类 名： tb_PosCashJournal
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
	/// tb_PosCashJournal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PosCashJournal
	{
		public tb_PosCashJournal()
		{}
		#region Model
		private Int64 _id;
		private string _billno;
		private string _tradetype;
		private decimal? _billaccount;
		private string _paymentcode;
		private string _paymentmode;
		private decimal? _paymentaccount;
		private string _paymentno;
		private string _memberno;
		private string _returnoriginalno;
		private int? _syerid;
		private string _syercode;
		private string _syername;
		private DateTime? _sydatetime;
		private string _remark;
        private string _StoreName;
        

        public string StoreName
		{
            set { _StoreName = value; }
            get { return _StoreName; }
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 票号
		/// </summary>
		public string BillNo
		{
			set{ _billno=value;}
			get{return _billno;}
		}
		/// <summary>
		/// 交易方式
		/// </summary>
		public string TradeType
		{
			set{ _tradetype=value;}
			get{return _tradetype;}
		}
		/// <summary>
		/// 单据金额
		/// </summary>
		public decimal? BillAccount
		{
			set{ _billaccount=value;}
			get{return _billaccount;}
		}
		/// <summary>
		/// 付款方式编码
		/// </summary>
		public string PaymentCode
		{
			set{ _paymentcode=value;}
			get{return _paymentcode;}
		}
		/// <summary>
		/// 付款方式
		/// </summary>
		public string PaymentMode
		{
			set{ _paymentmode=value;}
			get{return _paymentmode;}
		}
		/// <summary>
		/// 付款金额
		/// </summary>
		public decimal? PaymentAccount
		{
			set{ _paymentaccount=value;}
			get{return _paymentaccount;}
		}
		/// <summary>
		/// 付款卡凭证号
		/// </summary>
		public string PaymentNo
		{
			set{ _paymentno=value;}
			get{return _paymentno;}
		}
		/// <summary>
		/// 会员卡号
		/// </summary>
		public string MemberNo
		{
			set{ _memberno=value;}
			get{return _memberno;}
		}
		/// <summary>
		/// 退货原单号
		/// </summary>
		public string ReturnOriginalNo
		{
			set{ _returnoriginalno=value;}
			get{return _returnoriginalno;}
		}
		/// <summary>
		/// 收银员ID
		/// </summary>
		public int? SYerID
		{
			set{ _syerid=value;}
			get{return _syerid;}
		}
		/// <summary>
		/// 收银员编码
		/// </summary>
		public string SYerCode
		{
			set{ _syercode=value;}
			get{return _syercode;}
		}
		/// <summary>
		/// 收银员姓名
		/// </summary>
		public string SYerName
		{
			set{ _syername=value;}
			get{return _syername;}
		}
		/// <summary>
		/// 收银时间
		/// </summary>
		public DateTime? SYDateTime
		{
			set{ _sydatetime=value;}
			get{return _sydatetime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

