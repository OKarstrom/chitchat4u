using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class Admin
    {
        [Required]
        [DataType(DataType.Text)]

        public string userEmail { get; set; }
    }
}
