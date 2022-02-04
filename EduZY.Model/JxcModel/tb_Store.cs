using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_Store:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Store
	{
		public tb_Store()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _lxr;
		private string _tel;
		private string _address;
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
		/// 
		/// </summary>
		public string Code
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
		/// 联系人
		/// </summary>
		public string lxr
		{
			set{ _lxr=value;}
			get{return _lxr;}
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

