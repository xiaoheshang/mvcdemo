/**  版本信息模板在安装目录下，可自行修改。
* cd.cs
*
* 功 能： N/A
* 类 名： cd
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/20 11:25:05   N/A    初版
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
	/// 数据访问类:cd
	/// </summary>
	public partial class cd : IDAL<demo1.Model.cd>
	{
		public cd()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(demo1.Model.cd model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_cd(");
            strSql.Append("xtid,cdjb,sjcdid,gnid,cdmc,xsjb,bhcdgn,icon,dkfs)");
            strSql.Append(" values (");
            strSql.Append("@xtid,@cdjb,@sjcdid,@gnid,@cdmc,@xsjb,@bhcdgn,@icon,@dkfs)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@xtid", SqlDbType.Int,4),
                    new SqlParameter("@cdjb", SqlDbType.Int,4),
                    new SqlParameter("@sjcdid", SqlDbType.Int,4),
                    new SqlParameter("@gnid", SqlDbType.Int,4),
                    new SqlParameter("@cdmc", SqlDbType.NVarChar,50),
                    new SqlParameter("@xsjb", SqlDbType.Int,4),
                    new SqlParameter("@bhcdgn", SqlDbType.NVarChar,50),
                    new SqlParameter("@icon", SqlDbType.NVarChar,50),
                    new SqlParameter("@dkfs", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.xtid;
            parameters[1].Value = model.cdjb;
            parameters[2].Value = model.sjcdid;
            parameters[3].Value = model.gnid;
            parameters[4].Value = model.cdmc;
            parameters[5].Value = model.xsjb;
            parameters[6].Value = model.bhcdgn;
            parameters[7].Value = model.icon;
            parameters[8].Value = model.dkfs;

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
		public bool Update(demo1.Model.cd model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_cd set ");
            strSql.Append("xtid=@xtid,");
            strSql.Append("cdjb=@cdjb,");
            strSql.Append("sjcdid=@sjcdid,");
            strSql.Append("gnid=@gnid,");
            strSql.Append("cdmc=@cdmc,");
            strSql.Append("xsjb=@xsjb,");
            strSql.Append("bhcdgn=@bhcdgn,");
            strSql.Append("icon=@icon,");
            strSql.Append("dkfs=@dkfs");
            strSql.Append(" where cdid=@cdid");
            SqlParameter[] parameters = {
                    new SqlParameter("@xtid", SqlDbType.Int,4),
                    new SqlParameter("@cdjb", SqlDbType.Int,4),
                    new SqlParameter("@sjcdid", SqlDbType.Int,4),
                    new SqlParameter("@gnid", SqlDbType.Int,4),
                    new SqlParameter("@cdmc", SqlDbType.NVarChar,50),
                    new SqlParameter("@xsjb", SqlDbType.Int,4),
                    new SqlParameter("@bhcdgn", SqlDbType.NVarChar,50),
                    new SqlParameter("@icon", SqlDbType.NVarChar,50),
                    new SqlParameter("@dkfs", SqlDbType.NVarChar,50),
                    new SqlParameter("@cdid", SqlDbType.Int,4)};
            parameters[0].Value = model.xtid;
            parameters[1].Value = model.cdjb;
            parameters[2].Value = model.sjcdid;
            parameters[3].Value = model.gnid;
            parameters[4].Value = model.cdmc;
            parameters[5].Value = model.xsjb;
            parameters[6].Value = model.bhcdgn;
            parameters[7].Value = model.icon;
            parameters[8].Value = model.dkfs;
            parameters[9].Value = model.cdid;

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
		public bool Delete(int cdid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_cd ");
			strSql.Append(" where cdid=@cdid");
			SqlParameter[] parameters = {
					new SqlParameter("@cdid", SqlDbType.Int,4)
			};
			parameters[0].Value = cdid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string cdidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_cd ");
			strSql.Append(" where cdid in ("+cdidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public demo1.Model.cd GetModel(int cdid)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cdid,xtid,cdjb,sjcdid,gnid,cdmc,xsjb,bhcdgn,icon,dkfs from t_cd ");
            strSql.Append(" where cdid=@cdid");
            SqlParameter[] parameters = {
                    new SqlParameter("@cdid", SqlDbType.Int,4)
            };
            parameters[0].Value = cdid;

            demo1.Model.cd model = new demo1.Model.cd();
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
		public demo1.Model.cd DataRowToModel(DataRow row)
		{
            demo1.Model.cd model = new demo1.Model.cd();
            if (row != null)
            {
                if (row["cdid"] != null && row["cdid"].ToString() != "")
                {
                    model.cdid = int.Parse(row["cdid"].ToString());
                }
                if (row["xtid"] != null && row["xtid"].ToString() != "")
                {
                    model.xtid = int.Parse(row["xtid"].ToString());
                }
                if (row["cdjb"] != null && row["cdjb"].ToString() != "")
                {
                    model.cdjb = int.Parse(row["cdjb"].ToString());
                }
                if (row["sjcdid"] != null && row["sjcdid"].ToString() != "")
                {
                    model.sjcdid = int.Parse(row["sjcdid"].ToString());
                }
                if (row["gnid"] != null && row["gnid"].ToString() != "")
                {
                    model.gnid = int.Parse(row["gnid"].ToString());
                }
                if (row["cdmc"] != null)
                {
                    model.cdmc = row["cdmc"].ToString();
                }
                if (row["xsjb"] != null && row["xsjb"].ToString() != "")
                {
                    model.xsjb = int.Parse(row["xsjb"].ToString());
                }
                if (row["bhcdgn"] != null)
                {
                    model.bhcdgn = row["bhcdgn"].ToString();
                }
                if (row["icon"] != null)
                {
                    model.icon = row["icon"].ToString();
                }
                if (row["dkfs"] != null)
                {
                    model.dkfs = row["dkfs"].ToString();
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
            strSql.Append("select cdid,xtid,cdjb,sjcdid,gnid,cdmc,xsjb,bhcdgn,icon,dkfs ");
            strSql.Append(" FROM t_cd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" cdid,xtid,cdjb,sjcdid,gnid,cdmc,xsjb,bhcdgn,icon,dkfs ");
            strSql.Append(" FROM t_cd ");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_cd ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.cdid desc");
			}
			strSql.Append(")AS Row, T.*  from t_cd T ");
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
			parameters[0].Value = "t_cd";
			parameters[1].Value = "cdid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        
        public List<Model.cd> getModelList(string whr)
        {
            List<Model.cd> cds = new List<Model.cd>();
            DataSet ds = GetList(whr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cds.Add(DataRowToModel(dr));
                }
            }

            return cds;
        }
        /// <summary>
        /// 获取一个级别的所有菜单
        /// </summary>
        /// <param name="cdjb"></param>
        /// <returns></returns>
        public List<Model.cd> getCdsBycdjb(int cdjb)
        {
            List<Model.cd> cds = new List<Model.cd>();
            string sql = "select * from t_cd where cdjb=@cdjb";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@cdjb", SqlDbType.Int, 4)
            };
            parameters[0].Value = cdjb;

            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    cds.Add(DataRowToModel(dr));
                }
            }

            return cds;
        }

        /// <summary>
        /// 根据上级菜单id获取菜单列表
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public List<Model.cd> getCdByParentid(int parentid)
        {
            List<Model.cd> cds = new List<Model.cd>();
            string sql = "select * from t_cd where sjcdid=@sjcdid";
            SqlParameter[] parameters =
            {
                new SqlParameter("@sjcdid", SqlDbType.Int, 4)
            };
            parameters[0].Value = parentid;

            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cds.Add(DataRowToModel(dr));
                }
            }

            return cds;
        }

		#endregion  ExtensionMethod
	}
}

