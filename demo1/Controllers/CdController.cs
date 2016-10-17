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
    [GnAtr("菜单管理", "1.0", false)]
    public class CdController : BaseController
    {
        [GnAtr("查看", "1.0", false)]
        public ActionResult List(int cdjb=0)
        {
            DAL.cd cddal = new DAL.cd();
            List<Model.cd> cds = cddal.getModelList("");
            if (cdjb > 0)
            {
                ViewBag.cdjb = cdjb;
                cds = cds.Where(b => b.cdjb == cdjb).ToList();
            }
            return View(cds);
        }

        [GnAtr("添加", "1.0", true)]
        public ActionResult Add()
        {
            return View();
        }

        [GnAtr("添加", "1.0", false)]
        [HttpPost]
        public ActionResult Add(ViewModels.CdAddDTO model)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            DAL.cd cddal = new DAL.cd();
            Model.cd cdmodel = new Model.cd();

            //cdmodel.gnid = gnmodel.gnid;
            cdmodel.cdjb = model.cdjb;
            cdmodel.xtid = model.xtid;
            cdmodel.sjcdid = model.sjcdid;
            cdmodel.cdmc = model.cdmc;
            cdmodel.xsjb = model.xsjb;
            cdmodel.bhcdgn = model.bhcdgn;
            cdmodel.icon = model.icon;
            cdmodel.dkfs = model.dkfs;

            if (model.cdjb == 3)
            {
                BLL.Gnbll gnbll = new BLL.Gnbll();
                Model.gn gnmodel = gnbll.getGnModelByName(model.controller, model.action);
                cdmodel.gnid = gnmodel.gnid;
            }

            if (cddal.Add(cdmodel) > 0)
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

        [GnAtr("获取上级菜单", "1.0", true)]
        public ActionResult GetParentCds(int cdjb)
        {
            DAL.cd cddal = new DAL.cd();
            int parentCdjb = cdjb - 1;
            List<Model.cd> cds = cddal.getCdsBycdjb(parentCdjb);

            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();
            foreach(var item in cds)
            {
                kvs.Add(new ViewModels.KeyValueDTO
                {
                    key = item.cdid.ToString(),
                    value = item.cdmc
                });
            }

            return Json(kvs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCdByXtid(int xtid)
        {
            DAL.cd cddal = new DAL.cd();
            List<Model.cd> cds = cddal.getCdByParentid(xtid);
            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();
            foreach (var item in cds)
            {
                kvs.Add(new ViewModels.KeyValueDTO
                {
                    key = item.cdid.ToString(),
                    value = item.cdmc
                });
            }
            return Json(kvs, JsonRequestBehavior.AllowGet);
        }
        
        
    }
}