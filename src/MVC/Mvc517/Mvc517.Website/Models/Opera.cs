using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc517.Website.Models
{
    public class Opera
    {
        [DisplayName("代號")]
        [Required]
        public int Id { get; set; }

        [DisplayName("名稱")]
        [Required]
        public string Title  { get; set; }

        [DisplayName("年分")]
        public int? Year { get; set; }

        [DisplayName("作曲家")]
        public string Composer { get; set; }
    }
}