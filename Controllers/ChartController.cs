using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cst = new List<Class1>();
            cst.Add(new Class1
            {



            });

            return cst;
        }



        public IActionResult Statistics()
        {

            var deger1 = c.Foods.Count();//count food tabosundaki satır sayısını sayar
            ViewBag.dgr1 = deger1;

            var deger2 = c.categories.Count();
            ViewBag.dgr2 = deger2;


            ViewBag.dgr3 = c.Foods.Where(x => x.CategoryId == 1).Count();
            // categorisi 1 numaralı id olan foodların sayısı bulunur

            ViewBag.dgr4 = c.Foods.Where(x => x.CategoryId == 2).Count();


            ViewBag.dgr5 = c.Foods.Sum(x => x.Stock);
            //foods daki tüm stock sayıları toplanır;

            ViewBag.dgr6 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();

            ViewBag.dgr7 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();




            ViewBag.dgr8 = c.Foods.Average(x => x.Price).ToString("0.00");

            ViewBag.dgr9 = c.Foods.Where(x => x.Category.CategoryName == "Fruits").Sum(x => x.Stock);

            ViewBag.dgr10 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();

            return View();
        }

    }
}
