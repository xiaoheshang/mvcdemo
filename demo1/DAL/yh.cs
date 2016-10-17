/**  版本信息模板在安装目录下，可自行修改。
* yh.cs
*
* 功 能： N/A
* 类 名： yh
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
	/// 数据访问类:yh
	/// </summary>
	public partial class yh:IDAL<demo1.Model.yh>
	{
        public yh()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("yhid", "t_yh");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int yhid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_yh");
            strSql.Append(" where yhid=@yhid");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhid", SqlDbType.Int,4)
            };
            parameters[0].Value = yhid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string yhmc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_yh");
            strSql.Append(" where yhmc=@yhmc");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhmc", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = yhmc;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(demo1.Model.yh model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_yh(");
            strSql.Append("yhmc,yhmm,email,qq,lxdh,zsxm,islock,cjtime,gxtime)");
            strSql.Append(" values (");
            strSql.Append("@yhmc,@yhmm,@email,@qq,@lxdh,@zsxm,@islock,SYSDATETIME(),SYSDATETIME())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhmc", SqlDbType.NVarChar,50),
                    new SqlParameter("@yhmm", SqlDbType.NVarChar,64),
                    new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@qq", SqlDbType.NVarChar,50),
                    new SqlParameter("@lxdh", SqlDbType.NVarChar,13),
                    new SqlParameter("@zsxm", SqlDbType.NVarChar,50),
                    new SqlParameter("@islock", SqlDbType.Int,4)};
            parameters[0].Value = model.yhmc;
            parameters[1].Value = model.yhmm;
            parameters[2].Value = model.email;
            parameters[3].Value = model.qq;
            parameters[4].Value = model.lxdh;
            parameters[5].Value = model.zsxm;
            parameters[6].Value = model.islock ? 1 : 0;

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
        public bool Update(demo1.Model.yh model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_yh set ");
            strSql.Append("yhmm=@yhmm,");
            strSql.Append("email=@email,");
            strSql.Append("qq=@qq,");
            strSql.Append("lxdh=@lxdh,");
            strSql.Append("zsxm=@zsxm,");
            strSql.Append("islock=@islock,");
            strSql.Append("gxtime=SYSDATETIME()");
            strSql.Append(" where yhid=@yhid");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhmm", SqlDbType.NVarChar,64),
                    new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@qq", SqlDbType.NVarChar,50),
                    new SqlParameter("@lxdh", SqlDbType.NVarChar,13),
                    new SqlParameter("@zsxm", SqlDbType.NVarChar,50),
                    new SqlParameter("@islock", SqlDbType.Int,4),
                    new SqlParameter("@yhid", SqlDbType.Int,4)};
            parameters[0].Value = model.yhmm;
            parameters[1].Value = model.email;
            parameters[2].Value = model.qq;
            parameters[3].Value = model.lxdh;
            parameters[4].Value = model.zsxm;
            parameters[5].Value = model.islock ? 1 : 0;
            parameters[6].Value = model.yhid;

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
        public bool Delete(int yhid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_yh ");
            strSql.Append(" where yhid=@yhid");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhid", SqlDbType.Int,4)
            };
            parameters[0].Value = yhid;

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
        public bool DeleteList(string yhidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_yh ");
            strSql.Append(" where yhid in (" + yhidlist + ")  ");
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
        public demo1.Model.yh GetModel(int yhid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 yhid,yhmc,yhmm,email,qq,lxdh,zsxm,islock,cjtime,gxtime from t_yh ");
            strSql.Append(" where yhid=@yhid");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhid", SqlDbType.Int,4)
            };
            parameters[0].Value = yhid;

            demo1.Model.yh model = new demo1.Model.yh();
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
        public demo1.Model.yh DataRowToModel(DataRow row)
        {
            demo1.Model.yh model = new demo1.Model.yh();
            if (row != null)
            {
                if (row["yhid"] != null && row["yhid"].ToString() != "")
                {
                    model.yhid = int.Parse(row["yhid"].ToString());
                }
                if (row["yhmc"] != null)
                {
                    model.yhmc = row["yhmc"].ToString();
                }
                if (row["yhmm"] != null)
                {
                    model.yhmm = row["yhmm"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                if (row["lxdh"] != null)
                {
                    model.lxdh = row["lxdh"].ToString();
                }
                if (row["zsxm"] != null)
                {
                    model.zsxm = row["zsxm"].ToString();
                }
                if (row["islock"] != null && row["islock"].ToString() != "")
                {
                    model.islock = int.Parse(row["islock"].ToString()) == 1 ? true : false;
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
            strSql.Append("select yhid,yhmc,yhmm,email,qq,lxdh,zsxm,islock,cjtime,gxtime ");
            strSql.Append(" FROM t_yh ");
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
            strSql.Append(" yhid,yhmc,yhmm,email,qq,lxdh,zsxm,islock,cjtime,gxtime ");
            strSql.Append(" FROM t_yh ");
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
            strSql.Append("select count(1) FROM t_yh ");
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
                strSql.Append("order by T.yhid desc");
            }
            strSql.Append(")AS Row, T.*  from t_yh T ");
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
			parameters[0].Value = "t_yh";
			parameters[1].Value = "yhid";
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
        /// 根据用户名称获取用户信息
        /// </summary>
        /// <param name="yhmc">用户名称</param>
        /// <returns></returns>
        public demo1.Model.yh GetModelByYhmc(string yhmc)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 yhid,yhmc,yhmm,email,qq,lxdh,zsxm,islock,cjtime,gxtime from t_yh ");
            strSql.Append(" where yhmc=@yhmc");
            SqlParameter[] parameters = {
                    new SqlParameter("@yhmc", SqlDbType.VarChar,50)
            };
            parameters[0].Value = yhmc;

            demo1.Model.yh model = new demo1.Model.yh();
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
        /// 更新一条数据(不更新用户密码）
        /// </summary>
        public bool UpdateWithoutYhmm(demo1.Model.yh model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_yh set ");
            strSql.Append("email=@email,");
            strSql.Append("qq=@qq,");
            strSql.Append("lxdh=@lxdh,");
            strSql.Append("zsxm=@zsxm,");
            strSql.Append("islock=@islock,");
            strSql.Append("gxtime=SYSDATETIME()");
            strSql.Append(" where yhid=@yhid");
            SqlParameter[] parameters = {
                    new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@qq", SqlDbType.NVarChar,50),
                    new SqlParameter("@lxdh", SqlDbType.NVarChar,13),
                    new SqlParameter("@zsxm", SqlDbType.NVarChar,50),
                    new SqlParameter("@islock", SqlDbType.Int,4),
                    new SqlParameter("@yhid", SqlDbType.Int,4)};
            parameters[0].Value = model.email;
            parameters[1].Value = model.qq;
            parameters[2].Value = model.lxdh;
            parameters[3].Value = model.zsxm;
            parameters[4].Value = model.islock ? 1 : 0;
            parameters[5].Value = model.yhid;

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
        #endregion  ExtensionMethod
    }
}

