using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSite.Models
{
    public class CalcAccessDate
    {
        public int CalcAccessDateID { get; set; }
        public DateTime DateTo { get; set; }
        public bool DateIsSet { get; set; }
    }
}