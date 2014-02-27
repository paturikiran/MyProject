using System.Collections.Generic;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubRequestRepository
    {
        IEnumerable<DOCUS_SUB_REQUEST> GetAll();
        IEnumerable<DOCUS_SUB_REQUEST> Get(int id);
        void Insert(DOCUS_SUB_REQUEST subRequest);
        void Update(DOCUS_SUB_REQUEST subRequest);
    }
}