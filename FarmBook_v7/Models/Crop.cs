using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

/* The crop model defines the attributes for the crops information stored in the database
 i.e the Crop ID, Name, Location, its content & any additional information related to a crop 
 */
 
namespace FarmBook_v7.Models
{
    [Table("Crops")]
    public class Crop
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CropID { get; set; } 
        
        [Required]
        public string CropName { get; set; }
        
        [Required]
        public string CropLocation { get; set; }

        /* a tiny mce editor was used to allow users to input data on a detailed text editor
         * such that formatting could simulate that of MS WORD docs
         * tinymce4.mvc -editor them -- //[UIHint("tinymce_basic"), AllowHtml] | [UIHint("tinymce_full"), AllowHtml]*/
        [UIHint("tinymce_classic"), AllowHtml]
        [Required]
        public string CropContent { get; set; }


        [UIHint("tinymce_classic"), AllowHtml]
        public string CropExtra { get; set; }
     }

}
