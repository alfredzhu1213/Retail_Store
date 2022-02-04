using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseSupplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_PurchaseSupplier
	{
		public tb_PurchaseSupplier()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _helpcode;
		private string _linkname;
		private string _tel;
		private string _address;
		private string _status;
		private string _remark;
		private DateTime? _addtime= DateTime.Now;
		private DateTime? _updatetime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 助记码
		/// </summary>
		public string HelpCode
		{
			set{ _helpcode=value;}
			get{return _helpcode;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
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
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

