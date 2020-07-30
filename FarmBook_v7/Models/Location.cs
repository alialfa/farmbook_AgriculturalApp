using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

/* Please note that this model has not been used within the project, it was merely for test purposes*/
namespace FarmBook_v7.Models
{
    [Table("Location")]
    public class Location {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string LocationName { get; set; } // 9 provinces - EC, FreeStrate, Gau, KZN, Limp, Mpu, NC, NW, WC
        
        public List<Supplier> Suppliers { get; set; }
        
        /*
        [Required]
        public string IsSelected { get; set; }
        */
    }   

}