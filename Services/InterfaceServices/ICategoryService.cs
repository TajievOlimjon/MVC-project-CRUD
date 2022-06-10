using Domain.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceServices
{
    public  interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<int> Insert(CategoryDTO category);
        Task<int> Update(CategoryDTO category);
        Task<int> Delete(int Id);
    }
}
