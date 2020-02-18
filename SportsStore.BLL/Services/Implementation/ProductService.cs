using Microsoft.EntityFrameworkCore;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.DAL;
using SportsStore.DAL.Entities;
using SportsStore.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.BLL.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _uow.Products.Add(product);
        }

        public void Update(ProductDto entity)
        {
            Product product = _mapper.Map<ProductDto, Product>(entity);
            _uow.Products.Update(product);
        }

        public void Remove(ProductDto entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            var product = new Product {Id = id};
            _uow.Products.Remove(product);
        }

        public ProductDto GetById(int id)
        {
            Product product = _uow.Products.GetById(id);

            ProductDto productDto = _mapper.Map<Product, ProductDto>(product);

            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            IEnumerable<Product> products = _uow.Products.GetAll();

            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return productDtos;
        }

        public IEnumerable<ProductDto> GetProductsWithImages()
        {
            IList<Product> products = _uow.Products
                .GetAll(include: queryable => queryable
                    .Include(p => p.Image));

            IEnumerable<ProductDto> productDtos =
                _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            return productDtos;
        }

        public IEnumerable<string> GetCategories()
        {
            IEnumerable<string> categories = _uow.Products.GetAll()
                .Select(product => product.Category)
                .Distinct();
            return categories;
        }
    }
}