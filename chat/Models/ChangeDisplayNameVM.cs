using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class ChangeDisplayNameVM
    {

        [Required]
        [DataType(DataType.Text)]
        [MinLength(4)]
        public string DisplayName { get; set; }
    }
}