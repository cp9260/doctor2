using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Doctor
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.richTextBox1.Invoke(d, new object[] { text });
                
            }
            else
            {
                richTextBox1.AppendText(text+"\n");
            }

        }

        CookieContainer cook = null;
        public Form1()
        {
            InitializeComponent();
        }

        public void Hello(string aa)
        {
            MessageBox.Show(aa);
        }

        public void test()
        {
            MessageBox.Show("asdaf");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.ObjectForScripting = this;
            //string path = Application.StartupPath + @"\test.htm";
            string path = "http://192.168.0.221:8081/superscene/test.html";
            path = " http://mcm3.pc.e-health.org.cn";
       
            //MessageBox.Show(path);
            this.webBrowser1.Navigate(path);
            //this.webBrowser1.Url = new System.Uri(path, System.UriKind.Absolute);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.webBrowser1.Document.InvokeScript("winfromForJs", new object[]{"winform 调用 js","我是第二个参数"});
           // this.webBrowser1.Document.InvokeScript("fun");
            if (cook == null) { 
                cook = GetCookieString();
                HttpLoad.getInstance().setCook(cook);
            
            }
            DataConvertWomen.getInstance();
            DataConvertMen.getInstance();
            //this.webBrowser1.Navigate("");
           // this.button1.Visible = false;

            MainService.getInstance().form1 = this;
           
            
            //MainService.getInstance().work();
            new Sqlservice().test(this.checkBox1.Checked);

            datafresh();

        }


        private CookieContainer GetCookieString()
        {
            // Determine the size of the cookie      
            CookieContainer myCookieContainer = new CookieContainer();

            string cookieStr = this.webBrowser1.Document.Cookie;
            string[] cookstr = cookieStr.Split(';');
            foreach (string str in cookstr)
            {
                string[] cookieNameValue = str.Split('=');
                Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                ck.Domain = "mcm3.pc.e-health.org.cn";
                myCookieContainer.Add(ck);
            }
            return myCookieContainer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;

            button2.Visible = true;
            button3.Visible = true;
            this.checkBox1.Visible = true;
            datafresh();

            button2.Visible = false;

            button1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            datafresh();
        }

        public void datafresh()
        {
            string ConnectString = ConfigurationManager.AppSettings["SQL"];

            SqlConnection con = null;
            SqlCommand cmd = null;

            con = new SqlConnection(ConnectString);       //连接到数据库
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from dbo."+SysConstUrl.tableName+" where isUpdate = N'0'"; //T-SQL语句    
            con.Open();                                  //创建连接后需要用Open打开连接，结束后要关闭连接，及时释放资源
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dataGridView1.ReadOnly = true;
            da.Fill(ds, SysConstUrl.tableName);
            dataGridView1.DataSource = ds;

            dataGridView1.DataMember = SysConstUrl.tableName;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }
    }
}
