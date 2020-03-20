using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class DeleteAccount
    {
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
