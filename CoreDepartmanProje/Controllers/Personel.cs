using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartmanProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CoreDepartmanProje.Controllers
{
    public class Personel : Controller
    {
        Context c = new Context();
        [Authorize]

        public IActionResult Index()
        {
            var per = c.Personels.Include(x => x.Birim).ToList();//Bire çok ilşki yönetimi
            return View(per);
        }
        [HttpGet]
        public IActionResult NewPersonel()
        {
            List<SelectListItem> values = (from x in c.Birims.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BirimAd,
                                               Value = x.BirimId.ToString()


                                           }).ToList();
            ViewBag.dgr = values;
            return View();
           

        }
        [HttpPost]
        /*public IActionResult NewPersonel(Personel p1)
        {
            var per = c.Birims.Where(x => x.BirimId==p1.Birim.birimId).FirstOrDefault();
            p1.Birim = per;
            c.Personels.Add(p1);
            c.SaveChanges();
            return RedirectToAction("Index");
         

        }*/
        public IActionResult DeletePersonel(int personelId)
        {
            var delPers = c.Personels.Find(personelId);
            c.Personels.Remove(delPers);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetDepart(int birimId)
        {
            var dept = c.Personels.Find(birimId);
            return View("GetDepart", dept);
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
