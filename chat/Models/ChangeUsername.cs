using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ChangeUsername
    {

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
    }
}