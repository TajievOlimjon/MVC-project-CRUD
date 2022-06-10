using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDTO;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Services.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClassServices
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CategoryService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            var list =await (from c in context.Categories
                        select new CategoryDTO
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description
                        }).ToListAsync();
            return list;
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var list = await (from c in context.Categories
                        where c.Id == id
                        select new CategoryDTO
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description
                        }).FirstOrDefaultAsync();
            if (list == null) return new CategoryDTO();
            return list;
        }
        public async Task<int> Insert(CategoryDTO category)
        {
            var newCategory = mapper.Map<Category>(category);
            await context.Categories.AddAsync(newCategory);
            return await context.SaveChangesAsync();
        }
        public async Task<int> Update(CategoryDTO category)
        {
            var c = await context.Categories.FindAsync(category.Id);
            if (c == null) return 0;
            c.Name = category.Name;
            c.Description = category.Description;
           return await  context.SaveChangesAsync();
        }
        public async Task<int> Delete(int Id)
        {
            var category = await context.Categories.FindAsync(Id);
            if (category == null) return 0;
             context.Categories.Remove(category);
            return await context.SaveChangesAsync();
        }

        
    }
}
