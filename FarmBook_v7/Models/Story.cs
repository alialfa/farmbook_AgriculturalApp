using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/* this is the story model which pretty much acts as a blog, user stories attributes are defined such as 
 * ID, Name, Author & Titles as well as posting time stamps */

namespace FarmBook_v7.Models
{
    [Table("Stories")]
    public class Story {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StoryID { get; set; }
        
        [Required(ErrorMessage="Please enter Author name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter Story title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostedOn { get; set; }
 
        // tinymce4.mvc -editor themes
        [UIHint("tinymce_classic_compressed"), AllowHtml]
        [Required(ErrorMessage = "Please enter your Story's content")]
        public string Content { get; set; }

    }   

    /*
    public class Uploads
     {
         public IEnumerable<HttpPostedFileBase> Files { get; set; }
     }*/
}