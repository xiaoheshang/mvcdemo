using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace demo1.BLL
{
    public class Gnbll
    {
        /// <summary>
        /// 获取controller列表
        /// </summary>
        /// <returns></returns>
        public List<ViewModels.KeyValueDTO> getControllers()
        {
            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();

            DAL.gn gndal = new DAL.gn();

            List<Model.gn> gns = gndal.getModelList("");

            var query = from r in gns
                        where r.islock==false
                        where r.ispublic==false
                        orderby r.controller
                        group r by new { c = r.controller, cn = r.controllername } into g
                        select new
                        {
                            g.Key.c,
                            g.Key.cn
                        };
            foreach(var item in query)
            {
                kvs.Add(new ViewModels.KeyValueDTO
                {
                    key = item.c,
                    value = item.cn
                });
            }

            return kvs;
        }
        /// <summary>
        /// 通过controller获取aciton列表
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public List<ViewModels.KeyValueDTO> getActionByController(string controller)
        {
            List<ViewModels.KeyValueDTO> kvs = new List<ViewModels.KeyValueDTO>();
            DAL.gn gndal = new DAL.gn();
            List<Model.gn> gns = gndal.getModelList("");
            var query = gns.Where(b => b.controller == controller).Where(b => b.ispublic == false).Where(b => b.islock==false);
            foreach(var item in query)
            {
                kvs.Add(new ViewModels.KeyValueDTO
                {
                    key = item.action,
                    value = item.actionname
                });
            }
            return kvs;
        }

        /// <summary>
        /// 通过controller,action,method获取功能模型
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public Model.gn getGnModelByName(string controller,string action)
        {
            DAL.gn gndal = new DAL.gn();
            List<Model.gn> gns = gndal.getModelList("");
            return gns.Where(b => (b.controller == controller && b.action==action && b.ispublic==false)).FirstOrDefault();
        }

        /// <summary>
        /// 校验用户权限
        /// </summary>
        /// <param name="yhmc"></param>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool checkYhqx(string yhmc,string ctrl,string action)
        {
            DAL.gn gndal = new DAL.gn();

            int[] gnids = gndal.getGnidsByYhmc(yhmc);

            Model.gn gn = gndal.getModelByName(ctrl, action);

            if (gnids.Contains(gn.gnid))
            {
                return true;
            }

            return false;
        }
        
    }
}