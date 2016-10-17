/**  版本信息模板在安装目录下，可自行修改。
* js.cs
*
* 功 能： N/A
* 类 名： js
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
using System.ComponentModel.DataAnnotations;

namespace demo1.Model
{
	/// <summary>
	/// js:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class js
	{
		public js()
		{}
        #region Model
        private int _jsid;
        private string _jsmc;
        private string _jssm;
        private int _islock = 0;
        private DateTime? _cjtime;
        private DateTime? _gxtime;
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
        [Required]
        public string jsmc
        {
            set { _jsmc = value; }
            get { return _jsmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jssm
        {
            set { _jssm = value; }
            get { return _jssm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool islock
        {
            set
            {
                _islock = value ? 1 : 0;
            }
            get { return _islock == 1 ? true : false; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cjtime
        {
            set { _cjtime = value; }
            get { return _cjtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? gxtime
        {
            set { _gxtime = value; }
            get { return _gxtime; }
        }
        #endregion Model

    }
}

