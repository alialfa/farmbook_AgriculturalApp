using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* AN UPLOAD MODEL THAT ALLOWS MULTIPLE FILES TO BE CAPTURED AS AN ENUM LIST */

namespace FarmBook_v7.Models
{
    public class Upload
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }

}