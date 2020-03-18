using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class MessageTest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("aspnetusers")]
        public string UserId { get; set; }
        public string Test { get; set; }
    }
}
