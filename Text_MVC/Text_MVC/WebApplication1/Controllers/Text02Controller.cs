using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class Text02Controller : Controller
    {
        public ActionResult Index()
        {
            DBtext DBtext = new DBtext();
            List<DBconnTest> DBconnTests = DBtext.GetCards();
            ViewBag.DBconnTests = DBconnTests;

            return View();
        }
    }
}