using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmartProject.Models
{
     public class SubCategory : Category
    {
        public int sub_id { get; set; }
        public string sub_name { get; set; }
        public int gst { get; set; }
    }
}
