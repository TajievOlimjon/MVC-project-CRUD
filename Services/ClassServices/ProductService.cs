using AutoMapper;
using Domain.Entities;
using Domain.EntitiesDTO;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Services.InterfaceServices;
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
        public async Task<List<ProductCategory>> GetProductCategories()
        {
            var listOfProducts =await (

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


                 }).ToListAsync();
            if (listOfProducts == null) return new List<ProductCategory>();
            return listOfProducts;
        }

        public async  Task<List<ProductDTO>> GetProducts()
        {
            var listOfProducts =await (

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
                    
                }).ToListAsync();
            if (listOfProducts == null) return new List<ProductDTO>();
            return listOfProducts;
        }
   
       public async Task<ProductDTO> GetProductById(int Id)
        {
            var listOfProducts =await  (
               from p in  context.Products
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
               }).FirstOrDefaultAsync();
            if (listOfProducts == null) return new ProductDTO();
            return  listOfProducts;
        }
       public async Task<int> Insert(ProductDTO product)
        {
            var newProduct =  mapper.Map<Product>(product);
            context.Products.Add(newProduct);
            return await context.SaveChangesAsync();
        }
       public async  Task<int> Update(ProductDTO product)
        {
            var p= await context.Products.FindAsync(product.Id);
            if (p == null) return 0;
            p.Name = product.Name;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
            p.GodVipuska = product.GodVipuska;
            p.Country = product.Country;
            p.Garantiya = product.Garantiya;
            p.CtegoryId = product.CtegoryId;
           return  await context.SaveChangesAsync();

        }
       public async  Task<int> Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return 0;
               context.Products.Remove(product);
            return await context.SaveChangesAsync();

        }

        
    }
}
