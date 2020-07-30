using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/* The guide model defines the attributes for the farming guides related to the crops
 * in the crop model
 i.e guides like how to sow seeds, pruning, watering, gardening, glossary's 
 */
namespace FarmBook_v7.Models
{
    [Table("Guides")]
    public class Guide
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string GuideName { get; set; }
        
        [UIHint("tinymce_classic"), AllowHtml]
        [Required]
        public string GuideContent { get; set; }

    }
}