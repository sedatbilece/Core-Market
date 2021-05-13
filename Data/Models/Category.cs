using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Kategori adı boş geçilemez")]// boş ise hata mesajı
        [StringLength(20,ErrorMessage ="4-20 only  char enter ", MinimumLength = 4)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        //bire çok ilişkide çoklu taraf category yani birden fazla food alabilir

        public List<Food> Foods { get; set; }


        // category çıkarmak için statü durumu
        public bool Status { get; set; }
    }
}
