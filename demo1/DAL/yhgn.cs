﻿/**  版本信息模板在安装目录下，可自行修改。
* yhgn.cs
*
* 功 能： N/A
* 类 名： yhgn
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/20 11:25:07   N/A    初版
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

namespace demo1.DAL
{
	/// <summary>
	/// 数据访问类:yhgn
	/// </summary>
	public partial class yhgn:IDAL<Model.yhgn>
	{
		public yhgn()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_yhgn");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(demo1.Model.yhgn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_yhgn(");
            strSql.Append("yhid,gnid)");
            strSql.Append(" values (");
            strSql.Append("@yhid,@gnid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhid", SqlDbType.Int,4),
                    new SqlParameter("@gnid", SqlDbType.Int,4)};
            parameters[0].Value = model.yhid;
            parameters[1].Value = model.gnid;

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
        public bool Update(demo1.Model.yhgn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_yhgn set ");
            strSql.Append("yhid=@yhid,");
            strSql.Append("gnid=@gnid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhid", SqlDbType.Int,4),
                    new SqlParameter("@gnid", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.yhid;
            parameters[1].Value = model.gnid;
            parameters[2].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_yhgn ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_yhgn ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public demo1.Model.yhgn GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,yhid,gnid from t_yhgn ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            demo1.Model.yhgn model = new demo1.Model.yhgn();
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
        public demo1.Model.yhgn DataRowToModel(DataRow row)
        {
            demo1.Model.yhgn model = new demo1.Model.yhgn();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["yhid"] != null && row["yhid"].ToString() != "")
                {
                    model.yhid = int.Parse(row["yhid"].ToString());
                }
                if (row["gnid"] != null && row["gnid"].ToString() != "")
                {
                    model.gnid = int.Parse(row["gnid"].ToString());
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
            strSql.Append("select id,yhid,gnid ");
            strSql.Append(" FROM t_yhgn ");
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
            strSql.Append(" id,yhid,gnid ");
            strSql.Append(" FROM t_yhgn ");
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
            strSql.Append("select count(1) FROM t_yhgn ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_yhgn T ");
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
			parameters[0].Value = "t_yhgn";
			parameters[1].Value = "id";
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
        /// 根据用户id获取功能列表
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        public List<Model.yhgn> getGnsByYhid(int yhid)
        {
            List<Model.yhgn> yhgns = new List<Model.yhgn>();
            string sql = "select * from t_yhgn" +
                " where yhid=@yhid";
            SqlParameter[] parameters =
            {
                new SqlParameter("@yhid",SqlDbType.Int,4)
            };

            parameters[0].Value = yhid;

            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    yhgns.Add(DataRowToModel(dr));
                }
            }
            return yhgns;
        }

        /// <summary>
        /// 删除用户所有的功能权限
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        public bool deleteByYhid(int yhid)
        {
            string sql = "delete from t_yhgn where yhid=@yhid";
            SqlParameter[] parameters =
            {
                new SqlParameter("@yhid",SqlDbType.Int,4)
            };
            parameters[0].Value = yhid;
            try
            {
                DbHelperSQL.ExecuteSql(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        #endregion  ExtensionMethod
    }
}

