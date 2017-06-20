using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Doctor
{
    class DataConvertBC
    {
        private static DataConvertBC dataConvert = null;
        public static Dictionary<string, Dictionary<string, string>> men = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> menType = new Dictionary<string, string>();

        private DataConvertBC()
        {
            init();
        }

        private void init()
        {
           

            Dictionary<string, string> type = new Dictionary<string, string>();
            type.Add("未见异常", "0");
            type.Add("异常", "1");
            type.Add("正常", "0");




            men.Add("result", null);         //B超结果
            men.Add("resultDesc", null);     //B超结果描述
            men.Add("doctorName", null);    //医师签名
            men.Add("reportDate", null);    //日期


            menType.Add("zdjg", "result");                      
            menType.Add("msjg", "resultDesc");                   
            menType.Add("jcys", "doctorName");                   
            menType.Add("jcrq", "reportDate");                   
            
        

            
        }

        public static DataConvertBC getInstance()
        {
            if (dataConvert == null) {
                dataConvert = new DataConvertBC();
            }
            return dataConvert;
        }

        public string ConvertDataForBC(Dictionary<string, string> data, string id, string serviceCode)
        {
            string url = SysConstUrl.submitBC.Replace("ids11", id);
            url = url.Replace("serviceCode", serviceCode);
            foreach (string key in data.Keys) { 
                string temp = "&"+key+"=";
                string value = data[key];
                if (men.ContainsKey(key) && men[key] != null) {
                    if (men[key].ContainsKey(data[key])) {
                        value = men[key][data[key]];
                        //value = System.Web.HttpUtility.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                    } 
                }
                if (hasChinese(value) || key == "doctorName")
                {
                    value = SysConstUrl.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                }
                if (key == "reportDate")
                {
                    value = value.Replace("/","-");
                }
                url = url + temp + value;
            }
           // url = System.Web.HttpUtility.UrlEncode(url, Encoding.GetEncoding("utf-8"));
            return url;
        }

        public bool hasChinese(string CString)
        {
            return Regex.IsMatch(CString, @"^.*[\u4e00-\u9fa5].*$"); //存在中文
        }
    }
}
