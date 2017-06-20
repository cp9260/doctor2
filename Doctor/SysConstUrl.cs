using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Doctor
{
    class SysConstUrl
    {
        //public const string search = "http://mcm3.pc.e-health.org.cn/entity/exam/labExamReport_abstractList.action?start=0&limit=20&search__fname=@!&sort=id&dir=DESC";

        public const string search = "http://mcm3.pc.e-health.org.cn/entity/exam/labExamReport_abstractList.action?start=0&limit=20&search__fidCard=@!&sort=id&dir=DESC";

        public const string searchBC = "http://mcm3.pc.e-health.org.cn/entity/image/bmodResult_abstractList.action?start=0&limit=20&&search__ps.FNAME=&search__bi.fid_card=@!&sort=id&dir=DESC";
       // public const string searchBC = "http://mcm3.pc.e-health.org.cn/entity/image/bmodResult_abstractList.action?start=0&limit=20&search__ps.SERVICE_CODE=&search__ps.FNAME=&search__ps.FBIRTHDAY=&search__bi.fid_card=340821197912160847%20&search__b.report_date=&search__ps_SERVICE_TIME_startDateValue=&search__ps_SERVICE_TIME_endDateValue=&search__er_COMPLETE_DATE_startDateValue=&search__er_COMPLETE_DATE_endDateValue=&search__complete=&sort=id&dir=DESC";

        public const string sumbitParms = "http://mcm3.pc.e-health.org.cn/entity/exam/editExamResult_abstractList.action?ids=ids11&start=0&limit=20&search__tableType=&search__examineDate=&search__modifyDate=&search__status=&sort=id&dir=DESC";

        public const string submit = "http://mcm3.pc.e-health.org.cn/entity/basic/labExamW_submitWomanClinical.action?labExamId=ids11&psid=ids11";

        public const string submitMen = "http://mcm3.pc.e-health.org.cn/entity/exam/labExamM_submitManClinical.action?labExamId=ids11&psid=ids11";

        
        //public const string submitBC = "http://mcm3.pc.e-health.org.cn/entity/image/bmodResult_saveBmodResult.action?result=不正常&resultDesc=1111&bmid=ff80808154416b140154462682bc2859&techNum=4401110141600101&doctorName=123&reportDate=2017-06-10";
        public const string submitBC = "http://mcm3.pc.e-health.org.cn/entity/image/bmodResult_saveBmodResult.action?bmid=ids11&techNum=serviceCode";

       // public const string submit = "http://mcm3.pc.e-health.org.cn/entity/basic/labExamW_submitWomanClinical.action?labExamId=ids11&psid=ids11&leuClueCell1=1&leuTrichomonas1=&leuAmineOdor1=0&candidiasis=&leuCleanliness1=&wphValue=&gonorrhoeae1=&chlamydiaT1=&whb=&wrbC=&wpbT=&wwbC=&wn=&we=20&wb=&wl=&wm=&urineRoutineM=&abO1=&rh1=&wbloodSugar=&hbs_Ag=&hbs_Ab=&hbe_Ag=&hbe_Ab=&hbc_Ab=&walT=&wcr=&wtsH=&rvigg1=&cvigg1=&tgigg1=&treponema=&cvigm1=&tgigm1=&custom39=&custom43=&custom40=&custom41=&custom42=&custom44=&custom45=&custom46=&custom135=&custom136=&elseItem=&testerName=%E5%B9%BF%E4%B8%9C%E7%9C%81%E5%B9%BF%E5%B7%9E%E5%B8%82%E7%99%BD%E4%BA%91%E5%8C%BA%E7%9F%B3%E4%BA%95%E8%A1%97%E9%81%93&wcheckDate=2017-05-15";

        public const string tableName = "Y_BCJGXX";

        public static string UrlEncode(string temp, Encoding encoding)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                string t = temp[i].ToString();
                string k = HttpUtility.UrlEncode(t, encoding);
                if (t == k)
                {
                    stringBuilder.Append(t);
                }
                else
                {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }
    }
}
