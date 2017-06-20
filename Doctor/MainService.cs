using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Doctor
{
    class MainService
    {

        private static MainService mainService = null;

        public Form1 form1;
        
        private MainService() { }

        public static MainService getInstance() {
            if (mainService == null)
            {
                mainService = new MainService();
            }
            return mainService;
        }
      

        public void work() {
            HttpLoad http = HttpLoad.getInstance();

            //查询表数据，遍历每条记录

            //查询人名获取model
            String name = "张新新";
            name = System.Web.HttpUtility.UrlEncode(name, Encoding.GetEncoding("utf-8"));
            Console.WriteLine(name);
            string url = SysConstUrl.search;
            url = url.Replace("@!",name);
            JObject search = http.httpForJson(url);
            Console.WriteLine(search.ToString()); 
            Console.WriteLine(search["models"]);
            string ids = search["models"][0]["id"].ToString();
            //TODO 解析model获取相关信息 

            //完善结果获取表单类型 提交action
            url = SysConstUrl.sumbitParms;
            url = url.Replace("ids11", ids);
            JObject parms = http.httpForJson(url);
            Console.WriteLine(parms.ToString());


            url = SysConstUrl.submit;
            url = url.Replace("ids11", ids);
            JObject result = http.httpForJson(url);
            Console.WriteLine(result.ToString()); 
            //组装数据

            //提交
        
        }

        public void work(string sfz, Dictionary<string, string> map)
        {
            HttpLoad http = HttpLoad.getInstance();

            //查询表数据，遍历每条记录

            //查询人名获取model
            String name = "张新新";
            name = System.Web.HttpUtility.UrlEncode(name, Encoding.GetEncoding("utf-8"));
            Console.WriteLine(name);
            string url = SysConstUrl.search;
            url = url.Replace("@!", name);
            JObject search = http.httpForJson(url);
            Console.WriteLine(search.ToString());
            Console.WriteLine(search["models"]);
            string ids = search["models"][0]["id"].ToString();
            //TODO 解析model获取相关信息 

            //完善结果获取表单类型 提交action
            //url = SysConstUrl.sumbitParms;
            //url = url.Replace("ids11", ids);
            //JObject parms = http.httpForJson(url);
            //Console.WriteLine(parms.ToString());
            
            url = DataConvertWomen.getInstance().ConvertDataForWomen(map, ids);
            //url = SysConstUrl.submit;
            //url = url.Replace("ids11", ids);
            JObject result = http.httpForJson(url);
            Console.WriteLine(result.ToString()); 
        }

        public void work(string sfz, Dictionary<string, string> map, Dictionary<string, string> menMap,string no,bool flag)
        {
            HttpLoad http = HttpLoad.getInstance();

            //查询表数据，遍历每条记录
            SqlConnection con = new Sqlservice().getConn();
            SqlCommand cmd = con.CreateCommand();
            //查询人名获取model
           // String name = "张新新";
           // name = System.Web.HttpUtility.UrlEncode(name, Encoding.GetEncoding("utf-8"));
            //Console.WriteLine(name);
            string url = SysConstUrl.search;
            url = url.Replace("@!", sfz);
            JObject search = http.httpForJson(url);
            Console.WriteLine(search.ToString());
            Console.WriteLine(search["models"]);
            string ids = search["models"][0]["id"].Value<string>();
            string mm = search["models"][0]["gdLabExamM"]["enumConstByComplete"]["name"].Value<string>();
            bool wFlag = mm== "首诊完成" ? true : false;
            //string gg = search["models"][0]["gdLabExamM"]["enumConstByCompleteM"]["name"].ToString();
            //bool mFlag = gg== "首诊完成" ? true : false;
            //TODO 解析model获取相关信息 

            //完善结果获取表单类型 提交action
            //url = SysConstUrl.sumbitParms;
            //url = url.Replace("ids11", ids);
            //JObject parms = http.httpForJson(url);
            //Console.WriteLine(parms.ToString());
            if (wFlag) {
                form1.SetText("已完成不更新:" + no);
                con.Close();
                return;
            }
            url = DataConvertWomen.getInstance().ConvertDataForWomen(map, ids);
            if (flag) {
                url += "&iscomplete=1";
            }
            //url = SysConstUrl.submit;
            //url = url.Replace("ids11", ids);
            JObject result = http.httpForJson(url);
            
            if (result["success"].Value<string>()== "True")
            {
                Console.WriteLine("更新女成功");

                string sql_update = "update dbo." + SysConstUrl.tableName + " set isUpdate = N'1' where sex = N'女' and no=N'" + no + "'";
                cmd.CommandText = sql_update;
                cmd.ExecuteNonQuery();
                form1.SetText("更新女成功:"+no);          
            }
            else
            {
                Console.WriteLine("更新女失败");
            }

            url = DataConvertMen.getInstance().ConvertDataForMen(menMap, ids);
            if (flag)
            {
                url += "&iscomplete=1";
            }
            //url = SysConstUrl.submit;
            //url = url.Replace("ids11", ids);
            result = http.httpForJson(url);

            if (result["success"].Value<string>() == "True")
            {
                Console.WriteLine("更新男成功");
                string sql_update = "update dbo." + SysConstUrl.tableName + " set isUpdate = N'1' where sex = N'男' and no=N'" + no + "'";
                cmd.CommandText = sql_update;
                cmd.ExecuteNonQuery();
                form1.SetText("更新男成功:"+no );  
            }
            con.Close();
        }

        public void work(string sfz, Dictionary<string, string> map, string no, bool flag)
        {
            HttpLoad http = HttpLoad.getInstance();

            //查询表数据，遍历每条记录
            SqlConnection con = new Sqlservice().getConn();
            SqlCommand cmd = con.CreateCommand();
            //查询人名获取model
            // String name = "张新新";
            // name = System.Web.HttpUtility.UrlEncode(name, Encoding.GetEncoding("utf-8"));
            //Console.WriteLine(name);
            string url = SysConstUrl.searchBC;
            url = url.Replace("@!", sfz);
            JObject search = http.httpForJson(url);
            //Console.WriteLine(search.ToString());
            //Console.WriteLine(search["models"]);
            string ids = search["models"][0]["id"].Value<string>();
            string serviceCode = search["models"][0]["ps"]["SERVICE_CODE"].Value<string>();
            string mm = search["models"][0]["complete"].Value<string>();
            bool wFlag = mm == "完成" ? true : false;
            //string gg = search["models"][0]["gdLabExamM"]["enumConstByCompleteM"]["name"].ToString();
            //bool mFlag = gg== "首诊完成" ? true : false;
            //TODO 解析model获取相关信息 

            //完善结果获取表单类型 提交action
            //url = SysConstUrl.sumbitParms;
            //url = url.Replace("ids11", ids);
            //JObject parms = http.httpForJson(url);
            //Console.WriteLine(parms.ToString());

            if (wFlag)
            {
                form1.SetText("已完成不更新:" + no);
                con.Close();
                return;
            }

            url = DataConvertBC.getInstance().ConvertDataForBC(map, ids, serviceCode);
            if (flag)
            {
                url += "&yncomplete=1";
            }
            //url = SysConstUrl.submit;
            //url = url.Replace("ids11", ids);
            JObject result = http.httpForJson(url);

            if (result["success"].Value<string>() == "True")
            {
                Console.WriteLine("更新女成功");

                string sql_update = "update dbo." + SysConstUrl.tableName + " set isUpdate = N'1' where sfz=N'" + no + "'";
                cmd.CommandText = sql_update;
                cmd.ExecuteNonQuery();
                form1.SetText("更新女成功:" + no);
            }
            else
            {
                Console.WriteLine("更新女失败");
            }

           
            con.Close();
        }
    }
}
