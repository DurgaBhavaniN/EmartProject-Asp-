using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmartProject.Models
{
    public class Seller
    {
        [Key]
        public int s_id { get; set; }
        [Required(ErrorMessage = "Plz enter name")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Name should between 4 to 20 characters")]


        public string s_name { get; set; }
        [DataType("Password")]
        public string s_pwd { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string s_emailid { get; set; }
        public double gstin { get; set; }
        public string bank_details { get; set; }
        public string Photpath { get; set; }
       
    }
}
