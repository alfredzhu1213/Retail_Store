using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_ProductBarCode:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_ProductBarCode
	{
		public tb_ProductBarCode()
		{}
		#region Model
		private int _id;
		private int _productid;
		private string _barcode;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string barcode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		#endregion Model

	}
}

