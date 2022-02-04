using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_MemberClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_MemberClass
	{
		public tb_MemberClass()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _yhremark;
		private decimal? _zk;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        private string _text;
        public string text
        {
            set { _text = value; }
            get { return _text; }
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
		/// 优惠方案
		/// </summary>
		public string YHRemark
		{
			set{ _yhremark=value;}
			get{return _yhremark;}
		}
		/// <summary>
		/// 会员折扣率
		/// </summary>
		public decimal? ZK
		{
			set{ _zk=value;}
			get{return _zk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model



	}
}

