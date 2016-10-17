/**  版本信息模板在安装目录下，可自行修改。
* gn.cs
*
* 功 能： N/A
* 类 名： gn
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/20 11:25:06   N/A    初版
*
* Copyright (c) 2012 demo1 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using demo1.DBUtility;//Please add references
using System.Collections.Generic;
using System.Collections;

namespace demo1.DAL
{
	/// <summary>
	/// 数据访问类:gn
	/// </summary>
	public partial class gn:IDAL<Model.gn>
	{
		public gn()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("gnid", "t_gn"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int gnid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_gn");
			strSql.Append(" where gnid=@gnid");
			SqlParameter[] parameters = {
					new SqlParameter("@gnid", SqlDbType.Int,4)
			};
			parameters[0].Value = gnid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(demo1.Model.gn model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_gn(");
            strSql.Append("controller,action,controllername,actionname,method,version,addtime,ispublic,islock)");
            strSql.Append(" values (");
            strSql.Append("@controller,@action,@controllername,@actionname,@method,@version,SYSDATETIME(),@ispublic,@islock)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@controller", SqlDbType.NVarChar,50),
                    new SqlParameter("@action", SqlDbType.NVarChar,50),
                    new SqlParameter("@controllername", SqlDbType.NVarChar,50),
                    new SqlParameter("@actionname", SqlDbType.NVarChar,50),
                    new SqlParameter("@method", SqlDbType.NVarChar,50),
                    new SqlParameter("@version", SqlDbType.NVarChar,50),
                    new SqlParameter("@ispublic", SqlDbType.Int,4),
                    new SqlParameter("@islock", SqlDbType.Int,4)};
            parameters[0].Value = model.controller;
            parameters[1].Value = model.action;
            parameters[2].Value = model.controllername;
            parameters[3].Value = model.actionname;
            parameters[4].Value = model.method;
            parameters[5].Value = model.version;
            parameters[6].Value = model.ispublic ? 1 : 0;
            parameters[7].Value = model.islock ? 1 : 0;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(demo1.Model.gn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_gn set ");
            strSql.Append("controller=@controller,");
            strSql.Append("action=@action,");
            strSql.Append("controllername=@controllername,");
            strSql.Append("actionname=@actionname,");
            strSql.Append("method=@method,");
            strSql.Append("version=@version,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("ispublic=@ispublic,");
            strSql.Append("islock=@islock");
            strSql.Append(" where gnid=@gnid");
            SqlParameter[] parameters = {
                    new SqlParameter("@controller", SqlDbType.NVarChar,50),
                    new SqlParameter("@action", SqlDbType.NVarChar,50),
                    new SqlParameter("@controllername", SqlDbType.NVarChar,50),
                    new SqlParameter("@actionname", SqlDbType.NVarChar,50),
                    new SqlParameter("@method", SqlDbType.NVarChar,50),
                    new SqlParameter("@version", SqlDbType.NVarChar,50),
                    new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@ispublic", SqlDbType.Int,4),
                    new SqlParameter("@islock", SqlDbType.Int,4),
                    new SqlParameter("@gnid", SqlDbType.Int,4)};
            parameters[0].Value = model.controller;
            parameters[1].Value = model.action;
            parameters[2].Value = model.controllername;
            parameters[3].Value = model.actionname;
            parameters[4].Value = model.method;
            parameters[5].Value = model.version;
            parameters[6].Value = model.addtime;
            parameters[7].Value = model.ispublic;
            parameters[8].Value = model.islock;
            parameters[9].Value = model.gnid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int gnid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_gn ");
            strSql.Append(" where gnid=@gnid");
            SqlParameter[] parameters = {
                    new SqlParameter("@gnid", SqlDbType.Int,4)
            };
            parameters[0].Value = gnid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string gnidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_gn ");
            strSql.Append(" where gnid in (" + gnidlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_gn ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public demo1.Model.gn GetModel(int gnid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 gnid,controller,action,controllername,actionname,method,version,addtime,ispublic,islock from t_gn ");
            strSql.Append(" where gnid=@gnid");
            SqlParameter[] parameters = {
                    new SqlParameter("@gnid", SqlDbType.Int,4)
            };
            parameters[0].Value = gnid;

            demo1.Model.gn model = new demo1.Model.gn();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public demo1.Model.gn DataRowToModel(DataRow row)
        {
            demo1.Model.gn model = new demo1.Model.gn();
            if (row != null)
            {
                if (row["gnid"] != null && row["gnid"].ToString() != "")
                {
                    model.gnid = int.Parse(row["gnid"].ToString());
                }
                if (row["controller"] != null)
                {
                    model.controller = row["controller"].ToString();
                }
                if (row["action"] != null)
                {
                    model.action = row["action"].ToString();
                }
                if (row["controllername"] != null)
                {
                    model.controllername = row["controllername"].ToString();
                }
                if (row["actionname"] != null)
                {
                    model.actionname = row["actionname"].ToString();
                }
                if (row["method"] != null)
                {
                    model.method = row["method"].ToString();
                }
                if (row["version"] != null)
                {
                    model.version = row["version"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["ispublic"] != null && row["ispublic"].ToString() != "")
                {
                    model.ispublic = int.Parse(row["ispublic"].ToString()) == 1 ? true : false;
                }
                if (row["islock"] != null && row["islock"].ToString() != "")
                {
                    model.islock = int.Parse(row["islock"].ToString()) == 1 ? true : false;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gnid,controller,action,controllername,actionname,method,version,addtime,ispublic,islock ");
            strSql.Append(" FROM t_gn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" gnid,controller,action,controllername,actionname,method,version,addtime,ispublic,islock ");
            strSql.Append(" FROM t_gn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_gn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.gnid desc");
            }
            strSql.Append(")AS Row, T.*  from t_gn T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_gn";
			parameters[1].Value = "gnid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取List
        /// </summary>
        /// <param name="whr"></param>
        /// <returns></returns>
        public List<Model.gn> getModelList(string whr)
        {
            List<Model.gn> gns = new List<Model.gn>();

            DataSet ds = GetList(whr);
            if(ds.Tables[0].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    gns.Add(DataRowToModel(dr));
                }
            }

            return gns;
        }
        /// <summary>
        /// 根据用户名称获取用户有权限的功能id数组
        /// </summary>
        /// <param name="yhmc"></param>
        /// <returns></returns>
        public int[] getGnidsByYhmc(string yhmc)
        {
            List<int> rst = new List<int>();
            string sql = "select distinct gnid from " +
                        "( " +
                        "select c.gnid from t_yh as a, t_yhjs as b, t_jsgn as c,t_gn as d " +
                        "where a.yhid = b.yhid and b.jsid = c.jsid and c.gnid=d.gnid " +
                        "and d.islock='0' and a.yhmc = @yhmc1 " +
                        "union " +
                        "select b.gnid from t_yh as a, t_yhgn as b,t_gn as d " +
                        "where a.yhid = b.yhid and b.gnid=d.gnid " +
                        "and d.islock='0' and a.yhmc = @yhmc2 " +
                        "union "+
                        "select gnid from t_gn where ispublic='1' "+
                        ") as x";
            SqlParameter[] parameters = {
                    new SqlParameter("@yhmc1", SqlDbType.VarChar,50),
                    new SqlParameter("@yhmc2", SqlDbType.VarChar,50)
            };
            parameters[0].Value = yhmc;
            parameters[1].Value = yhmc;

            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    rst.Add(Convert.ToInt32(dr["gnid"]));
                }
            }
            return rst.ToArray();
        }

        /// <summary>
        /// 通过controller 和 action 获取功能
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Model.gn getModelByName(string ctrl,string action)
        {
            Model.gn gn = new Model.gn();

            string sql = "select * from t_gn where controller=@controller and action=@action";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@controller",SqlDbType.VarChar,50),
                new SqlParameter("@action",SqlDbType.VarChar,50)
            };
            parameters[0].Value = ctrl;
            parameters[1].Value = action;

            DataSet ds = DbHelperSQL.Query(sql, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gn = DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return gn;
        }

        #endregion  ExtensionMethod
    }
}

