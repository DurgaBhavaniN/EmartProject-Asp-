using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EmartProject.Models
{
    public class ProductCreateViewModel:SubCategory
    {
        [Key]
        public int i_id { get; set; }
        public double price { get; set; }
        public int stk_num { get; set; }
        public string i_name { get; set; }
        public int s_id { get; set; }
        public IFormFile ItemPhoto { get; set; }
    }
}
