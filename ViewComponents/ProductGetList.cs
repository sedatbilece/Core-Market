using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class ProductGetList :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            FoodRepository fd = new FoodRepository();

            var fdlist = fd.TList();
            return View(fdlist);
        }

       
    }
}
