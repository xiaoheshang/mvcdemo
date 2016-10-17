using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Common.MenuHelper.Base
{
    public class TagContainer
    {
        /// <summary>
        /// 表示记录的序号（构建时，每个TagContainer都有个OrdinalNum作为标记，每产生一个li或ul都加1）
        /// </summary>
        public int OrdinalNum;
        public string Name;
        /// <summary>
        /// 用于创建 HTML 元素的类和属性
        /// </summary>
        public TagBuilder Tb;
        public TagContainer ParentContainer;
        public List<TagContainer> ChildrenContainers = new List<TagContainer>();

        public TagContainer(ref int Num,TagContainer parent)
        {
            OrdinalNum = Num++;
            ParentContainer = parent;
            if (parent != null)
            {
                parent.ChildrenContainers.Add(this);
            }
        }
    }
}