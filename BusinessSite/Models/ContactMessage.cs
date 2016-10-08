using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSite.Models
{
    public class ContactMessage
    {
        public int ContactMessageID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
    }
}