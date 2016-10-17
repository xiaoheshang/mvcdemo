using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1.Common
{
    public interface IItem<T>
    {
        IList<T> GetChildren();
    }
}
