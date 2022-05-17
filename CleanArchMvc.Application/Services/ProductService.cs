using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository ?? 
                throw new System.ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductBuCategory(int? id)
        {
            var products = await _productRepository.GetByCategoryAsync(id);
            return _mapper.Map<ProductDTO>(products);
        }

        public async Task Add(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.Create(productEntity);
        }

        public async Task Update(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.Update(productEntity);
        }

        public async Task Delete(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.Delete(product);
        }
    }
}