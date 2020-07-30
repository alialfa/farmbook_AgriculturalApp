using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/* this model defines the attributes of suppliers that provision seeds within S.Africa
 entails a suppliers names, contact details & their main speciality*/

namespace FarmBook_v7.Models
{
    [Table("Suppliers")]
    public class Supplier {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        
        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierLocation { get; set; }

        [Required]
        public string SupplierAddress { get; set; }
        
        // tinymce4.mvc -editor themes
        [UIHint("tinymce_full"), AllowHtml]
        public string SupplierContent { get; set; } // supplier products & address

    }   

}