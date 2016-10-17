using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    /// <summary>
    /// 存放根菜单
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MenuViewModel<T>
    {
        public IList<T> MenuItems = new List<T>();
    }
}