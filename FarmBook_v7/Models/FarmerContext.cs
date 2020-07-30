using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/* The FarmerContext is the main database context that holds all the other models related with 
 * Project FarmBook, it connects with the local sql client such that only one database exist & 
 * inherent tables are stores here 
 */
namespace FarmBook_v7.Models
{ 
    // private FarmerContext db = new FarmerContext(); -- how to reference this context from a controller
    public class FarmerContext: DbContext
    {
        public DbSet<Guide> Guides { get; set; } // GuidesModel
        public DbSet<UserProfile> UserProfiles { get; set; } // AccountModel
        public DbSet<Crop> Crops { get; set; } // CropModel
        public DbSet<Location> Locations { get; set; } // LocationModel
        public DbSet<Story> Stories { get; set; } // StoryModel
        public DbSet<Supplier> Suppliers { get; set; } // SupplierModel
    }
}