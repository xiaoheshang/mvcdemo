using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo1.Common;
using System.ComponentModel;

namespace demo1.Controllers
{
    [GnAtr("测试功能", "1.0", true)]
    public class ManageController : BaseController
    {
        [GnAtr("获取所有Action", "1.0", true)]
        public ActionResult TestGetActionName()
        {
            ActionPermissionService aps = new ActionPermissionService();

            List<Model.gn> gns = aps.GetAllActionByAssembly() as List<Model.gn>;

            return View(gns);
        }



        public ActionResult TestMenu()
        {

            return View();
        }

    }
}