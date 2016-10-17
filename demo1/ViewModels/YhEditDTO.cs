using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    /// <summary>
    /// 编辑用户信息页面模型
    /// </summary>
    public class YhEditDTO
    {
        public YhEditDTO()
        {
            this.yh = new Model.yh();
            this.yhgns = new List<YhgnDTO>();
            this.yhjss = new List<YhjsDTO>();
        }
        //基本信息
        public Model.yh yh { get; set; }

        //用户权限
        public List<ViewModels.YhgnDTO> yhgns{get;set;}

        //用户角色
        public List<ViewModels.YhjsDTO> yhjss { get; set; }

    }
}