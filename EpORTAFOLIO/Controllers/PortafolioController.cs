using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EpORTAFOLIO.Models;

namespace EpORTAFOLIO.Controllers
{
    public class PortafolioController : Controller
    {
        // GET: Portafolio
        public ActionResult VistaIndex()
        {
            return View();
        }
    }
}