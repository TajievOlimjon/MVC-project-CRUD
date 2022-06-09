using Domain.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceServices
{
    public  interface IProductService
    {
        List<ProductCategory> GetProductCategories();
        List<ProductDTO> GetProducts();

        ProductDTO GetProductById(int Id);
        int Insert(ProductDTO product);
        int Update(ProductDTO product);
        int Delete(int id);

    }
}
