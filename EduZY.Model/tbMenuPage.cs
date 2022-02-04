using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduZY.Model
{
    public partial class tb_MenuPage
    {
        public List<tb_MenuPage> children { get; set; }
        public string StatusName { get; set; }
        public string MenuTypeName { get; set; }
        public string nodeName { get; set; }
        public int id { get; set; }
        public string text { get; set; }

        public string iconCls { get; set; }
        public string state { get; set; }
        public int Checked { get; set; }
    }
}
