using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Models
{
    public class CompanyInfo
    {   [Key]
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string CompanyContactName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
    }
}
