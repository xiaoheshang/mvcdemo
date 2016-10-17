/**  版本信息模板在安装目录下，可自行修改。
* gn.cs
*
* 功 能： N/A
* 类 名： gn
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
	/// gn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gn
	{
        public gn()
        { }
        #region Model
        private int _gnid;
        private string _controller;
        private string _action;
        private string _controllername;
        private string _actionname;
        private string _method;
        private string _version;
        private bool _ispublic;
        private DateTime? _addtime;
        private bool _islock;
        /// <summary>
        /// 
        /// </summary>
        public int gnid
        {
            set { _gnid = value; }
            get { return _gnid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string controller
        {
            set { _controller = value; }
            get { return _controller; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string action
        {
            set { _action = value; }
            get { return _action; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string controllername
        {
            set { _controllername = value; }
            get { return _controllername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actionname
        {
            set { _actionname = value; }
            get { return _actionname; }
        }
        /// <summary>
        /// http请求方式
        /// </summary>
        public string method
        {
            set { _method = value; }
            get { return _method; }
        }
        /// <summary>
        /// 版本
        /// </summary>
        public string version
        {
            set { _version = value; }
            get { return _version; }
        }

        public bool ispublic
        {
            set { _ispublic = value; }
            get { return _ispublic; }
        }
        public bool islock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

