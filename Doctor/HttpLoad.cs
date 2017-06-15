using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;



namespace Doctor
{
    class HttpLoad
    {
        private static HttpLoad httpLoad = null;
        private HttpLoad() { }

        public static HttpLoad getInstance()
        {
            if (httpLoad == null) {
                httpLoad = new HttpLoad();
            }
            return httpLoad;
        }

        private CookieContainer cook = null;

        public void setCook(CookieContainer cook)
        {
            this.cook = cook;
        }
        public void test() {
            //login();
            string strURL = "http://mcm3.pc.e-health.org.cn/entity/basic/labExamW_submitWomanClinical.action?labExamId=ff80808154416b140154462682bc2859&psid=ff80808154416b140154462682bc2859&leuClueCell1=1&leuTrichomonas1=&leuAmineOdor1=0&candidiasis=&leuCleanliness1=&wphValue=&gonorrhoeae1=&chlamydiaT1=&whb=&wrbC=&wpbT=&wwbC=&wn=&we=20&wb=&wl=&wm=&urineRoutineM=&abO1=&rh1=&wbloodSugar=&hbs_Ag=&hbs_Ab=&hbe_Ag=&hbe_Ab=&hbc_Ab=&walT=&wcr=&wtsH=&rvigg1=&cvigg1=&tgigg1=&treponema=&cvigm1=&tgigm1=&custom39=&custom43=&custom40=&custom41=&custom42=&custom44=&custom45=&custom46=&custom135=&custom136=&elseItem=&testerName=%E5%B9%BF%E4%B8%9C%E7%9C%81%E5%B9%BF%E5%B7%9E%E5%B8%82%E7%99%BD%E4%BA%91%E5%8C%BA%E7%9F%B3%E4%BA%95%E8%A1%97%E9%81%93&wcheckDate=2017-05-15http://mcm3.pc.e-health.org.cn/entity/basic/labExamW_submitWomanClinical.action?labExamId=ff80808154416b140154462682bc2859&psid=ff80808154416b140154462682bc2859&leuClueCell1=1&leuTrichomonas1=&leuAmineOdor1=0&candidiasis=&leuCleanliness1=&wphValue=&gonorrhoeae1=&chlamydiaT1=&whb=&wrbC=&wpbT=&wwbC=&wn=&we=20&wb=&wl=&wm=&urineRoutineM=&abO1=&rh1=&wbloodSugar=&hbs_Ag=&hbs_Ab=&hbe_Ag=&hbe_Ab=&hbc_Ab=&walT=&wcr=&wtsH=&rvigg1=&cvigg1=&tgigg1=&treponema=&cvigm1=&tgigm1=&custom39=&custom43=&custom40=&custom41=&custom42=&custom44=&custom45=&custom46=&custom135=&custom136=&elseItem=&testerName=%E5%B9%BF%E4%B8%9C%E7%9C%81%E5%B9%BF%E5%B7%9E%E5%B8%82%E7%99%BD%E4%BA%91%E5%8C%BA%E7%9F%B3%E4%BA%95%E8%A1%97%E9%81%93&wcheckDate=2017-05-15";
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.CookieContainer = cook;
            //request.Method="get";
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            XmlTextReader Reader = new XmlTextReader(s);
            Reader.MoveToContent();
            string strValue = Reader.ReadInnerXml();
            //strValue = strValue.Replace("&lt;", "<");
            //strValue = strValue.Replace("&gt;", ">");
            MessageBox.Show(strValue);
            Reader.Close();
            /* 何问起 hovertree.com */
        }

        public string httpForValue(String url)
        {
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cook;
            //request.Method="get";
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            XmlTextReader Reader = new XmlTextReader(s);
            Reader.MoveToContent();
            string strValue = Reader.ReadInnerXml();
            //strValue = strValue.Replace("&lt;", "<");
            //strValue = strValue.Replace("&gt;", ">");
            MessageBox.Show(strValue);
            Reader.Close();
            //JsonTextParser parser = new JsonTextParser();
            //JsonObject obj = parser.Parse(strValue);
            /* 何问起 hovertree.com */
            return strValue;
        }

        public JObject httpForJson(String url)
        {
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cook;
            System.Net.HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            // response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            string result = sr.ReadToEnd();
            //strValue = strValue.Replace("&lt;", "<");
            //strValue = strValue.Replace("&gt;", ">");
            //MessageBox.Show(result);
            sr.Close();
            JObject obj = JObject.Parse(result);
            /* 何问起 hovertree.com */
            return obj;
        }

    }
}
