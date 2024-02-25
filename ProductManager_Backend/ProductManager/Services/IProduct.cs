using ProductManager.Requests;
using ProductManager.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManager.Services
{
    public interface IProduct
    {
        Task<List<ProductRes>> GetAll();
        Task<ProductRes> AddProduct(ProductReq product);
        Task<ProductRes> updateProduct(ProductReq productReq,int id);
        Task<int> DeleteProduct(int id);
        Task<List<ProductRes>> GetAllProductByName(string Name);
    }
}
