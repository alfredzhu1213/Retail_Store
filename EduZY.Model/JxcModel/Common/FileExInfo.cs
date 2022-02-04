using System;
using System.Collections.Generic;
using System.Web;

namespace EduZY.Model.Common
{
    public class FileExInfo
    {
        public string FileName
        {
            get;
            set;
        }
        public string ID
        {
            get;
            set;
        }
        public string FileExtension
        {
            get;
            set;
        }
        public long FileSize
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public int OrderIndex
        {
            get;
            set;
        }

        public string ServerID
        {
            get;
            set;
        }
        public string ViewPermission
        {
            get;
            set;
        }
    }
}