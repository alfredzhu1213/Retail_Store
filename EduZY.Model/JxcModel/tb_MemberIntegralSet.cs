using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_MemberIntegralSet:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class tb_MemberIntegralSet
	{
		public tb_MemberIntegralSet()
		{}
		#region Model
		private int _id;
		private decimal? _xfprice;
		private int? _ispayintegralenable=0;
		private decimal? _integral;
		private decimal? _diprice;
		private int? _isscorepayingnoscoring=0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���ѽ��ÿ 1Ԫ��1�֣�0��ʾ�����֣�
		/// </summary>
		public decimal? xfPrice
		{
			set{ _xfprice=value;}
			get{return _xfprice;}
		}
		/// <summary>
		/// �������ָ����
		/// </summary>
		public int? IsPayIntegralEnable
		{
			set{ _ispayintegralenable=value;}
			get{return _ispayintegralenable;}
		}
		/// <summary>
		/// ÿ 100 ��
		/// </summary>
		public decimal? Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// �ɵ��� 10Ԫ
		/// </summary>
		public decimal? diPrice
		{
			set{ _diprice=value;}
			get{return _diprice;}
		}
		/// <summary>
		/// ���ָ���Ľ��ٻ���
		/// </summary>
		public int? IsScorePayingNoScoring
		{
			set{ _isscorepayingnoscoring=value;}
			get{return _isscorepayingnoscoring;}
		}
		#endregion Model

	}
}

