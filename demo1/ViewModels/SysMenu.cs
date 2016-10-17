using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace demo1.ViewModels
{
    public class SysMenu
    {
        public SysMenu()
        { }
        #region Model
        private int _cdid;
        private int _cdjb;
        private int? _sjcdid;
        private int? _gnid;
        private string _cdmc;
        private int? _xsjb;
        private string _bhcdgn;
        private string _icon;
        private string _dkfs;
        /// <summary>
        /// 
        /// </summary>
        public int cdid
        {
            set { _cdid = value; }
            get { return _cdid; }
        }
        /// <summary>
        /// 0-系统，1-菜单，2-功能
        /// </summary>
        public int cdjb
        {
            set { _cdjb = value; }
            get { return _cdjb; }
        }
        /// <summary>
        /// 上级菜单id
        /// </summary>
        public int? sjcdid
        {
            set { _sjcdid = value; }
            get { return _sjcdid; }
        }
        /// <summary>
        /// 对应的功能id，如果是系统或菜单，这里为空
        /// </summary>
        public int? gnid
        {
            set { _gnid = value; }
            get { return _gnid; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("菜单名称")]
        public string cdmc
        {
            set { _cdmc = value; }
            get { return _cdmc; }
        }
        /// <summary>
        /// 显示级别，0或空不显示，1-一级目录位置，2-二级目录位置
        /// </summary>
        public int? xsjb
        {
            set { _xsjb = value; }
            get { return _xsjb; }
        }
        /// <summary>
        /// 当前系统（菜单）包含的菜单（功能） 11,12,01,04 这种格式
        /// </summary>
        public string bhcdgn
        {
            set { _bhcdgn = value; }
            get { return _bhcdgn; }
        }
        /// <summary>
        /// 菜单或功能显示的图标
        /// </summary>
        [DisplayName("图标")]
        public string icon
        {
            set { _icon = value; }
            get { return _icon; }
        }
        /// <summary>
        /// 功能的打开方式，在本窗口还是新窗口
        /// </summary>
        public string dkfs
        {
            set { _dkfs = value; }
            get { return _dkfs; }
        }
        #endregion Model

        public List<SysMenu> MenuChildren = new List<SysMenu>();

    }
}