using demo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Common.MenuHelper
{
    public static class MenuHelper
    {
        
        public static string GetMenuHtml(this HtmlHelper helper,string menuName)
        {
            HtmlBuilder builder = new HtmlBuilder(helper);
            //获取菜单数据
            MenuViewModel<Model.cd> model = CreatMenuModel(menuName);
            builder.buildTreeStruct(model);
            return builder.Build();
        }

        public static MenuViewModel<Model.cd> CreatMenuModel(string menuName)
        {
            MenuViewModel<Model.cd> model = new MenuViewModel<Model.cd>();
            //获取当前登录用户信息
            HttpContext context = HttpContext.Current;
            YhSession yhsession = context.Session["yhsession"] as ViewModels.YhSession;
            if (yhsession != null)
            {
                //获取用户有权限的菜单
                List<Model.cd> authCds = getAuthCd(yhsession);
                //获取显示级别==1的菜单
                //DAL.cd cddal = new DAL.cd();
                //获取根菜单（即系统）  目前获取固定系统的菜单，到后面通过登录用户选择的系统获取选择的系统菜单
                //IEnumerable<Model.cd> cds = cddal.getModelList("xsjb=1 and xtid=8");
                IEnumerable<Model.cd> cds = authCds.FindAll(b => b.xsjb == 1 && b.xtid==yhsession.currentXtid);
                if (cds.Count()>0)
                {
                    foreach(Model.cd item in cds)
                    {
                        //获取子菜单
                        //IEnumerable<Model.cd> menus = cddal.getModelList("sjcdid=" + item.cdid);
                        IEnumerable<Model.cd> menus = authCds.FindAll(b => b.sjcdid == item.cdid);
                        foreach (var ii in menus)
                        {
                            item.MenuChildren.Add(ii);
                            AddChildNode(ii,authCds);
                        }
                    }
                }
                model.MenuItems = cds.ToList();
            }

            //model就是菜单树
            return model;
        }

        /// <summary>
        /// 递归获取下级菜单
        /// </summary>
        /// <param name="menu"></param>
        public static void AddChildNode(Model.cd menu,List<Model.cd> authCds)
        {
            //DAL.cd cddal = new DAL.cd();
            //var menus = cddal.getModelList("sjcdid=" + menu.cdid);
            var menus = authCds.FindAll(b => b.sjcdid == menu.cdid);
            foreach(var item in menus)
            {
                menu.MenuChildren.Add(item);
                AddChildNode(item,authCds);
            }
        }

        /// <summary>
        /// 获取用户有权限的菜单
        /// </summary>
        /// <param name="yhsession"></param>
        /// <returns></returns>
        public static List<Model.cd> getAuthCd(YhSession yhsession)
        {
            DAL.gn gndal = new DAL.gn();
            //获取用户有权限的功能
            int[] gnids = gndal.getGnidsByYhmc(yhsession.yh.yhmc);
            //string gnidsStr = String.Join(",", gnids);
            List<int> gnidList = gnids.ToList();
            //通过用户有权限的功能得到用户有权限的菜单
            DAL.cd cddal = new DAL.cd();
            //List<Model.cd> cds = cddal.getModelList(" gnid in(" + gnidsStr + ")");
            List<Model.cd> cds = cddal.getModelList("");

            List<Model.cd> yhcds = cds.FindAll(delegate (Model.cd cd)
            {
                if (cd.gnid.HasValue)
                {
                    return gnidList.Contains(cd.gnid.Value);
                }
                else
                {
                    return false;
                }
            });
            //获取上级菜单并添加菜单记录
            List<Model.cd> x1 = cds.FindAll(delegate (Model.cd cd)
              {
                  return yhcds.FindAll(b => b.sjcdid == cd.cdid).Count > 0;
              });
            yhcds.AddRange(x1);


            return yhcds;
        }
    }
}