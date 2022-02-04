using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduZY.Web.Models
{
    public class MyViewEngine : RazorViewEngine
    {
        public MyViewEngine()
        {
          
        }
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            this.ViewLocationFormats = new[]
            {
                "~/Views/Admin/{1}/{0}.cshtml",//我们的规则
                "~/Views/Admin/{0}.cshtml"
                
            };
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}