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
    public class ProductService: IProductService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductService(DataContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<ProductCategory> GetProductCategories()
        {
            var listOfProducts = (

                 from p in context.Products
                 join c in context.Categories  on p.CtegoryId equals c.Id
                 select new ProductCategory
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Price = p.Price,
                     Quantity = p.Quantity,
                     GodVipuska = p.GodVipuska,
                     Country = p.Country,
                     Garantiya = p.Garantiya,
                     CtegoryId = p.CtegoryId,
                     CategoryName=c.Name


                 }).ToList();
            if (listOfProducts == null) return new List<ProductCategory>();
            return listOfProducts;
        }

        public  List<ProductDTO> GetProducts()
        {
            var listOfProducts = (

                from p in context.Products
                select new ProductDTO
                {
                    Id=p.Id,
                    Name=p.Name,
                    Price=p.Price,
                    Quantity=p.Quantity,
                    GodVipuska=p.GodVipuska,
                    Country=p.Country,
                    Garantiya=p.Garantiya,
                    CtegoryId=p.CtegoryId
                    
                }).ToList();
            if (listOfProducts == null) return new List<ProductDTO>();
            return listOfProducts;
        }
   
       public  ProductDTO GetProductById(int Id)
        {
            var listOfProducts = (

               from p in context.Products
               where p.Id==Id
               select new ProductDTO
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
                   Quantity = p.Quantity,
                   GodVipuska = p.GodVipuska,
                   Country = p.Country,
                   Garantiya = p.Garantiya,
                   CtegoryId=p.CtegoryId
               }).FirstOrDefault();
            if (listOfProducts == null) return new ProductDTO();
            return listOfProducts;
        }
       public  int Insert(ProductDTO product)
        {
            var newProduct = mapper.Map<Product>(product);
            context.Products.Add(newProduct);
            return context.SaveChanges();
        }
       public  int Update(ProductDTO product)
        {
            var p=context.Products.Find(product.Id);

            p.Name = product.Name;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            p.GodVipuska = product.GodVipuska;
            p.Country = product.Country;
            p.Garantiya = product.Garantiya;
            p.CtegoryId = product.CtegoryId;
           return  context.SaveChanges();

        }
       public  int Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return 0;
            context.Products.Remove(product);
            return context.SaveChanges();

        }

        
    }
}
