using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo1.DAL;
using demo1.Model;
using System.Data;
using demo1.Common;

namespace demo1.Controllers
{
    [GnAtr("功能管理", "1.0", false)]
    public class GnController : BaseController
    {

        IDAL<Model.gn> dal = new DAL.gn();

        [GnAtr("初始化功能", "1.0", false)]
        public ActionResult Init()
        {
            

            
            DAL.gn gndal = dal as DAL.gn;

            //清空现有功能表
            gndal.DeleteAll();

            //利用反射获取程序功能写入到t_gn表中
            ActionPermissionService aps = new ActionPermissionService();
            IList<Model.gn> gns = aps.GetAllActionByAssembly();

            foreach(Model.gn gn in gns)
            {
                gndal.Add(gn);
            }
            return Json(new ViewModels.Message { sno = 1, msg = "" });
        }


        [GnAtr("查看", "1.0", false)]
        public ActionResult List()
        {
            List<Model.gn> gns = new List<Model.gn>();
            DAL.gn gndal = dal as DAL.gn;
            if (gndal != null)
            {
                
                DataSet ds = gndal.GetList("");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Model.gn gn = gndal.DataRowToModel(dr);

                        gns.Add(gn);
                    }
                }
            }
            return View(gns);
        }

        /// <summary>
        /// 获取controller列表
        /// </summary>
        /// <returns></returns>
        [GnAtr("获取controller列表","1.0", true)]
        public ActionResult ControllerList()
        {
            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();

            BLL.Gnbll gnbll = new BLL.Gnbll();

            kvs = gnbll.getControllers();

            return Json(kvs, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取Action列表
        /// </summary>
        /// <returns></returns>
        [GnAtr("获取action列表", "1.0", true)]
        public ActionResult ActionList(string ctrl)
        {
            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();
            BLL.Gnbll gnbll = new BLL.Gnbll();

            kvs = gnbll.getActionByController(ctrl);
            return Json(kvs, JsonRequestBehavior.AllowGet);
        }
    }
}