using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmBook_v7.Repositories;
using FarmBook_v7.Models;

/* THIS CLASS HAS BEEN IMPLEMENTED AS IS FROM AN OPEN SOURCE DEVELOPERS PROJECT ON www.philknows.net
 * IT WORKS ON Asp.Net.SignalR to allow a realtime chat service 
 */

namespace FarmBook_v7.Controllers
{
    public class ChatController : Controller
    {

        public ActionResult Chat() // initiaites client chat socket connection
        {
            return View();
        }
        
        public JsonResult Messages() //access chat repository for old messages
        {
            return Json(ChatRepository.GetMessages(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chat2() // this method is irrelevant - test purposes only
        {
            return View();
        }
    }
}
