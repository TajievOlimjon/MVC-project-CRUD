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
        Task<List<ProductCategory>> GetProductCategories();
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int Id);
        Task<int> Insert(ProductDTO product);
        Task<int> Update(ProductDTO product);
        Task<int> Delete(int id);


    }
}
