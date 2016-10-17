
using demo1.Common;
/**  版本信息模板在安装目录下，可自行修改。
* cd.cs
*
* 功 能： N/A
* 类 名： cd
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/20 11:04:30   N/A    初版
*
* Copyright (c) 2012 demo1 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：zk　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace demo1.Model
{
	/// <summary>
	/// cd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cd:IItem<cd>
	{
		public cd()
		{}
		#region Model
		private int _cdid;
        private int _xtid;
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
			set{ _cdid=value;}
			get{return _cdid;}
		}
		/// <summary>
		/// 0-系统，1-菜单，2-功能
		/// </summary>
		public int cdjb
		{
			set{ _cdjb=value;}
			get{return _cdjb;}
		}
        /// <summary>
        /// 系统id
        /// </summary>
        public int xtid
        {
            set { _xtid = value; }
            get { return _xtid; }
        }
		/// <summary>
		/// 上级菜单id
		/// </summary>
		public int? sjcdid
		{
			set{ _sjcdid=value;}
			get{return _sjcdid;}
		}
		/// <summary>
		/// 对应的功能id，如果是系统或菜单，这里为空
		/// </summary>
		public int? gnid
		{
			set{ _gnid=value;}
			get{return _gnid;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
        [DisplayName("菜单名称")]
		public string cdmc
		{
			set{ _cdmc=value;}
			get{return _cdmc;}
		}
		/// <summary>
		/// 显示级别，0或空不显示，1-一级目录位置，2-二级目录位置
		/// </summary>
		public int? xsjb
		{
			set{ _xsjb=value;}
			get{return _xsjb;}
		}
		/// <summary>
		/// 当前系统（菜单）包含的菜单（功能） 11,12,01,04 这种格式
		/// </summary>
		public string bhcdgn
		{
			set{ _bhcdgn=value;}
			get{return _bhcdgn;}
		}
        /// <summary>
        /// 菜单或功能显示的图标
        /// </summary>
        [DisplayName("图标")]
        public string icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 功能的打开方式，在本窗口还是新窗口
		/// </summary>
		public string dkfs
		{
			set{ _dkfs=value;}
			get{return _dkfs;}
		}
        #endregion Model

        public IList<cd> GetChildren()
        {
            return MenuChildren;
        }

        public List<cd> MenuChildren = new List<cd>();
    }
}

