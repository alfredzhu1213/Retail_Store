using System;
using System.Collections.Generic;
using System.Text;

namespace EduZY.Model.Common
{
    /// <summary>
    /// BasicUnit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BasicUnit
    {
        public BasicUnit()
        { }
        #region Model
        private int _unitid;
        private string _unitcode;
        private string _unitname;
        private int? _unitclassid;
        private int? _pcaid;
        private string _remark;
        private int _parentunitid = 0;
        private int? _unitmanageuserid = 0;
        private int? _operationuserid = 0;
        private DateTime? _addtime ;
        private DateTime? _updatetime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int UnitID
        {
            set { _unitid = value; }
            get { return _unitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitCode
        {
            set { _unitcode = value; }
            get { return _unitcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UnitClassID
        {
            set { _unitclassid = value; }
            get { return _unitclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PCAID
        {
            set { _pcaid = value; }
            get { return _pcaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentUnitID
        {
            set { _parentunitid = value; }
            get { return _parentunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UnitManageUserID
        {
            set { _unitmanageuserid = value; }
            get { return _unitmanageuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OperationUserID
        {
            set { _operationuserid = value; }
            get { return _operationuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}
