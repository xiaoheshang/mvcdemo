using demo1.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demo1.BLL
{
    public class Yhbll
    {
        
        //获取用户功能
        //返回易绑定的格式
        public List<ViewModels.YhgnDTO> getYhgnDTO(int yhid)
        {
            //返回易绑定的格式
            List<ViewModels.YhgnDTO> yhgndtos = new List<ViewModels.YhgnDTO>();

            //获取系统所有功能(去除公共功能）
            List<Model.gn> gns = new List<Model.gn>();
            DAL.gn gndal = new DAL.gn();
            DataSet ds=gndal.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {

                    Model.gn gn=gndal.DataRowToModel(dr);
                    if (!gn.ispublic)
                    {
                        gns.Add(gn);
                    }
                }
            }

            //获取用户拥有的功能权限
            DAL.yhgn yhgndal = new DAL.yhgn();
            List<Model.yhgn> yhgns = yhgndal.getGnsByYhid(yhid);


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
            foreach(var item in query)
            {
                ViewModels.YhgnDTO yhgndto = new ViewModels.YhgnDTO();
                yhgndto.controller = item.c;
                yhgndto.controllername = item.cn;

                foreach(var action in item.actions)
                {
                    ViewModels.YhAction yhaction = new ViewModels.YhAction
                    {
                        gnid = action.gnid,
                        action = action.action,
                        actionname = action.actionname
                    };

                    //绑定用户是否拥有该功能
                    if (yhgns.FindAll(b => b.gnid == action.gnid).Count>0)
                    {
                        yhaction.isallow = true;
                    }

                    yhgndto.actions.Add(yhaction);
                    
                }
                yhgndtos.Add(yhgndto);
            }

            return yhgndtos;
        }

        /// <summary>
        /// 获取用户所属角色
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        public List<ViewModels.YhjsDTO> getYhjsDTO(int yhid)
        {
            List<ViewModels.YhjsDTO> yhjsdtos = new List<ViewModels.YhjsDTO>();
            //获取系统所有角色信息
            DAL.js jsdal = new DAL.js();
            List<Model.js> jss = new List<Model.js>();
             DataSet ds= jsdal.GetList("");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    jss.Add(jsdal.DataRowToModel(dr));
                }
            }

            //获取用户所属角色列表
            DAL.yhjs yhjsdal = new DAL.yhjs();
            List<Model.yhjs> yhjss = yhjsdal.getYhjssByyhid(yhid) ;

            foreach(Model.js js in jss)
            {
                ViewModels.YhjsDTO yhjsdto = new ViewModels.YhjsDTO
                {
                    jsid = js.jsid,
                    jsmc = js.jsmc,
                    jssm = js.jssm
                };

                if (yhjss.FindAll(b => b.jsid == js.jsid).Count > 0)
                {
                    yhjsdto.isjs = true;
                }

                yhjsdtos.Add(yhjsdto);
            }
            return yhjsdtos;
        }
    }
}