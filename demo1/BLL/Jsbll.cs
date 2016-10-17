using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace demo1.BLL
{
    public class Jsbll
    {
        //获取角色功能
        //返回易绑定的格式
        public List<ViewModels.JsgnDTO> getJsgnDTO(int jsid)
        {
            //返回易绑定的格式
            List<ViewModels.JsgnDTO> jsgndtos = new List<ViewModels.JsgnDTO>();

            //获取系统所有功能(去除公共功能）
            List<Model.gn> gns = new List<Model.gn>();
            DAL.gn gndal = new DAL.gn();
            DataSet ds = gndal.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    Model.gn gn = gndal.DataRowToModel(dr);
                    if (!gn.ispublic)
                    {
                        gns.Add(gn);
                    }
                }
            }

            //获取角色拥有的功能权限
            DAL.jsgn jsgndal = new DAL.jsgn();
            List<Model.jsgn> jsgns = jsgndal.getGnsByJsid(jsid);


            var query = from r in gns
                        orderby r.controller
                        group r by new { c = r.controller, cn = r.controllername } into g
                        select new
                        {
                            g.Key.c,
                            g.Key.cn,
                            actions = from r1 in g
                                      orderby r1.action
                                      select new
                                      {
                                          r1.gnid,
                                          r1.action,
                                          r1.actionname
                                      }
                        };
            foreach (var item in query)
            {
                ViewModels.JsgnDTO jsgndto = new ViewModels.JsgnDTO();
                jsgndto.controller = item.c;
                jsgndto.controllername = item.cn;

                foreach (var action in item.actions)
                {
                    ViewModels.JsAction jsaction = new ViewModels.JsAction
                    {
                        gnid = action.gnid,
                        action = action.action,
                        actionname = action.actionname
                    };

                    //绑定角色是否拥有该功能
                    if (jsgns.FindAll(b => b.gnid == action.gnid).Count > 0)
                    {
                        jsaction.isallow = true;
                    }

                    jsgndto.actions.Add(jsaction);

                }
                jsgndtos.Add(jsgndto);
            }

            return jsgndtos;
        }
    }
}