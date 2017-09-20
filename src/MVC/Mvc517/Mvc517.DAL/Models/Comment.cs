using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc517.DAL.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }
    }
}
