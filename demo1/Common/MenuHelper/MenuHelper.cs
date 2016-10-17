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
            
            //获取显示级别==1的菜单
            DAL.cd cddal = new DAL.cd();
            //获取根菜单（即系统）  目前获取固定系统的菜单，到后面通过登录用户选择的系统获取选择的系统菜单
            //Model.cd xtcd = cddal.getModelList("cdjb=1").FirstOrDefault();
            IEnumerable<Model.cd> cds = cddal.getModelList("xsjb=1 and xtid=8");
            if (cds.Count()>0)
            {
                foreach(Model.cd item in cds)
                {
                    //获取子菜单
                    IEnumerable<Model.cd> menus = cddal.getModelList("sjcdid=" + item.cdid);

                    foreach (var ii in menus)
                    {
                        item.MenuChildren.Add(ii);
                        AddChildNode(ii);
                    }
                }
                

            }

            model.MenuItems = cds.ToList();
            //model就是菜单树
            return model;
        }

        /// <summary>
        /// 递归获取下级菜单
        /// </summary>
        /// <param name="menu"></param>
        public static void AddChildNode(Model.cd menu)
        {
            DAL.cd cddal = new DAL.cd();
            var menus = cddal.getModelList("sjcdid=" + menu.cdid);
            foreach(var item in menus)
            {
                menu.MenuChildren.Add(item);
                AddChildNode(item);
            }
        }

    }
}