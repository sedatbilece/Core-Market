using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            CategoryRepository ctrp = new CategoryRepository();

            var liste = ctrp.TList();
            return View(liste);
        }





    }
}
