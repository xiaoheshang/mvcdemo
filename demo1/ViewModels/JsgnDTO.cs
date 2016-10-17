using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    /// <summary>
    /// 角色所有功能模型
    /// </summary>
    public class JsgnDTO
    {
        public JsgnDTO()
        {
            this.actions = new List<JsAction>();
        }
        public string controller { get; set; }
        public string controllername { get; set; }
        public List<JsAction> actions { get; set; }
    }

    public class JsAction
    {
        public int gnid { get; set; }
        public string action { get; set; }
        public string actionname { get; set; }
        public bool isallow { get; set; }
    }
}