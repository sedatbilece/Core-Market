using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();



        public IActionResult Index(int page=1)
        {

            List<Food> fl = c.Foods.OrderByDescending(x => x.FoodId).Include("Category").ToList();
            // OrderByDescending verilen parametreye göre azalan şekilde sıralar


            return View(fl.ToPagedList(page,3) );
            //.topagedlist sayfalama için ve artık viewe list değil IPagedList gönderiyoruz oradada aynı şekilde karşılanmalı
        }

        [HttpGet]
        public IActionResult FoodAdd()
        {

            List<SelectListItem> values = (from x in c.categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();

            ViewBag.listicerik = values;
            

            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food fd)
        {

            foodRepository.TAdd(fd);
            return RedirectToAction("Index");
        }


        public IActionResult FoodDelete(int id)
        {
           
            foodRepository.TDelete(new Food { FoodId=id} );

            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            Food f = new Food
            {
                FoodId=x.FoodId,
                CategoryId=x.CategoryId,
                Price=x.Price,
                FoodName=x.FoodName,
                Stock=x.Stock,
                Desc=x.Desc,
                ImageURL=x.ImageURL

            };

            List<SelectListItem> values = (from y in c.categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()

                                           }).ToList();

            ViewBag.listicerik = values;


            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food fd)
        {
            var x = foodRepository.TGet(fd.FoodId);
            x.FoodName = fd.FoodName;
            x.Stock = fd.Stock;
            x.Price = fd.Price;
            x.ImageURL = fd.ImageURL;
            x.CategoryId = fd.CategoryId;

            foodRepository.TUpdate(x);

            return RedirectToAction("Index");
        }
    }
}
