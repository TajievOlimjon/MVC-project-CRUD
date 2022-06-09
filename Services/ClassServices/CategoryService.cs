using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDTO;
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

        public List<CategoryDTO> GetCategories()
        {
            var list = (from c in context.Categories
                        select new CategoryDTO
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description
                        }).ToList();
            return list;
        }
        public CategoryDTO GetCategoryById(int id)
        {
            var list = (from c in context.Categories
                        where c.Id == id
                        select new CategoryDTO
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description
                        }).FirstOrDefault();
            if (list == null) return new CategoryDTO();
            return list;
        }
        public int Insert(CategoryDTO category)
        {
            var newCategory = mapper.Map<Category>(category);
            context.Categories.Add(newCategory);
            return context.SaveChanges();
        }
        public int Update(CategoryDTO category)
        {
            var c = context.Categories.Find(category.Id);
            if (c == null) return 0;
            c.Name = category.Name;
            c.Description = category.Description;
           return  context.SaveChanges();
        }
        public int Delete(int Id)
        {
            var category = context.Categories.Find(Id);
            if (category == null) return 0;
            context.Categories.Remove(category);
            return context.SaveChanges();
        }

        
    }
}
