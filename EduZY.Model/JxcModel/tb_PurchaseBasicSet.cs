using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_PurchaseBasicSet:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ɹ��ջ��������Чʱ��ʱ������Ʒ�����еĽ���(0����)
		/// </summary>
		public int? SetStatus1
		{
			set{ _setstatus1=value;}
			get{return _setstatus1;}
		}
		/// <summary>
		/// �ջ������������ܼ��Զ����㵥��
		/// </summary>
		public int? SetStatus2
		{
			set{ _setstatus2=value;}
			get{return _setstatus2;}
		}
		/// <summary>
		/// �ɹ��ջ�����0������Ʒ���
		/// </summary>
		public int? SetStatus3
		{
			set{ _setstatus3=value;}
			get{return _setstatus3;}
		}
		/// <summary>
		/// ����ɹ���������ⵥ��ͨ��ɨ�뽨��(ֻ��13λ��׼������Ч
		/// </summary>
		public int? SetStatus4
		{
			set{ _setstatus4=value;}
			get{return _setstatus4;}
		}
		#endregion Model

	}
}

