using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1.DAL
{
    public interface IDAL<T>
    {
        int Add(T model);
        bool Update(T model);
        bool Delete(int id);
        bool DeleteList(string idlist);
        T GetModel(int id);
        T DataRowToModel(DataRow row);
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        
    }
}
