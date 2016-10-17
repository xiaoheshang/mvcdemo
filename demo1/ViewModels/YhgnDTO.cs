using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    public class YhgnDTO
    {
        public YhgnDTO()
        {
            this.actions = new List<YhAction>();
        }
        public string controller { get; set; }
        public string controllername { get; set; }
        public List<YhAction> actions { get; set; }
    }

    public class YhAction
    {
        public int gnid { get; set; }
        public string action { get; set; }
        public string actionname { get; set; }
        public bool isallow { get; set; }
    }
}