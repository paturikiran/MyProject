using System.Linq.Expressions;
using CDR.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CDR.Web.Api
{
    public class ApiRepository<T>: IApiRepository<T>
    {
        public IEnumerable<T> Get(string requestUrl)
        {
            HttpResponseMessage response = ApiConnection.ApiConnect().GetAsync(requestUrl).Result;
            IEnumerable<T> returnType = new List<T>();
            if (response.IsSuccessStatusCode)
                returnType = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
            return returnType;
        }

        public T GetDetails(string requestUrl)
        {
            HttpResponseMessage response = ApiConnection.ApiConnect().GetAsync(requestUrl).Result;
            return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<T>().Result :(T) new Object();
        }

        public bool Update(T obj,string requestUrl)
        {
            HttpResponseMessage response = ApiConnection.ApiConnect().PutAsJsonAsync(requestUrl, obj).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Insert(T obj, string requestUrl)
        {
            HttpResponseMessage response = ApiConnection.ApiConnect().PostAsJsonAsync(requestUrl, obj).Result;
            return response.IsSuccessStatusCode;
        }

       
        public int Create(T obj, string requestUrl)
        {
            HttpResponseMessage response = ApiConnection.ApiConnect().PostAsJsonAsync(requestUrl, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                var returnType = response.Content.ReadAsAsync<int>().Result;
                return returnType;
            }
            return 0;
        }
    }
}