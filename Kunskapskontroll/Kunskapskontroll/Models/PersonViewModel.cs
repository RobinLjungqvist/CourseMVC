using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kunskapskontroll.Models
{
    public class PersonViewModel
    {
        public Guid id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display( Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }

        public DateTime Updated { get; set; }


    }
}