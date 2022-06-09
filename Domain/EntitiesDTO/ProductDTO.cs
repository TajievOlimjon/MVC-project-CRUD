using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public  class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime GodVipuska { get; set; }
        public string? Country { get; set; }
        public string? Garantiya { get; set; }
        public int CtegoryId { get; set; }
        public List<CategoryDTO>? Categories { get; set; }
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime GodVipuska { get; set; }
        public string? Country { get; set; }
        public string? Garantiya { get; set; }
        public int CtegoryId { get; set; }
        public string? CategoryName { get; set; }

    }


}
