using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisepay.Web.Controllers
{
  using Database;

  using Logging;
  
  using UnitOfService;

  public class HomeController : Controller
  {
   
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult WisepayLanding()
    {
     
      ViewBag.Message = "Your Wisepay application Landing page.";
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
    //[ChildActionOnly]
    //[OutputCache(Duration = 180)]
    //public ActionResult Version()
    //{
    //  var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

    //  var versionViewModel = new VersionViewModel { Version = version };
    //  return this.PartialView("_footer", versionViewModel);
    //}
  }
}