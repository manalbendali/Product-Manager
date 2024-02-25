using Microsoft.EntityFrameworkCore;
using ProductManager.Context;
using ProductManager.Migrations;
using ProductManager.Models;
using ProductManager.Requests;
using ProductManager.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace ProductManager.Services
{
    public class ProductService : IProduct
    {
        public ProductContext Context { get; set; }
        public ProductService( ProductContext _Context) 
        {
            Context = _Context;        
        }
        public async Task<List<ProductRes>> GetAll()
        {
            var Products = await Context.Products.Select(product => new ProductRes
            {
                id=product.id,
                Name=product.Name,
                Price=product.Price,
                Checked=product.Checked,
                CreatedAt=product.CreatedAt,
                UpdatedAt=product.UpdatedAt
            })
                .ToListAsync();
            return Products;
        }

        public async Task<ProductRes> updateProduct(ProductReq productReq, int id)
        {
            var product = await Context.Products.FindAsync(id);
            if (product != null)
            {
                product.Name = productReq.Name;
                product.Price = productReq.Price;
                product.Checked = productReq.Checked;
                product.UpdatedAt = System.DateTime.Now;

                Context.Products.Update(product);
                await Context.SaveChangesAsync();

                var productRes = new ProductRes
                {
                    id = product.id,
                    Name = product.Name,
                    Price = product.Price,
                    Checked = product.Checked,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                };
                return productRes;
            }
            return null;
        }

        public async Task<int> DeleteProduct(int id)
        {
            int res = 0;
            using var transaction = Context.Database.BeginTransaction();
            var product = await Context.Products.FindAsync(id);
            try
            {
                Context.Products.Remove(product);
                res = await Context.SaveChangesAsync();
                if (res > 0)
                {
                    transaction.Commit();
                }
                return res;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return res;
            }
        }

        public async Task<ProductRes> AddProduct(ProductReq productReq)
        {
            var res = 0;
            using var transaction = Context.Database.BeginTransaction();
            try
            {
                Product product = new Product
                {
                    Name = productReq.Name,
                    Price = productReq.Price,
                    Checked = productReq.Checked,
                    CreatedAt = DateTime.Now
                };
                Context.Products.Add(product);
                res = await Context.SaveChangesAsync();
                if (res > 0)
                {
                    transaction.Commit();
                }
                var productRes = new ProductRes
                {
                    id = product.id,
                    Name = product.Name,
                    Price = product.Price,
                    Checked = product.Checked,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                };
                return productRes;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        public  async  Task<List<ProductRes>> GetAllProductByName(string Name)
        {


            var Products = await Context.Products.Select(product => new ProductRes
            {
                
                id = product.id,
                Name = product.Name,
                Price = product.Price,
                Checked = product.Checked,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            })
                .Where(product => product.Name.Contains(Name))
                   .ToListAsync();
            return Products;




        }
    }
}
