/**  版本信息模板在安装目录下，可自行修改。
* jsgn.cs
*
* 功 能： N/A
* 类 名： jsgn
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/20 11:04:31   N/A    初版
*
* Copyright (c) 2012 demo1 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：zk　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace demo1.Model
{
	/// <summary>
	/// jsgn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class jsgn
	{
        public jsgn()
        { }
        #region Model
        private int _id;
        private int _jsid;
        private int _gnid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int jsid
        {
            set { _jsid = value; }
            get { return _jsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int gnid
        {
            set { _gnid = value; }
            get { return _gnid; }
        }
        #endregion Model

    }
}

