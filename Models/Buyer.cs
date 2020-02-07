using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EmartProject.Models
{
    public class Buyer
    {
        [Key]
        public int b_id { get; set; }
        [Required(ErrorMessage = "Plz enter name")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Name should between 4 to 20 characters")]

        public string b_name { get; set; }
        [DataType("Password")]
        public string b_pwd { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string b_email_id { get; set; }
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Invalid Mobile no")]
        public long b_phn { get; set; }
    }
}
