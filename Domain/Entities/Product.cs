using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime GodVipuska { get; set; }
        public string? Country { get; set; }
        public string? Garantiya { get; set; }
        public int CtegoryId { get; set; }
        public Category? Ctegory { get; set; }
        public List<Order>? Orders { get; set; }


    }
}
