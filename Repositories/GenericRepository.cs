using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class, new()   // gönderilen T class olmak zorunda işlem bu
    {

        Context c = new Context();




        public List<T> TList()// kategori veya food list döndürür
        {
            return c.Set<T>().ToList();
        }

        public List<T> TList(string p)// overloading
        {
            return c.Set<T>().Include(p).ToList();
        }

        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }


        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }


        public void TUpdate(T p)
        {

            c.Set<T>().Update(p);
            c.SaveChanges();
        }

        public T TGet(int id)
        {
           return  c.Set<T>().Find(id);
        }
    }
}
