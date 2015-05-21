using CIFR.DAL;
using CIFR.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CIFR.Web
{
    public static class HtmlHelpers
    {
  

        public static string GetGender(this HtmlHelper helper, int? sex)
        {
            string gender = string.Empty;
            switch (sex)
            {
                case 1:
                    gender = "男";
                    break;
                case 0:
                    gender = "女";
                    break;
                default:
                    gender = "不详";
                    break;
            }
            return gender;
        }

  
        /// <summary> 
        /// 截取指定字节长度的字符串
        /// </summary> 
        ///  <param name="str">原字符串</param>
        ///  <param name="len">截取字节长度</param> 
        ///  <returns></returns>  
        public static string CutByteString(this HtmlHelper helper, string str, int len, int type = 0)
        {
            string result = string.Empty;
            // 最终返回的结果
            if (string.IsNullOrEmpty(str))
            { return result; }

            int byteLen = System.Text.Encoding.Default.GetByteCount(str);
            // 单字节字符长度
            int charLen = str.Length;
            // 把字符平等对待时的字符串长度 
            int byteCount = 0;
            // 记录读取进度 
            int pos = 0;
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)
                    // 按中文字符计算加2
                    { byteCount += 2; }
                    else
                    // 按英文字符计算加1 
                    { byteCount += 1; }
                    if (byteCount > len)
                    // 超出时只记下上一个有效位置
                    { pos = i; break; }
                    else if (byteCount == len)
                    // 记下当前位置 
                    { pos = i + 1; break; }
                }
                if (pos >= 0)
                {
                    if (type == 0)
                    {
                        result = str.Substring(0, pos) + "......";
                    }
                    else
                    {
                        result = str.Substring(0, pos);
                    }
                }
            }
            else { result = str; } return result;
        }


        ///   <summary>
        ///   Remove HTML Tag
        ///   </summary>
        ///   <param   name=”NoHTML”> </param>
        ///   <returns></returns>
        public static string FilterHtml(this HtmlHelper helper, string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring))
            {
                return string.Empty;
            }

            //Remove javascript
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
            RegexOptions.IgnoreCase);

            //remove html
            Htmlstring = Regex.Replace(Htmlstring, @"<\\s*img\\s+([^>]*)\\s*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"–>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!–.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Htmlstring.Replace("à", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

    }
}
