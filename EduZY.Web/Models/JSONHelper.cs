using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace EduZY.Web.Models
{
    public class JSONHelper
    {

        protected System.Collections.ArrayList arrData = new System.Collections.ArrayList();
        protected System.Collections.ArrayList arrDataItem = new System.Collections.ArrayList();

        public JSONHelper()
        {

        }
        public void AddItem(string name, string value)
        {
            if (name == "isRoot")
            {
                arrData.Add("\"" + name + "\":" + "" + value + "");

            }
            else
            {
                try
                {
                    arrData.Add("\"" + name + "\":" + "" + Convert.ToInt32(value) + "");

                }
                catch
                {
                    arrData.Add("\"" + name + "\":" + "\"" + value + "\"");

                }
            }
        }

        public void ItemOk()
        {
            arrData.Add("<BR>");
        }
        //序列化JSON对象，得到返回的JSON代码
        public string sToString(string fjsons)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"Rows\":[{");

            sb.Append("\"leaf\":false,");
            sb.Append("\"children\":[");

            int index = 0;
            sb.Append("{");
            if (arrData.Count <= 0)
            {
                sb.Append("}]");
            }
            else
            {
                foreach (string val in arrData)
                {
                    index++;

                    if (val != "<BR>")
                    {
                        sb.Append(val + ",");
                    }
                    else
                    {
                        sb = sb.Replace(",", "", sb.Length - 1, 1);
                        sb.Append("},");
                        if (index < arrData.Count)
                        {
                            sb.Append("{");
                        }
                    }

                }
                sb = sb.Replace(",", "", sb.Length - 1, 1);
                sb.Append("]");
            }

            sb.Append("," + fjsons);

            sb.Append("}]}");
            return sb.ToString();
        }

        public string PageJsonToString1(int pageSize, int pageIndex, string searchId, int pageCount, int totalPage)
        {
            StringBuilder sb = new StringBuilder();


            //开始 结束  
            sb.Append("{\"pageObject\":{\"endIndexOnShow\":" + totalPage + ",\"first\":0,\"indexCountOnShow\":7,\"fullListSize\":" + pageCount + ",\"sortDirection\":null,\"pageNumber\":" + pageIndex + ",\"paginatedList\":");
            //开始 结束  
            sb.Append("{\"fullListSize\":" + pageCount + ",\"sortDirection\":null,\"searchId\":null,");
            sb.Append("\"list\":[");
            int index = 0;
            sb.Append("{");
            if (arrData.Count <= 0)
            {
                sb.Append("}]");
            }
            else
            {
                foreach (string val in arrData)
                {
                    index++;

                    if (val != "<BR>")
                    {
                        sb.Append(val + ",");
                    }
                    else
                    {
                        sb = sb.Replace(",", "", sb.Length - 1, 1);
                        sb.Append("},");
                        if (index < arrData.Count)
                        {
                            sb.Append("{");
                        }
                    }

                }
                sb = sb.Replace(",", "", sb.Length - 1, 1);
                sb.Append("],");
            }

            sb.Append("\"class\":\"com.wiscom.generic.base.tag.PaginatedListImpl\",\"pageNumber\":" + pageIndex + ",\"sortCriterion\":null,\"objectsPerPage\":" + pageSize + "},");


            return sb.ToString();
        }
        public string PageJsonToString2(int pageSize, int pageIndex, string searchId, int pageCount, int totalPage)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\"totalCount\":" + pageCount + ",");
            sb.Append("\"items\":[");
            int index = 0;
            sb.Append("{");
            if (arrData.Count <= 0)
            {
                sb.Append("}]");
            }
            else
            {
                foreach (string val in arrData)
                {
                    index++;

                    if (val != "<BR>")
                    {
                        sb.Append(val + ",");
                    }
                    else
                    {
                        sb = sb.Replace(",", "", sb.Length - 1, 1);
                        sb.Append("},");
                        if (index < arrData.Count)
                        {
                            sb.Append("{");
                        }
                    }
                }
                sb = sb.Replace(",", "", sb.Length - 1, 1);
                sb.Append("],");
            }

            sb.Append("\"sortCriterion\":null,\"objectsPerPage\":" + pageSize + ",\"startIndexOnShow\":" + pageIndex + ",\"nextIndex\":" + Convert.ToInt32(pageIndex + 1) + ",\"endIndex\":" + totalPage + ",\"dataRequest\":null,");
            return sb.ToString();
        }
        public string PageJsonToString3(int pageSize, int pageIndex, string searchId, int pageCount, int totalPage)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\"list\":[");
            int index = 0;
            sb.Append("{");
            if (arrData.Count <= 0)
            {
                sb.Append("}]");
            }
            else
            {
                foreach (string val in arrData)
                {
                    index++;

                    if (val != "<BR>")
                    {
                        sb.Append(val + ",");
                    }
                    else
                    {
                        sb = sb.Replace(",", "", sb.Length - 1, 1);
                        sb.Append("},");
                        if (index < arrData.Count)
                        {
                            sb.Append("{");
                        }
                    }
                }
                sb = sb.Replace(",", "", sb.Length - 1, 1);
                sb.Append("],");
            }

            sb.Append("\"searchId\":null,\"indexes\":[],\"pageSize\":" + pageSize + ",\"startIndex\":0,\"previousIndex\":" + pageIndex + ",\"pageCount\":" + totalPage + ",\"currentIndex\":" + pageIndex + "");
            sb.Append("}");//结尾2个字符
            sb.Append("}");//结尾2个字符


            return sb.ToString();
        }
    }
}