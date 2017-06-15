using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Doctor
{
    class DataConvertWomen
    {
        private static DataConvertWomen dataConvert = null;
        public static Dictionary<string, Dictionary<string, string>> women = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> womenType = new Dictionary<string, string>();

        private DataConvertWomen() {
            init();
        }

        private void init()
        {
            Dictionary<string, string> type1 = new Dictionary<string, string> ();
            type1.Add("阴性","0");
            type1.Add("阳性", "1");
            type1.Add("可疑", "9");

            Dictionary<string, string> type2 = new Dictionary<string, string>();
            //type2.add("i", "0");
           // type2.add("ii", "1");
           // type2.add("iii", "2");
           // type2.add("iv", "3");
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
            type6.Add("阴性", "1");
            type6.Add("阳性", "0");

            women.Add("leuClueCell1", type1);              //线索细胞
            women.Add("candidiasis", type1);              //念珠菌
            women.Add("leuTrichomonas1", type1);          //滴虫
            women.Add("leuCleanliness1", type2);          //清洁度
            women.Add("leuAmineOdor1", type1);            //胺臭味
            women.Add("wphValue", type3);                 //PH值
            women.Add("gonorrhoeae1", type1);             //淋球菌
            women.Add("chlamydiaT1", type1);              //沙眼衣原体
            women.Add("whb", null);                      //hb
            women.Add("wrbC", null);                     //rbc
            women.Add("wpbT", null);                     //plt
            women.Add("wwbC", null);                     //wbc
            women.Add("we", null);                       //   比值E
            women.Add("wb", null);                       //   比值B
            women.Add("wm", null);                       //   比值M
            women.Add("wn", null);                       //   比值N
            women.Add("wl", null);                       //   比值L
            women.Add("urineRoutineM", type4);            //尿常规检验
            women.Add("urineRoutineDescribe", null);     //尿常规异常结果
            women.Add("abO1", type5);                     //abo
            women.Add("rh1", type6);                      //rh
            women.Add("wbloodSugar", null);              //血糖
            women.Add("hbs_Ag", type1);                   //hbsag
            women.Add("hbs_Ab", type1);                   //hbsab
            women.Add("hbe_Ag", type1);                   //hbeag
            women.Add("hbe_Ab", type1);                   //hbeab
            women.Add("hbc_Ab", type1);                   //hbcab
            women.Add("walT", null);                     //谷丙转氨酶
            women.Add("wcr", null);                      //肌酐
            women.Add("wtsH", null);                     //促甲状腺
            women.Add("rvigg1", type1);                   //风疹IgG
            women.Add("cvigg1", type1);                   //巨细胞IgG
            women.Add("cvigm1", type1);                   //巨细胞IgM
            women.Add("tgigg1", type1);                   //弓形虫IgG
            women.Add("tgigm1", type1);                   //弓形虫IgM
            women.Add("treponema", type1);                //梅毒螺旋筛查
            women.Add("custom39", null);                 //MCV
            women.Add("custom43", null);                 //MCH
            women.Add("custom135", null);                //G6PD比值
            women.Add("custom136", null);                //G6PD酶活性测定
            women.Add("elseItem", null);                 //其它检查
            women.Add("testerName", null);               //医师签名
            women.Add("wcheckDate", null);               //检查日期

            women.Add("custom45", null);
            women.Add("custom44", null);
            women.Add("custom46", null);
            women.Add("custom137", null);
            women.Add("custom143", null);  


            womenType.Add("线索细胞", "leuClueCell1");              //线索细胞
            womenType.Add("念珠菌", "candidiasis");              //念珠菌
            womenType.Add("滴虫", "leuTrichomonas1");          //滴虫
            womenType.Add("清洁度", "leuCleanliness1");          //清洁度
            womenType.Add("胺臭味", "leuAmineOdor1");            //胺臭味
            womenType.Add("PH值", "wphValue");                 //PH值
            womenType.Add("淋球菌", "gonorrhoeae1");             //淋球菌
            womenType.Add("沙眼衣原体", "chlamydiaT1");              //沙眼衣原体
            womenType.Add("hb", "whb");                      //hb
            womenType.Add("rbc", "wrbC");                     //rbc
            womenType.Add("plt", "wpbT");                     //plt
            womenType.Add("wbc", "wwbC");                     //wbc
            womenType.Add("比值E", "we");                       //   比值E
            womenType.Add("比值B", "wb");                       //   比值B
            womenType.Add("比值M", "wm");                       //   比值M
            womenType.Add("比值N", "wn");                       //   比值N
            womenType.Add("比值L", "wl");                       //   比值L
            womenType.Add("尿常规检验", "urineRoutineM");            //尿常规检验
            womenType.Add("尿常规异常结果", "urineRoutineDescribe");     //尿常规异常结果
            womenType.Add("abo", "abO1");                     //abo
            womenType.Add("rh", "rh1");                      //rh
            womenType.Add("血糖", "wbloodSugar");              //血糖
            womenType.Add("hbsag", "hbs_Ag");                   //hbsag
            womenType.Add("hbsab", "hbs_Ab");                   //hbsab
            womenType.Add("hbeag", "hbe_Ag");                   //hbeag
            womenType.Add("hbeab", "hbe_Ab");                   //hbeab
            womenType.Add("hbcab", "hbc_Ab");                   //hbcab
            womenType.Add("谷丙转氨酶", "walT");                     //谷丙转氨酶
            womenType.Add("肌酐", "wcr");                      //肌酐
            womenType.Add("促甲状腺", "wtsH");                     //促甲状腺
            womenType.Add("风疹IgG", "rvigg1");                   //风疹IgG
            womenType.Add("巨细胞IgG", "cvigg1");                   //巨细胞IgG
            womenType.Add("巨细胞IgM", "cvigm1");                   //巨细胞IgM
            womenType.Add("弓形虫IgG", "tgigg1");                   //弓形虫IgG
            womenType.Add("弓形虫IgM", "tgigm1");                   //弓形虫IgM
            womenType.Add("梅毒螺旋筛查", "treponema");                //梅毒螺旋筛查
            womenType.Add("MCV", "custom39");                 //MCV
            womenType.Add("MCH", "custom43");                 //MCH
            womenType.Add("G6PD比值", "custom135");                //G6PD比值
            womenType.Add("G6PD酶活性测定", "custom136");                //G6PD酶活性测定
            womenType.Add("其它检查", "elseItem");                 //其它检查
            womenType.Add("医师签名", "testerName");               //医师签名
            womenType.Add("检查日期", "wcheckDate");               //检查日期

            womenType.Add("HBA","custom45" );
            womenType.Add("HBA2","custom44");
            womenType.Add("HBF","custom46");
            womenType.Add("G6PD","custom137" );
            womenType.Add( "HIV","custom143"); 

            
        }

        public static DataConvertWomen getInstance() {
            if (dataConvert == null) {
                dataConvert = new DataConvertWomen();
            }
            return dataConvert;
        }

        public string ConvertDataForWomen(Dictionary<string, string> data,string id) {
            string url = SysConstUrl.submit.Replace("ids11", id);

            foreach (string key in data.Keys) { 
                string temp = "&"+key+"=";
                string value = data[key];
                if (women.ContainsKey(key) && women[key] != null) {
                    if (women[key].ContainsKey(data[key])) {
                        value = women[key][data[key]];
                        //value = System.Web.HttpUtility.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                    } 
                }
                if (hasChinese(value) || key == "urineRoutineDescribe" || key == "testerName")
                {
                    value = SysConstUrl.UrlEncode(value, Encoding.GetEncoding("utf-8"));
                }
                if (key == "wcheckDate") {
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
            //return !Regex.IsMatch(CString, @"^[a-zA-Z0-9]*$"); 
        }

    }
}
