using demo1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace demo1.Controllers
{
    public class PLoginController : Controller
    {

        [GnAtr("登录页面", "1.0", true)]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            //ViewBag.LoginState = "登录前...";
            return View();
        }
        [GnAtr("登录", "1.0", true)]
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            string username = fc["yhmc"];
            string password = fc["yhmm"];
            
            //ViewBa.LgoginState = "登录后:"+username+","+password;
            DAL.yh yhdal = new DAL.yh();
            Model.yh yh = yhdal.GetModelByYhmc(username);
            if (yh != null && yh.yhmm == Utils.MD5(password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                //设置Session
                ViewModels.YhSession yhSession = new ViewModels.YhSession()
                {
                    yh = yh,
                    currentXtid=8
                };
                Session["yhsession"] = yhSession;
                //跳转
                //return RedirectToAction("Index");
                rsp.sno = 1;
            }
            else
            {
                rsp.sno = 2;
                rsp.msg = "用户名或密码错误";
            }

            return Json(rsp, JsonRequestBehavior.DenyGet);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["yhsession"] = null;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}