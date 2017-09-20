using Mvc517.DAL.Validator;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc517.DAL.Models
{
    public class Opera
    {
        [Key]
        [DisplayName("代號")]
        [Required]
        public int Id { get; set; }

        [DisplayName("名稱")]
        [Required]
        public string Title  { get; set; }

        [YearValidator]
        [DisplayName("年分")]
        public int? Year { get; set; }

        [DisplayName("作曲家")]
        public string Composer { get; set; }

        
        public DateTime CreateOn { get; set; }

        public DateTime UpdateOn { get; set; }

        [DisplayName("描述")]
        public int? CommentId { get; set; }



        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

        public Opera()
        {
            this.Comment = new Comment();
        }
    }
}