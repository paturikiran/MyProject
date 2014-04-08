using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDR.Web.Models
{
    public class DOCUS_SYS_CUSTODIAN
    {

        public int CUSTODIAN_ID { get; set; }
        public string CUSTODIAN_NAME { get; set; }
        public string CUSTODIAN_COMMENTS { get; set; }
        public System.DateTime DATE_CREATED { get; set; }
        public System.DateTime DATE_UPDATED { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }

    }
}