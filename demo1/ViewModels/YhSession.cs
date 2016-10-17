using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    public class YhSession
    {
        //登录用户基本信息
        public Model.yh yh { get; set; }
        //用户所拥有的菜单
        public List<Model.cd> cds { get; set; }
        //当前系统id
        public int currentXtid { get; set; }
    }
}