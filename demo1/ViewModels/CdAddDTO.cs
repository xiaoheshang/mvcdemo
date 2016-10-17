using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    /// <summary>
    /// 添加菜单模型
    /// </summary>
    public class CdAddDTO
    {
        public int cdid { get; set; }
        public int xtid { get; set; }
        public int cdjb { get; set; }
        public int sjcdid { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string method { get; set; }
        public string cdmc { get; set; }
        public int xsjb { get; set; }
        public string bhcdgn { get; set; }
        public string icon { get; set; }
        public string dkfs { get; set; }
    }
}