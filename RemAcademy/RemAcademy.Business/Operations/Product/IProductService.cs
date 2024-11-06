using RemAcademy.Business.Operations.Product.Dtos;
using RemAcademy.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Product
{
    public interface IProductService
    {
        Task<ServiceMessage> AddProduct(AddProductDto product);
        Task<ProductDto> GetProduct(int id);
        Task<List<ProductDto>> GetProducts();
        Task<ServiceMessage> ChangeCourseName(int id, string changeBy);
        Task<ServiceMessage> DeleteProduct(int id);
        Task<ServiceMessage> UpdateProduct(UpdateProductDto product);
    }
}
