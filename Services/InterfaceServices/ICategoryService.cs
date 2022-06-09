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
        List<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryById(int id);
        int Insert(CategoryDTO category);
        int Update(CategoryDTO category);
        int Delete(int Id);
    }
}
