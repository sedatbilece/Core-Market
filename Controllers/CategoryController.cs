using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    //[Authorize]
    public class CategoryController : Controller
    {
        Context c = new Context();

        CategoryRepository categoryRepository = new CategoryRepository();


        //[Authorize]
        public IActionResult Index()//cat listeleme işlemi
        {
           

            return View(categoryRepository.TList());
        }




        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category ct)
        {


            
            if (!ModelState.IsValid)// eger hata varsa sayfayı tekrar yükler
            {
                return View("CategoryAdd");
            }

            categoryRepository.TAdd(ct);
            return RedirectToAction("Index"); 
        }

       
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);

            return View(x);

        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)//hata alıyoruz bu fonksiyonda
        {
            var xf = categoryRepository.TGet(p.CategoryId);

            xf.CategoryName = p.CategoryName;
            xf.CategoryDescription = p.CategoryDescription;
            xf.Status = true;
            categoryRepository.TUpdate(xf);


            return RedirectToAction("Index");

        }




        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);


            return RedirectToAction("Index");
        }

    }
}
