using System.Collections.Generic;
using System.Threading.Tasks;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Models;
using CentralSpecAPI.Models.Product;

namespace CentralSpecAPI.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto newProductGroup);

        Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup();

        Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId);

        Task<ServiceResponse<GetProductGroupDto>> UpdateProductGroup(UpdateProductGroupDto ProductGroup);

        Task<ServiceResponseWithPagination<List<GetProductGroupDto>>> GetProductGroupFilter(ProductGroupFilterDto productGroupFilter);


        //Product
        Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct);

        Task<ServiceResponse<GetProductDto>> GetProductById(int productId);

        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updateProduct);


        Task<ServiceResponseWithPagination<List<GetProductDto>>> GetProductFilter(ProductFilterDto productFilter);

        Task<ServiceResponse<List<GetProductDto>>> GetProductByProductGroupId(int productGroupId);

    }
}