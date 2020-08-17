using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System.Web;

namespace WebMVC.Controllers
{
    public class Text01Controller : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Message") != null && HttpContext.Session.GetString("mark") != "1")
            {
                TempData["strName"] = HttpContext.Session.GetString("strName");
                TempData["strYear"] = HttpContext.Session.GetString("strYear");
                TempData["strMonth"] = HttpContext.Session.GetString("strMonth");
                TempData["strDay"] = HttpContext.Session.GetString("strDay");
                TempData["Message"] = HttpContext.Session.GetString("Message");
                HttpContext.Session.SetString("mark", "1");

            }
            else
            {
                TempData["strName"] = "";
                TempData["strYear"] = "";
                TempData["strMonth"] = "";
                TempData["strDay"] = "";
                TempData["Message"] = null;
                HttpContext.Session.Clear();

            }

            return View();
        }
        //session 使用參考 => https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/225144/
        public IActionResult Web01(Text01_Web01 text01_Web01)
        {
            var strMessage = "";

            //判斷是否數字            
            int num1;

            if (int.TryParse(text01_Web01.strYear, out num1) == false ||
                int.TryParse(text01_Web01.strMonth, out num1) == false ||
                int.TryParse(text01_Web01.strDay, out num1) == false)
            {
                strMessage = "年、月、日欄位請輸入數字";
            }
            else
            {
                int tmpYear = Int32.Parse(text01_Web01.strYear);
                int tmpMonth = Int32.Parse(text01_Web01.strMonth);
                int tmpDay = Int32.Parse(text01_Web01.strDay);

                //年欄位判斷
                if (tmpYear < 0)
                {
                    strMessage = "年欄位請輸入大於0";
                }
                else {
                    //月欄位判斷
                    if (tmpMonth > 12 || tmpMonth < 1)
                    {
                        strMessage = "月欄位請輸入1~12";
                    }
                    else
                    {
                        int maxDay = DateTime.DaysInMonth(tmpDay, tmpMonth);
                        //日欄位判斷
                        if (tmpDay < 1 || tmpDay > maxDay)
                        {
                            strMessage = "日欄位請輸入1~" + maxDay;
                        }
                    }
                }
            }
            HttpContext.Session.Clear();
            if (strMessage != "")
            {
                HttpContext.Session.SetString("strName", text01_Web01.strName.ToString());//名字
                HttpContext.Session.SetString("strYear", text01_Web01.strYear.ToString());//年
                HttpContext.Session.SetString("strMonth", text01_Web01.strMonth.ToString());//月
                HttpContext.Session.SetString("strDay", text01_Web01.strDay.ToString());//日
                HttpContext.Session.SetString("Message", strMessage);
                Response.Redirect("Index");
            }
            
            return View(text01_Web01);

    }

    }
}