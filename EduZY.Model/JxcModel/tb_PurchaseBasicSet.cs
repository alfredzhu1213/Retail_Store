using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseBasicSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PurchaseBasicSet
	{
		public tb_PurchaseBasicSet()
		{}
		#region Model
		private int _id;
		private int? _setstatus1=0;
		private int? _setstatus2=0;
		private int? _setstatus3=0;
		private int? _setstatus4=0;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 采购收货单审核生效时即时更新商品档案中的进价(0除外)
		/// </summary>
		public int? SetStatus1
		{
			set{ _setstatus1=value;}
			get{return _setstatus1;}
		}
		/// <summary>
		/// 收货单按数量与总价自动计算单价
		/// </summary>
		public int? SetStatus2
		{
			set{ _setstatus2=value;}
			get{return _setstatus2;}
		}
		/// <summary>
		/// 采购收货允许0进价商品入库
		/// </summary>
		public int? SetStatus3
		{
			set{ _setstatus3=value;}
			get{return _setstatus3;}
		}
		/// <summary>
		/// 允许采购单、出入库单据通过扫码建档(只对13位标准条码有效
		/// </summary>
		public int? SetStatus4
		{
			set{ _setstatus4=value;}
			get{return _setstatus4;}
		}
		#endregion Model

	}
}

