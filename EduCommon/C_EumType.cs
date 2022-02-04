
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 枚举类型
    /// </summary>
    public class C_EumType
    {
        /// <summary>
        /// 资源对象类型
        /// </summary>
        public enum GetResourceLevel
        {
            菜单 = 0,
            按钮 = 1
        }

        /// <summary>
        /// 按钮类型
        /// </summary>
        public enum GetRoleRightBtnName
        {
            //用户列表按钮权限//
            SelectUser,
            AddUser,
            UpdateUser,
            DeleteUser,
            //用户列表按钮权限//

            //用户角色按钮权限//
            SelectRole,
            AddRole,
            UpdateRole,
            DeleteRoler
            //用户角色按钮权限//

        }

        public enum GetRoleRightResourceName
        {
            用户管理,
            角色管理

        }
        public enum GetSEXID
        {
            男 = 56,
            女 = 57,
        }
        public enum GetIsDutyID
        {
            是 = 1,
            否 = 0,
        }

        public enum GetISJoinID
        {
            是 = 1,
            否 = 0,
        }
        //0 平时成绩 1 重考成绩 2 重修成绩 3 免修成绩
        public enum GetScoreType
        {
            平时成绩 = 0,
            重考成绩 = 1,
            重修成绩 = 2,
            免修成绩 = 3,
        }

        public enum GetSoureID
        {
            正式生 = 185,
            借读生 = 186,
            试读生 = 187,
            旁听生 = 188,
        }

        public enum GetChangesID
        {
            休学 = 183,
            试读 = 182,
            跳级 = 181,
            降级 = 180,
            留级 = 179,
            正常 = 178,
        }
        public enum GetDataBasicClass
        {
            学校办别码 = 1,
            学校类别码 = 6,
            所在地区类别码 = 10,
            所在地经济属性码 = 14,
            所在地民族属性 = 18,
            主教学语言 = 21,
            学期类型 = 29,
            年级类型 = 37,
            年级阶段 = 33,
            班级类型 = 41,
            编制类别=94,
            文化程度=89,
            户口性质=86,
            家庭出生_本人成分=81,
            婚姻状况=76,
            港澳台侨=72,
            血型=66,
            健康状况=62,
            民族=58,
            性别=55,
            教学类型 = 109,
            考察结果 = 105,
            考察类别 = 102,
            聘任情况 = 159,
            取得资格途径 = 156,
            任职资格名称_聘任职务 = 152,
            免职原因 = 149,
            免职方式 = 144,
            当前任职状况 = 141,
            任务变动类别 = 134,
            职位分类 = 130,
            职务级别 = 126,
            任职方式 = 121,
            职务名称 = 117,
            职务类别 = 113,
            来自国家 = 173,
            批准单位级别 = 169,
            专家类别 = 165,
            政治面貌 = 207,
            入学方式 = 201,
            学生类别 = 194,
            就读方式 = 189,
            学生来源 = 184,
            学籍异动类别代码 = 177,
            毕业结业类型 = 213,
            学科类型 = 217,
            技能名称 = 259,
            勤工俭学名称 = 253,
            实践活动类别 = 249,
            活动内容 = 244,
            完成质量 = 239,
            缺勤类型 = 233,
            奖励类别 = 229,
            奖励级别 = 225,
            获奖级别 = 265,
            文艺活动类别 = 273,
            娱乐活动类别 = 269,
            信息级别 = 51,
            信息类别 = 46,
            补贴来源 = 285,
            补贴原因 = 286,
            学生状态 = 287,
        }
    }


}

