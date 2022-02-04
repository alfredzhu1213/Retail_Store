using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PosSaleSetting:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_PosSaleSetting
	{
		public tb_PosSaleSetting()
		{}
		#region Model
		private int _id;
		private int? _isautofreshnogroup=0;
		private int? _isautobarcode=0;
		private int? _isdefineitemno=0;
		private int? _isautopricecreate=0;
		private int? _smallchangeround=1;
		private int? _isprintitemshortname=0;
		private int? _isprintsumdiscount=0;
		private string _billprinttitle;
		private string _billprintbranch;
		private string _billprintfooter1;
		private string _billprintfooter2;
		private string _billprintfooter3;
		private string _billprintfooter4;
		private string _billprintfooter5;
		private string _billprintfooter6;
		private string _billprintfooter7;
		private string _billprintfooter8;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �������ӳ����޵�����
		/// </summary>
		public int? IsAutoFreshNoGroup
		{
			set{ _isautofreshnogroup=value;}
			get{return _isautofreshnogroup;}
		}
		/// <summary>
		/// �������������޵�����
		/// </summary>
		public int? IsAutoBarcode
		{
			set{ _isautobarcode=value;}
			get{return _isautobarcode;}
		}
		/// <summary>
		/// �����Ա����޵�����
		/// </summary>
		public int? IsDefineItemNo
		{
			set{ _isdefineitemno=value;}
			get{return _isdefineitemno;}
		}
		/// <summary>
		/// ��������۸�����
		/// </summary>
		public int? IsAutoPriceCreate
		{
			set{ _isautopricecreate=value;}
			get{return _isautopricecreate;}
		}
		/// <summary>
		/// 1ʵ��ʵ��(Ĭ��)2Ĩ�������µĽ��3Ĩ��Ԫ���µĽ��4Ԫ���µĽ����������5�����µĽ����������
		/// </summary>
		public int? SmallChangeRound
		{
			set{ _smallchangeround=value;}
			get{return _smallchangeround;}
		}
		/// <summary>
		/// ��ӡСƱ�Ƿ�ʹ����Ʒ���
		/// </summary>
		public int? IsPrintItemShortName
		{
			set{ _isprintitemshortname=value;}
			get{return _isprintitemshortname;}
		}
		/// <summary>
		/// �Ƿ��ӡ�Żݺϼ�
		/// </summary>
		public int? IsPrintSumDiscount
		{
			set{ _isprintsumdiscount=value;}
			get{return _isprintsumdiscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BillPrintTitle
		{
			set{ _billprinttitle=value;}
			get{return _billprinttitle;}
		}
		/// <summary>
		/// СƱ��ӡ�ŵ���Ϣ
		/// </summary>
		public string BillPrintBranch
		{
			set{ _billprintbranch=value;}
			get{return _billprintbranch;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣһ
		/// </summary>
		public string BillPrintFooter1
		{
			set{ _billprintfooter1=value;}
			get{return _billprintfooter1;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter2
		{
			set{ _billprintfooter2=value;}
			get{return _billprintfooter2;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter3
		{
			set{ _billprintfooter3=value;}
			get{return _billprintfooter3;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter4
		{
			set{ _billprintfooter4=value;}
			get{return _billprintfooter4;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter5
		{
			set{ _billprintfooter5=value;}
			get{return _billprintfooter5;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter6
		{
			set{ _billprintfooter6=value;}
			get{return _billprintfooter6;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter7
		{
			set{ _billprintfooter7=value;}
			get{return _billprintfooter7;}
		}
		/// <summary>
		/// СƱ��ӡƱβ��Ϣ��
		/// </summary>
		public string BillPrintFooter8
		{
			set{ _billprintfooter8=value;}
			get{return _billprintfooter8;}
		}
		#endregion Model

	}
}

