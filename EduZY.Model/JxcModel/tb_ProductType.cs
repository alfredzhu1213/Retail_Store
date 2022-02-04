using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_ProductType
	{
		public tb_ProductType()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private int? _parentid;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}

        public string text { get; set; }
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
		/// 父Id
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model


        public System.Collections.Generic.List<tb_ProductType> children { get; set; }
    }
}

