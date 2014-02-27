using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDR.Web.Models
{
  [Table("DOCUS_SUB_LOOKUP_REPRESENTATIVE")]
    public class DOCUS_SUB_LOOKUP_REPRESENTATIVE
    {
      [Column("LOOKUP_ID")]
      [Key]
        public int LOOKUP_ID { get; set; }
        public Nullable<int> LOOKUP_ORDER { get; set; }
        public string LOOKUP_VALUE { get; set; }
    }
}