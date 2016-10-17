using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo1.DAL;
using demo1.Model;
using System.Data;
using System.ComponentModel;
using demo1.Common;

namespace demo1.Controllers
{
    
    [GnAtr("角色管理", "1.0", false)]
    public class JsController : BaseController
    {

        IDAL<Model.js> dal = new DAL.js();

        [GnAtr("查看", "1.0", false)]
        public ActionResult List()
        {

            //DAL.js jsdal = dal as DAL.js;

            List<Model.js> jss = new List<Model.js>();

            DataSet ds = dal.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    Model.js js = dal.DataRowToModel(dr);
                    jss.Add(js);
                }
            }
            return View(jss);
        }

        [GnAtr("添加", "1.0", true)]
        public ActionResult Add()
        {
            return View();
        }

        [GnAtr("添加", "1.0", false)]
        [HttpPost]
        public ActionResult Add(Model.js model)
        {
            ViewModels.Message b = new ViewModels.Message();
            if (ModelState.IsValid)
            {
                if (dal.Add(model) > 0)
                {
                    b.sno = 1;
                }
                else
                {
                    b.sno = 3;
                    b.msg = "数据操作失败";
                }
            }
            else
            {
                b.sno = 2;
                b.msg = "数据校验失败";
            }

            return Json(b, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 校验角色名称是否已经存在
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateJsmc(string jsmc)
        {
            DAL.js jsdal = dal as DAL.js;

            if (jsdal.Exists(jsmc))
            {
                return Content("false");
            }
            else
            {
                return Content("true");
            }
        }

        [GnAtr("修改", "1.0", true)]
        public ActionResult Edit(int jsid)
        {
            ViewModels.JsEditDTO jseditdto = new ViewModels.JsEditDTO();
            //基本信息
            Model.js js = dal.GetModel(jsid);
            //角色权限信息
            BLL.Jsbll jsbll = new BLL.Jsbll();
            List<ViewModels.JsgnDTO> jsgns = jsbll.getJsgnDTO(jsid);

            jseditdto.js = js;
            jseditdto.jsgns = jsgns;

            return View(jseditdto);
        }

        [GnAtr("修改", "1.0", false)]
        [HttpPost]
        public ActionResult Edit(Model.js js)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            if (dal.Update(js))
            {
                rsp.sno = 1;
            }
            else
            {
                rsp.sno = 2;
                rsp.msg = "数据操作失败";
            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }

        [GnAtr("修改角色功能", "1.0", false)]
        [HttpPost]
        public ActionResult JsgnEdit(int jsid,string gnids)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            DAL.jsgn jsgndal = new DAL.jsgn();
            if (jsid > 0)
            {
                //先删除角色所有权限
                if (jsgndal.deleteByJsid(jsid))
                {
                    if (!string.IsNullOrEmpty(gnids))
                    {
                        //添加功能
                        string[] gnidArr = gnids.Split('#');
                        foreach (string gnid in gnidArr)
                        {
                            jsgndal.Add(new Model.jsgn { jsid = jsid, gnid = Convert.ToInt32(gnid) });
                        }
                    }
                    rsp.sno = 1;
                }
                else
                {
                    rsp.sno = 2;
                    rsp.msg = "数据操作失败";
                }
            }
            else
            {
                rsp.sno = 2;
                rsp.msg = "未指定操作角色";
            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }
    }
}