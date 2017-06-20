using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Doctor
{
    class Sqlservice
    {

        public string ConnectString = "";

        public SqlConnection con = null;

        public Sqlservice() {
            this.ConnectString = ConfigurationManager.AppSettings["SQL"];
        }

        public SqlConnection getConn()
        {
            if (con == null)
            {
                con = new SqlConnection(ConnectString);
                con.Open();
            }
            return con;
        }
        public void test(bool flag) {

            //数据库连接字符串，注意这个写法（localdb）后面必须是两个斜杠，因为这中间有个转义的过程
	            //Initial Catalog=要连接的数据库名
	            //Intergrated Security=true  开启windows身份验证
          
	            SqlCommand cmd = null;
	            SqlDataReader str = null;
	            try { 
	                con = new SqlConnection(ConnectString);       //连接到数据库
	                cmd = con.CreateCommand();
                  //  cmd.CommandText = "select * from dbo." + SysConstUrl.tableName + " where sex = N'女' and isUpdate = N'0'"; //T-SQL语句    
                    cmd.CommandText = "select * from dbo." + SysConstUrl.tableName + " where isUpdate = N'0'"; //T-SQL语句    

                    con.Open();                                  //创建连接后需要用Open打开连接，结束后要关闭连接，及时释放资源
	                str = cmd.ExecuteReader();                  
	                while(str.Read()){
                        Dictionary<string, string> map = new Dictionary<string, string>();
                        string sfz = null;
                        string no = "";
                        for (int n = 0; n < str.FieldCount; n++){
                        
                            string key = str.GetName(n);
                            string value = str.GetValue(n).ToString().Trim();
                            if (DataConvertBC.menType.ContainsKey(key)) {
                                map.Add(DataConvertBC.menType[key], value);
                            }
                            if (key == "sfz") {
                                sfz = value;
                            }
                            if (key == "sfz")
                            {
                                no = value;
                            }

                        }
                        if (sfz == null)
                            continue;
                        // Dictionary<string, string> temp = DataConvert.getInstance().
                        try
                        {
                            MainService.getInstance().work(sfz, map, no, flag);
                        }
                        catch (Exception)
                        { 
                        }
	                    }

	                }
	            catch(Exception ms)
	            {
	                Console.WriteLine(ms.Message);
	            }
	            finally
	            {
                    if(str != null)
	                str.Close();
	                cmd.Clone();
	                con.Close();
	            }
        }

        public Dictionary<string, string> getMen(string no)
        {

            //数据库连接字符串，注意这个写法（localdb）后面必须是两个斜杠，因为这中间有个转义的过程
            //Initial Catalog=要连接的数据库名
            //Intergrated Security=true  开启windows身份验证

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader str = null;
            Dictionary<string, string> map = new Dictionary<string, string>();
            try
            {
                con = new SqlConnection(ConnectString);       //连接到数据库
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo." + SysConstUrl.tableName + " where sex = N'男' and no = " + no; //T-SQL语句    
                con.Open();                                  //创建连接后需要用Open打开连接，结束后要关闭连接，及时释放资源
                str = cmd.ExecuteReader();
               
                if (str.Read())
                {
                   
                    for (int n = 0; n < str.FieldCount; n++)
                    {

                        string key = str.GetName(n);
                        string value = str.GetValue(n).ToString().Trim();
                        if (DataConvertMen.menType.ContainsKey(key))
                        {
                            map.Add(DataConvertMen.menType[key], value);
                        }
                        
                    }
                    // Dictionary<string, string> temp = DataConvert.getInstance().
                 
                }
            }
            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
            finally
            {
                if(str != null)
                    str.Close();
                if (cmd != null)
                    cmd.Clone();
                if(con != null)
                    con.Close();
            }
            return map;
        }

    }
}
