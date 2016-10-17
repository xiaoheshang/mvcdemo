/**  版本信息模板在安装目录下，可自行修改。
* js.cs
*
* 功 能： N/A
* 类 名： js
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
namespace demo1.DAL
{
	/// <summary>
	/// 数据访问类:js
	/// </summary>
	public partial class js:IDAL<Model.js>
	{
		public js()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int jsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_js");
            strSql.Append(" where jsid=@jsid");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsid", SqlDbType.Int,4)
            };
            parameters[0].Value = jsid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(demo1.Model.js model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_js(");
            strSql.Append("jsmc,jssm,islock,cjtime,gxtime)");
            strSql.Append(" values (");
            strSql.Append("@jsmc,@jssm,@islock,SYSDATETIME(),SYSDATETIME())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsmc", SqlDbType.NVarChar,50),
                    new SqlParameter("@jssm", SqlDbType.NVarChar,50),
                    new SqlParameter("@islock", SqlDbType.Int,4)};
            parameters[0].Value = model.jsmc;
            parameters[1].Value = model.jssm;
            parameters[2].Value = model.islock;

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
        public bool Update(demo1.Model.js model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_js set ");
            strSql.Append("jsmc=@jsmc,");
            strSql.Append("jssm=@jssm,");
            strSql.Append("islock=@islock,");
            strSql.Append("gxtime=SYSDATETIME()");
            strSql.Append(" where jsid=@jsid");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsmc", SqlDbType.NVarChar,50),
                    new SqlParameter("@jssm", SqlDbType.NVarChar,50),
                    new SqlParameter("@islock", SqlDbType.Int,4),
                    new SqlParameter("@jsid", SqlDbType.Int,4)};
            parameters[0].Value = model.jsmc;
            parameters[1].Value = model.jssm;
            parameters[2].Value = model.islock;
            parameters[3].Value = model.jsid;

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
        public bool Delete(int jsid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_js ");
            strSql.Append(" where jsid=@jsid");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsid", SqlDbType.Int,4)
            };
            parameters[0].Value = jsid;

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
        public bool DeleteList(string jsidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_js ");
            strSql.Append(" where jsid in (" + jsidlist + ")  ");
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
        public demo1.Model.js GetModel(int jsid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 jsid,jsmc,jssm,islock,cjtime,gxtime from t_js ");
            strSql.Append(" where jsid=@jsid");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsid", SqlDbType.Int,4)
            };
            parameters[0].Value = jsid;

            demo1.Model.js model = new demo1.Model.js();
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
        public demo1.Model.js DataRowToModel(DataRow row)
        {
            demo1.Model.js model = new demo1.Model.js();
            if (row != null)
            {
                if (row["jsid"] != null && row["jsid"].ToString() != "")
                {
                    model.jsid = int.Parse(row["jsid"].ToString());
                }
                if (row["jsmc"] != null)
                {
                    model.jsmc = row["jsmc"].ToString();
                }
                if (row["jssm"] != null)
                {
                    model.jssm = row["jssm"].ToString();
                }
                if (row["islock"] != null && row["islock"].ToString() != "")
                {
                    model.islock = int.Parse(row["islock"].ToString())==1?true:false;
                }
                if (row["cjtime"] != null && row["cjtime"].ToString() != "")
                {
                    model.cjtime = DateTime.Parse(row["cjtime"].ToString());
                }
                if (row["gxtime"] != null && row["gxtime"].ToString() != "")
                {
                    model.gxtime = DateTime.Parse(row["gxtime"].ToString());
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
            strSql.Append("select jsid,jsmc,jssm,islock,cjtime,gxtime ");
            strSql.Append(" FROM t_js ");
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
            strSql.Append(" jsid,jsmc,jssm,islock,cjtime,gxtime ");
            strSql.Append(" FROM t_js ");
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
            strSql.Append("select count(1) FROM t_js ");
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
                strSql.Append("order by T.jsid desc");
            }
            strSql.Append(")AS Row, T.*  from t_js T ");
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
			parameters[0].Value = "t_js";
			parameters[1].Value = "jsid";
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
        /// 校验角色名称是否存在
        /// </summary>
        /// <param name="jsmc"></param>
        /// <returns></returns>
        public bool Exists(string jsmc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_js");
            strSql.Append(" where jsmc=@jsmc");
            SqlParameter[] parameters = {
                    new SqlParameter("@jsmc", SqlDbType.VarChar,50)
            };
            parameters[0].Value = jsmc;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

