using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    public class YhjsDTO
    {
        public int jsid { get; set; }
        public string jsmc { get; set; }
        public string jssm { get; set; }
        /// <summary>
        /// 用户是否属于角色
        /// </summary>
        public bool isjs { get; set; }
    }
}