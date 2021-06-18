using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartmanProje.Models;

namespace CoreDepartmanProje.Controllers
{
    public class Birims : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Birims.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewDepart()
        {
            return View();

        }
        [HttpPost]
        public IActionResult NewDepart(Birim d)
        {
            var dept = c.Birims.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");//new DEpart HttpGet-POst use because add not empty value

        }
        public IActionResult DeleteDepart(int birimId)
        {
            var delDept = c.Birims.Find(birimId);
            c.Birims.Remove(delDept);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDepart(int birimId)
        {
            var dept = c.Birims.Find(birimId);
            return View("GetDepart",dept);
        }
        public IActionResult BirimDetail(int id)
        {
            var values = c.Personels.Where(x => x.birimId == id).ToList();
            var birimAd = c.Birims.Where(x => x.BirimId == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.dgr = birimAd;
            return View(values);


        }
      public IActionResult UpdateDepart(Birim d)
        {
            var dept = c.Birims.Find(d.BirimId);
            dept.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
