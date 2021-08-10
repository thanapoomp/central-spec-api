using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using CentralSpecAPI.Data;
using CentralSpecAPI.DTOs.Product;
using CentralSpecAPI.Models;
using CentralSpecAPI.Models.Product;
using System.Linq.Dynamic.Core;
using CentralSpecAPI.Helpers;

namespace CentralSpecAPI.Services.Product
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _dBContext;
        private readonly ILogger<ProductService> _log;
        private readonly IHttpContextAccessor _httpContext;

        public ProductService(IMapper mapper, IHttpContextAccessor httpContext, AppDBContext dBContext, ILogger<ProductService> log) : base(dBContext, mapper, httpContext)
        {
            this._httpContext = httpContext;
            this._log = log;
            this._mapper = mapper;
            this._dBContext = dBContext;
        }

        #region "ProductGroup"

        public async Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto newProductGroup)
        {
            var productGroup = new ProductGroup();
            productGroup.Name = newProductGroup.Name;
            productGroup.CreatedBy = Guid.Parse(GetUserId());
            productGroup.CreatedDate = Now();
            productGroup.IsActive = true;
            productGroup.StatusId = 1;

            await _dBContext.ProductGroups.AddAsync(productGroup);
            await _dBContext.SaveChangesAsync();

            var dto = _mapper.Map<ProductGroup, GetProductGroupDto>(productGroup);


            return ResponseResult.Success(dto);


        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup()
        {
            List<ProductGroup> list_ProductGroup = new List<ProductGroup>();

            list_ProductGroup = await _dBContext.ProductGroups.Include(x => x.Product).AsNoTracking().ToListAsync();

            var dto = _mapper.Map<List<GetProductGroupDto>>(list_ProductGroup);

            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId)
        {
            var productGroup = await _dBContext.ProductGroups
            .Include(x => x.Product).Where(x => x.Id == productGroupId).SingleOrDefaultAsync();

            var dto = _mapper.Map<GetProductGroupDto>(productGroup);

            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponseWithPagination<List<GetProductGroupDto>>> GetProductGroupFilter(ProductGroupFilterDto productGroupFilter)
        {
            //Add data to queryable
            var queryable = _dBContext.ProductGroups.AsQueryable();

            //Check Condition for Search
            if (!string.IsNullOrWhiteSpace(productGroupFilter.Name))
            {
                queryable = queryable.Where(x => x.Name == productGroupFilter.Name);
            }

            if (productGroupFilter.StatusId != 0)
            {
                queryable = queryable.Where(x => x.StatusId == productGroupFilter.StatusId);
            }

            if (!string.IsNullOrWhiteSpace(productGroupFilter.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{productGroupFilter.OrderingField} {(productGroupFilter.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                {
                    return ResponseResultWithPagination.Failure<List<GetProductGroupDto>>($"Could not Productgroup by field: {productGroupFilter.OrderingField}");
                }
            }

            //add data to pagination
            var paginationResult = await _httpContext.HttpContext
           .InsertPaginationParametersInResponse(queryable, productGroupFilter.RecordsPerPage, productGroupFilter.Page);

            var lst_ProductGroup = await queryable.Paginate(productGroupFilter).ToListAsync();

            var dto = _mapper.Map<List<GetProductGroupDto>>(lst_ProductGroup);

            return ResponseResultWithPagination.Success(dto, paginationResult);

        }

        public async Task<ServiceResponse<GetProductGroupDto>> UpdateProductGroup(UpdateProductGroupDto updateProductGroup)
        {
            var productGroup = await _dBContext.ProductGroups.Where(x => x.Id == updateProductGroup.Id).FirstOrDefaultAsync();

            if (productGroup is null)
            {
                _log.LogError("Error: ProductGroup not found");
                return ResponseResult.Failure<GetProductGroupDto>($"ProductGroup not found ProductGroupID : {updateProductGroup.Id}");
            }

            if (!string.IsNullOrWhiteSpace(updateProductGroup.Name))
            {
                productGroup.Name = updateProductGroup.Name;
            }
            productGroup.StatusId = updateProductGroup.StatusId;
            productGroup.UpdatedBy = Guid.Parse(GetUserId());
            productGroup.UpdatedDate = Now();

            _dBContext.Update(productGroup);
            await _dBContext.SaveChangesAsync();

            _log.LogInformation("Update ProductGroup Success");
            var dto = _mapper.Map<GetProductGroupDto>(productGroup);

            return ResponseResult.Success(dto);

        }

        #endregion


        #region  "Product"

        public async Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct)
        {
            var productGroup = await _dBContext.ProductGroups.Where(x => x.Id == newProduct.ProductGroupId).FirstOrDefaultAsync();

            if (productGroup is null)
            {
                _log.LogError("Error: ProductGroup not found");
                return ResponseResult.Failure<GetProductDto>($"ProductGroup not found ProductGroupID : {newProduct.ProductGroupId}");
            }

            var product = new Models.Product.Material();
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Stock = newProduct.Stock;
            product.ProductGroupId = newProduct.ProductGroupId;
            product.IsActive = true;
            product.StatusId = 1;
            product.CreatedBy = Guid.Parse(GetUserId());
            product.CreatedDate = Now();

            await _dBContext.Products.AddAsync(product);
            await _dBContext.SaveChangesAsync();

            var dto = _mapper.Map<GetProductDto>(product);

            return ResponseResult.Success<GetProductDto>(dto);
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int productId)
        {
            var product = await _dBContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product is null)
            {
                _log.LogError("Error: Product not found");
                return ResponseResult.Failure<GetProductDto>($"Product not found ProductID : {productId}");
            }

            var dto = _mapper.Map<GetProductDto>(product);

            return ResponseResult.Success<GetProductDto>(dto);

        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updateProduct)
        {
            var productGroup = await _dBContext.ProductGroups.Where(x => x.Id == updateProduct.ProductGroupId).FirstOrDefaultAsync();

            if (productGroup is null)
            {
                _log.LogError("Error: ProductGroup not found");
                return ResponseResult.Failure<GetProductDto>($"ProductGroup not found ProductGroupID : {updateProduct.ProductGroupId}");
            }


            var product = await _dBContext.Products.Where(x => x.Id == updateProduct.Id).FirstOrDefaultAsync();

            if (product is null)
            {
                _log.LogError("Error: Product not found");
                return ResponseResult.Failure<GetProductDto>($"Product not found ProductID : {updateProduct.Id}");
            }

            if (!string.IsNullOrWhiteSpace(updateProduct.Name))
            {
                product.Name = updateProduct.Name;
            }


            product.Price = updateProduct.Price;
            product.Stock = updateProduct.Stock;
            product.StatusId = updateProduct.StatusId;
            product.UpdatedBy =  Guid.Parse(GetUserId());
            product.UpdatedDate = Now();

            _dBContext.Update(product);
            await _dBContext.SaveChangesAsync();

            _log.LogInformation("Update Product Success");
            var dto = _mapper.Map<GetProductDto>(product);

            return ResponseResult.Success(dto);
        }



        public async Task<ServiceResponseWithPagination<List<GetProductDto>>> GetProductFilter(ProductFilterDto productFilter)
        {
            var queryable = _dBContext.Products
            .Include(x => x.ProductGroup)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(productFilter.Name))
            {
                queryable = queryable.Where(x => x.Name.Contains(productFilter.Name));
            }

            if (productFilter.StatusId != 0)
            {
                queryable = queryable.Where(x => x.StatusId == productFilter.StatusId);
            }

            if (productFilter.ProductGroupId != 0)
            {
                queryable = queryable.Where(x => x.ProductGroupId == productFilter.ProductGroupId);
            }

            if (!string.IsNullOrWhiteSpace(productFilter.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{productFilter.OrderingField} {(productFilter.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                {
                    return ResponseResultWithPagination.Failure<List<GetProductDto>>($"Could not Product by field: {productFilter.OrderingField}");
                }
            }

            //add data to pagination
            var paginationResult = await _httpContext.HttpContext
           .InsertPaginationParametersInResponse(queryable, productFilter.RecordsPerPage, productFilter.Page);

            var lst_ProductGroup = await queryable.Paginate(productFilter).ToListAsync();

            var dto = _mapper.Map<List<GetProductDto>>(lst_ProductGroup);

            return ResponseResultWithPagination.Success(dto, paginationResult);

        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetProductByProductGroupId(int productGroupId)
        {
            var product = await _dBContext.Products.Where(x => x.ProductGroupId == productGroupId).ToListAsync();

            var dto = _mapper.Map<List<GetProductDto>>(product);
            return ResponseResult.Success(dto);
        }


        #endregion

    }
}