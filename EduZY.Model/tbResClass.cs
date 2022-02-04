using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduZY.Model
{
    public partial class tb_Res_Class
    {
        public List<tb_Res_Class> children { get; set; }
        public string StatusName { get; set; }
        public string TypeName { get; set; }
      
        public int id { get; set; }
        public string text { get; set; }

        public int topid { get; set; }
        public bool Checkedes { get; set; }
        public string iconCls { get; set; }
        public string state { get; set; }
        public int Checked { get; set; }
    }
}
