

using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Member:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_Member
	{
		public tb_Member()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _cardcode;
		private string _pwd;
		private decimal? _amount=0M;
		private decimal? _xfamount=0M;
		private int? _xfsum=0;
		private int? _sumintegral=0;
		private int? _keyongintegral=0;
		private int? _usedintegral=0;
		private string _truename;
		private int? _membertypeid;
		private string _membertypename;
		private string _sex;
		private string _mobile;
		private string _birthdate;
		private string _email;
		private string _status;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ա��
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string CardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// ��ֵ���
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// ���ѽ��
		/// </summary>
		public decimal? XfAmount
		{
			set{ _xfamount=value;}
			get{return _xfamount;}
		}
		/// <summary>
		/// ���Ѵ���
		/// </summary>
		public int? XfSum
		{
			set{ _xfsum=value;}
			get{return _xfsum;}
		}
		/// <summary>
		/// �ۼƻ���
		/// </summary>
		public int? SumIntegral
		{
			set{ _sumintegral=value;}
			get{return _sumintegral;}
		}
		/// <summary>
		/// ���û���
		/// </summary>
		public int? keYongIntegral
		{
			set{ _keyongintegral=value;}
			get{return _keyongintegral;}
		}
		/// <summary>
		/// ��ʹ�û���
		/// </summary>
		public int? UsedIntegral
		{
			set{ _usedintegral=value;}
			get{return _usedintegral;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// ��Ա���ID
		/// </summary>
		public int? MemberTypeId
		{
			set{ _membertypeid=value;}
			get{return _membertypeid;}
		}
		/// <summary>
		/// ��Ա���
		/// </summary>
		public string MemberTypeName
		{
			set{ _membertypename=value;}
			get{return _membertypename;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// �ֻ�����
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        public int Result { get; set; }
		#endregion Model

	}
}

