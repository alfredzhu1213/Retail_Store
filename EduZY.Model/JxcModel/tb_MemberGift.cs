using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_MemberGift:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_MemberGift
	{
		public tb_MemberGift()
		{}
		#region Model
		private int _id;
		private int? _productid;
		private string _code;
		private string _name;
		private decimal _num;
		private int _integralnum;
		private string _startdate;
		private string _enddate;
		private string _createusername;
		private DateTime? _createdate;
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
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// ��Ʒ��
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// �һ�����
		/// </summary>
		public decimal Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// ��Ҫ����
		/// </summary>
		public int IntegralNum
		{
			set{ _integralnum=value;}
			get{return _integralnum;}
		}
		/// <summary>
		/// ��ʼ����
		/// </summary>
		public string StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

