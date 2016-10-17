using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace demo1.Common
{
    public class ActionPermissionService
    {
        public IList<demo1.Model.gn> GetAllActionByAssembly()
        {
            var result = new List<demo1.Model.gn>();

            var types = Assembly.Load("demo1").GetTypes();

            foreach (var type in types)
            {
                if (type.IsClass)
                {
                    if (type.BaseType.Name == "BaseController")//如果是Controller
                    {
                        string actionname = "", actionversion = "1.0";
                        bool actionispublic = false;
                        string controllername = "", controllerversion = "1.0";
                        bool controllerispublic = false;

                        //获取controller信息
                        object[] gnattrs = type.GetCustomAttributes(typeof(GnAtrAttribute), true);
                        if (gnattrs.Length > 0)
                        {
                            GnAtrAttribute gnatr = gnattrs[0] as GnAtrAttribute;
                            controllername = gnatr.name;
                            controllerversion = gnatr.version;
                            controllerispublic = gnatr.ispublic;

                        }
                        //获取action信息
                        var members = type.GetMethods();
                        foreach (var member in members)
                        {
                            if (member.ReturnType.Name == "ActionResult")
                            {
                                object[] deattrs = member.GetCustomAttributes(typeof(GnAtrAttribute), true);
                                if (deattrs.Length > 0)
                                {
                                    GnAtrAttribute deatr = deattrs[0] as GnAtrAttribute;
                                    actionname = deatr.name;
                                    actionversion = deatr.version;
                                    actionispublic = deatr.ispublic;

                                    var ap = new demo1.Model.gn();
                                    ap.action = member.Name;
                                    ap.controller = member.DeclaringType.Name.Substring(0, member.DeclaringType.Name.Length - 10);
                                    ap.actionname = actionname;
                                    ap.controllername = controllername;
                                    ap.version = actionversion;
                                    ap.ispublic = actionispublic;

                                    //action http请求方式
                                    object[] meattrs = member.GetCustomAttributes(typeof(System.Web.Mvc.ActionMethodSelectorAttribute), true);
                                    if (meattrs.Length > 0)
                                    {
                                        if (meattrs[0] is System.Web.Mvc.HttpPostAttribute)
                                        {
                                            ap.method = "POST";
                                        }
                                        else if (meattrs[0] is System.Web.Mvc.HttpPutAttribute)
                                        {
                                            ap.method = "PUT";
                                        }
                                        else if (meattrs[0] is System.Web.Mvc.HttpPatchAttribute)
                                        {
                                            ap.method = "PATCH";
                                        }
                                        else
                                        {
                                            ap.method = "";
                                        }
                                    }
                                    else
                                    {
                                        ap.method = "GET";
                                    }
                                    result.Add(ap);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public IList<demo1.Model.gn> QueryActionPlist(string query, int start, int limit, out long total)
        {
            IList<demo1.Model.gn> allActions = GetAllActionByAssembly();

            total = (from a in allActions
                     where a.action.ToLower().Contains(query.ToLower())
                     select a).Count();

            var result = (from a in allActions
                          where a.action.ToLower().Contains(query.ToLower())
                          select a).Skip(start).Take(limit);

            return new List<demo1.Model.gn>(result);
        }
    }
}