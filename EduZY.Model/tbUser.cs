using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduZY.Model
{
     public  class tbUser
     {
         //public string nodeName { get; set; }
         public int id { get; set; }
         public string text { get; set; }
         public List<tbUser> children { get; set; }
         public string iconCls { get; set; }
         public string state { get; set; }
         public bool Checkedes { get; set; }
         public int target { get; set; }
    }
}
