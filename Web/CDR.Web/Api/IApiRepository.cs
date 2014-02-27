using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR.Web.Api
{
    public interface IApiRepository<T>
    {
        IEnumerable<T> Get(string requestUrl);

        T GetDetails(string requestUrl);
        bool Update(T obj, string requestUrl);

        bool Insert(T obj, string requestUrl);
    }
}
