using DataModel.Football;
using FootballResultsGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace EPortfolio.Controllers
{
    public class FootballController : Controller
    {
        public ActionResult Index()
        {
            Football football = Generator.Generate();

            //var a = Directory.GetCurrentDirectory();

            //using (Stream stream = System.IO.File.Open(@".\football.bin", FileMode.Create))
            //{
            //    BinaryFormatter bin = new BinaryFormatter();
            //    football = bin.Deserialize(stream) as Football;
            //}

            return View(football);
        }
    }
}
