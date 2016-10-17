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
using System.Web.Security;

namespace demo1.Controllers
{
    [GnAtr("用户管理","1.0",false)]
    public class YhController : BaseController
    {
        IDAL<Model.yh> dal = new DAL.yh();

        [GnAtr("管理主页面", "1.0", false)]
        public ActionResult Index()
        {
            return View();
        }

        [GnAtr("查看", "1.0", false)]
        public ActionResult List()
        {
            //返回系统用户列表
            DataSet ds = dal.GetList("");
            List<Model.yh> yhs = new List<Model.yh>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.yh yh = dal.DataRowToModel(dr);
                yhs.Add(yh);
            }
            return View(yhs);
            
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="yh"></param>
        /// <returns></returns>
        [GnAtr("添加", "1.0", true)]
        public ActionResult Add()
        {
            return View();
        }

        [GnAtr("添加", "1.0", false)]
        [HttpPost]
        public ActionResult Add(Model.yh yh)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            if (yh == null)
            {
                rsp.sno = 0;
                rsp.msg = "未输入用户信息";
            }

            else
            {
                yh.yhmm = Utils.MD5(yh.yhmm);
                if (dal.Add(yh) > 0)
                {
                    rsp.sno = 1;
                    rsp.msg = "成功";
                }
                else
                {
                    rsp.sno = 0;
                    rsp.msg = "数据操作失败";
                }
                
            }
            return Json(rsp,JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        [GnAtr("编辑", "1.0", true)]
        public ActionResult Edit(int yhid)
        {

            ViewModels.YhEditDTO yheditdto = new ViewModels.YhEditDTO();

            Model.yh yh = dal.GetModel(yhid);
            //用户功能
            BLL.Yhbll yhbll = new BLL.Yhbll();
            List<ViewModels.YhgnDTO> yhgns = yhbll.getYhgnDTO(yhid);
            //用户角色
            List<ViewModels.YhjsDTO> yhjss = yhbll.getYhjsDTO(yhid);
            yheditdto.yh = yh;
            yheditdto.yhgns = yhgns;
            yheditdto.yhjss = yhjss;

            return View(yheditdto);
        }

        [GnAtr("编辑", "1.0", false)]
        [HttpPost]
        public ActionResult Edit(Model.yh yh)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            if (yh == null)
            {
                rsp.sno = 0;
                rsp.msg = "未输入用户信息";
            }

            else
            {
                yh.yhmm = Utils.MD5(yh.yhmm);
                if (dal.Update(yh))
                {
                    rsp.sno = 1;
                    rsp.msg = "成功";
                }
                else
                {
                    rsp.sno = 0;
                    rsp.msg = "数据操作失败";
                }

            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }

        [GnAtr("修改用户权限", "1.0", false)]
        [HttpPost]
        public ActionResult YhgnEdit(int yhid=0,string gnids="")
        {
            ViewModels.Message rsp = new ViewModels.Message();
            DAL.yhgn yhgndal = new DAL.yhgn();
            if (yhid>0)
            {
                //先删除用户所有权限
                if (yhgndal.deleteByYhid(yhid))
                {
                    if (!string.IsNullOrEmpty(gnids))
                    {
                        //添加功能
                        string[] gnidArr = gnids.Split('#');
                        foreach(string gnid in gnidArr)
                        {
                            yhgndal.Add(new Model.yhgn { yhid = yhid, gnid = Convert.ToInt32(gnid) });
                        }
                    }
                    rsp.sno = 1;
                }
                else
                {
                    rsp.sno = 2;
                    rsp.msg = "数据操作失败";
                }
            }else
            {
                rsp.sno = 2;
                rsp.msg = "未指定操作用户";
            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }

        [GnAtr("修改用户所属角色", "1.0", false)]
        [HttpPost]
        public ActionResult YhjsEdit(int yhid = 0,string jsids="")
        {
            ViewModels.Message rsp = new ViewModels.Message();
            DAL.yhjs yhjsdal = new DAL.yhjs();
            if (yhid > 0)
            {
                //先删除用户所属角色
                if (yhjsdal.deleteByYhid(yhid))
                {
                    if (!string.IsNullOrEmpty(jsids))
                    {
                        //添加功能
                        string[] jsidArr = jsids.Split('#');
                        foreach (string jsid in jsidArr)
                        {
                            yhjsdal.Add(new Model.yhjs { yhid = yhid, jsid = Convert.ToInt32(jsid) });
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
                rsp.msg = "未指定操作用户";
            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        [GnAtr("删除", "1.0", false)]
        [HttpPost]
        public ActionResult Delete(int yhid)
        {
            ViewModels.Message rsp = new ViewModels.Message();
            if (dal.Delete(yhid))
            {
                rsp.sno = 1;
                rsp.msg = "成功";
            }
            else
            {
                rsp.sno = 0;
                rsp.msg = "数据操作失败";
            }
            return Json(rsp, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 校验用户名是否存在
        /// </summary>
        /// <returns></returns>
        [GnAtr("校验用户名是否已经存在", "1.0", true)]
        public ActionResult ValidateYhmc(string yhmc)
        {
            if (!string.IsNullOrEmpty(yhmc))
            {
                try
                {
                    DAL.yh yhdal = dal as DAL.yh;
                    if (yhdal.Exists(yhmc))
                    {
                        return Content("false");
                    }
                    else
                    {
                        return Content("true");
                    }
                }
                catch
                {
                    return Content("false");
                }
            }
            else
            {
                return Content("false");
            }
        }

        /// <summary>
        /// 获取用户功能列表
        /// </summary>
        /// <returns></returns>
        public ActionResult YhGnList()
        {
            int yhid = 1;//要从用户登录信息中获取

            BLL.Yhbll yhbll = new BLL.Yhbll();
            //List<Model.gn> gns = yhbll.getGnsByYhid(yhid);
            return View();
        }

        /// <summary>
        /// 重置用户功能列表
        /// </summary>
        /// <param name="gnids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult YhGnList(int[] gnids)
        {
            ViewModels.Message b = new ViewModels.Message();

            int yhid = 1;//要从用户登录信息中获取
            DAL.yhgn yhgndal = new DAL.yhgn();
            foreach(int gnid in gnids)
            {
                yhgndal.Add(new Model.yhgn { yhid = yhid, gnid = gnid });
            }
            b.sno = 1;
            return Json(b, JsonRequestBehavior.DenyGet);
        }
    }
}