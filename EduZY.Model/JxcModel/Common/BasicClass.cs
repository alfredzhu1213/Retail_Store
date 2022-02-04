
using System;
namespace EduZY.Model.Common
{
	/// <summary>
	/// BasicClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BasicClass
	{
		public BasicClass()
		{}
		#region Model
		private int _classid;
		private string _classname;
		private int _parentclassid=0;
		private int? _operationuserid=0;
		private DateTime? _addtime= DateTime.Now;
		private DateTime? _updatetime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentClassID
		{
			set{ _parentclassid=value;}
			get{return _parentclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperationUserID
		{
			set{ _operationuserid=value;}
			get{return _operationuserid;}
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

