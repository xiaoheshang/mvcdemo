using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormValidate.Models;
using System.Text.RegularExpressions;

namespace FormValidate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student model)
        {
            //手动验证方法
            if (string.IsNullOrEmpty(model.name))
            {
                ModelState.AddModelError("name", "姓名不能为空");
            }

            if (string.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("email", "邮箱不能为空");
            }
            else
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.email))
                {
                    ModelState.AddModelError("email", "邮箱格式不正确");
                }
            }

            if (ModelState.IsValid)
            {
                ViewBag.Name = model.name;
                ViewBag.Email = model.email;
            }

            return View(model);
        }

        public ActionResult DataAnnotation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataAnnotation(Student2 model)
        {
            //数据注解方式
            if (ModelState.IsValid)
            {
                ViewBag.name = model.name;
                ViewBag.email = model.email;
            }
            return View();
        }
    }
}