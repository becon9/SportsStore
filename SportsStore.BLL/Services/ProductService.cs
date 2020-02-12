using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Interfaces;
using System.Collections.Generic;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> Products
        {
            get
            {
                IEnumerable<Product> products = _productRepository.Products;

                IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

                return productsDto;

            }
        }

        public IEnumerable<ProductDto> ProductsWithImages
        {
            get
            {
                IEnumerable<Product> products = _productRepository.ProductsWithImages;
                IEnumerable<ProductDto> productDtos =
                    _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                return productDtos;
            }
        }

        public void SaveProduct(ProductDto productDto)
        {

            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _productRepository.SaveProduct(product);
        }

        public ProductDto DeleteProduct(int productId)
        {
            Product deleteProduct = _productRepository.DeleteProduct(productId);

            ProductDto deleteProductDto = _mapper.Map<Product, ProductDto>(deleteProduct);

            return deleteProductDto;
        }
    }
}