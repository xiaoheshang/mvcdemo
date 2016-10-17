/**  版本信息模板在安装目录下，可自行修改。
* yh.cs
*
* 功 能： N/A
* 类 名： yh
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
    /// yh:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class yh
    {
        public yh()
        { }
        #region Model
        private int _yhid;
        private string _yhmc;
        private string _yhmm;
        private string _email;
        private string _qq;
        private string _lxdh;
        private string _zsxm;
        private int _islock = 0;
        private DateTime? _cjtime;
        private DateTime? _gxtime;
        /// <summary>
        /// 
        /// </summary>
        public int yhid
        {
            set { _yhid = value; }
            get { return _yhid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yhmc
        {
            set { _yhmc = value; }
            get { return _yhmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        
        public string yhmm
        {
            set { _yhmm = value; }
            get { return _yhmm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string lxdh
        {
            set { _lxdh = value; }
            get { return _lxdh; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string zsxm
        {
            set { _zsxm = value; }
            get { return _zsxm; }
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

