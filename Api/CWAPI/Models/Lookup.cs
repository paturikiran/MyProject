﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CWAPI.Models
{
    public class LookupModel
    {
        public string Section { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Transaction { get; set; }
        public int? Id { get; set; }
    }
}