using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Doctor
{
    class DataConvertMen
    {
        private static DataConvertMen dataConvert = null;
        public static Dictionary<string, Dictionary<string, string>> men = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> menType = new Dictionary<string, string>();

        private DataConvertMen()
        {
            init();
        }

        private void init()
        {
            Dictionary<string, string> type1 = new Dictionary<string, string> ();
            type1.Add("阴性","0");
            type1.Add("阳性", "1");
            type1.Add("可疑", "9");

            Dictionary<string, string> type2 = new Dictionary<string, string>();
            //type2.Add("I", "0");
            //type2.Add("II", "1");
            //type2.Add("III", "2");
            //type2.Add("IV", "3");
            type2.Add("Ⅰ", "0");//Ⅰ
            type2.Add("Ⅱ", "1");//Ⅱ
            type2.Add("Ⅲ", "2");//Ⅲ
            type2.Add("Ⅳ", "3");//Ⅳ


            Dictionary<string, string> type3 = new Dictionary<string, string>();
            type3.Add("<4.5", "0");
            type3.Add(">=4.5", "1");
            type3.Add(">4.5", "1");

            Dictionary<string, string> type4 = new Dictionary<string, string>();
            type4.Add("未见异常", "0");
            type4.Add("异常", "1");
            type4.Add("正常", "0");

            Dictionary<string, string> type5 = new Dictionary<string, string>();
            type5.Add("A", "1");
            type5.Add("B", "2");
            type5.Add("AB", "3");
            type5.Add("O", "4");
            type5.Add("o", "4");

            Dictionary<string, string> type6 = new Dictionary<string, string>();
            type6.Add("阴性", "2");
            type6.Add("阳性", "1");

            //men.Add("leuClueCell1", type1);              //线索细胞
            //men.Add("candidiasis", type1);              //念珠菌
            //men.Add("leuTrichomonas1", type1);          //滴虫
            //men.Add("leuCleanliness1", type2);          //清洁度
            //men.Add("leuAmineOdor1", type1);            //胺臭味
            //men.Add("wphValue", type3);                 //PH值
            //men.Add("gonorrhoeae1", type1);             //淋球菌
            //men.Add("chlamydiaT1", type1);              //沙眼衣原体
            men.Add("custom87", null);                      //hb
            men.Add("custom88", null);                     //rbc
            men.Add("custom89", null);                     //plt
            men.Add("custom90", null);                     //wbc
            men.Add("custom94", null);                       //   比值E
            men.Add("custom95", null);                       //   比值B
            men.Add("custom93", null);                       //   比值M
            men.Add("custom91", null);                       //   比值N
            men.Add("custom92", null);                       //   比值L
            men.Add("urineRoutineM", type4);            //尿常规检验
            men.Add("urineRoutineDescribe", null);     //尿常规异常结果
            men.Add("abOM", type5);                     //abo
            men.Add("rhM", type6);                      //rh
            //men.Add("wbloodSugar", null);              //血糖
            men.Add("agM", type1);                   //hbsag
            men.Add("abM", type1);                   //hbsab
            men.Add("eagM", type1);                   //hbeag
            men.Add("eabM", type1);                   //hbeab
            men.Add("cabM", type1);                   //hbcab
            men.Add("altM", null);                     //谷丙转氨酶
            men.Add("crM", null);                      //肌酐
            //men.Add("wtsH", null);                     //促甲状腺
            //men.Add("rvigg1", type1);                   //风疹IgG
            //men.Add("cvigg1", type1);                   //巨细胞IgG
            //men.Add("cvigm1", type1);                   //巨细胞IgM
            //men.Add("tgigg1", type1);                   //弓形虫IgG
            //men.Add("tgigm1", type1);                   //弓形虫IgM
            men.Add("microSPM", type1);                //梅毒螺旋筛查
            men.Add("custom82", null);                 //MCV
            men.Add("custom86", null);                 //MCH
            men.Add("custom140", null);                //G6PD比值
            men.Add("custom141", null);                //G6PD酶活性测定
            men.Add("elseItem", null);                 //其它检查
            men.Add("testerName", null);               //医师签名
            men.Add("asktimeM", null);               //检查日期

            men.Add("custom97", null);        
            men.Add("custom98", null);        
            men.Add("custom99", null);
            men.Add("custom142", null);       
            men.Add("custom146", null);       
          //  men.Add("custom92", null);      


            menType.Add("hb","custom87");                      //hb
            menType.Add("rbc","custom88");                     //rbc
            menType.Add("plt","custom89");                     //plt
            menType.Add("wbc","custom90");                     //wbc
            menType.Add("比值E","custom94");                       //   比值E
            menType.Add("比值B","custom95");                       //   比值B
            menType.Add("比值M","custom93");                       //   比值M
            menType.Add("比值N","custom91");                       //   比值N
            menType.Add("比值L","custom92");                       //   比值L
            menType.Add("尿常规检验","urineRoutineM");            //尿常规检验
            menType.Add("尿常规异常结果","urineRoutineDescribe");     //尿常规异常结果
            menType.Add( "abo","abOM");                     //abo
            menType.Add("rh","rhM");                      //rh
            menType.Add( "血糖","wbloodSugar");              //血糖
            menType.Add("hbsag","agM" );                   //hbsag
            menType.Add("hbsab","abM" );                   //hbsab
            menType.Add("hbeag","eagM");                   //hbeag
            menType.Add("hbeab","eabM");                   //hbeab
            menType.Add("hbcab","cabM");                   //hbcab
            menType.Add("谷丙转氨酶","altM" );                     //谷丙转氨酶
            menType.Add("肌酐", "crM");
            menType.Add("梅毒螺旋筛查","microSPM" );                //梅毒螺旋筛查
            menType.Add("MCV","custom82" );                 //MCV
            menType.Add("MCH","custom86");                 //MCH
            menType.Add( "G6PD比值","custom140");                //G6PD比值
            menType.Add("G6PD酶活性测定", "custom141");                //G6PD酶活性测定
            menType.Add("其它检查","elseItem" );                 //其它检查
            menType.Add("医师签名","testerName" );               //医师签名
            menType.Add( "检查日期","asktimeM");               //检查日期
            menType.Add("HBA2", "custom97");
            menType.Add("HBA", "custom98");
            menType.Add("HBF", "custom99");
            menType.Add("G6PD", "custom142");
            menType.Add("HIV", "custom146");   
        

            
        }

        public static DataConvertMen getInstance() {
            if (dataConvert == null) {
                dataConvert = new DataConvertMen();
            }
            return dataConvert;
        }

        public string ConvertDataForMen(Dictionary<string, string> data,string id) {
            string url = SysConstUrl.submitMen.Replace("ids11", id);

            foreach (string key in data.Keys) { 
                string temp = "&"+key+"=";
                string value = data[key];
                if (men.ContainsKey(key) && men[key] != null) {
                    if (men[key].ContainsKey(data[key])) {
                        value = men[key][data[key]];
                        //value = System.Web.HttpUtility.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                    } 
                }
                if (hasChinese(value) || key == "urineRoutineDescribe" || key == "testerName")
                {
                    value = SysConstUrl.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                }
                if (key == "asktimeM")
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
