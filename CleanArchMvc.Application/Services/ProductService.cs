using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            // _productRepository = productRepository ?? 
            //     throw new System.ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsMediator = new GetProductsQuery();

            if(productsMediator == null)
                throw new ApplicationException(nameof(productsMediator));

            var result = await _mediator.Send(productsMediator);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productsMediator = new GetProductQuery(id);
            if(productsMediator == null)
                throw new ApplicationException(nameof(productsMediator));

            var result = await _mediator.Send(productsMediator);
            return _mapper.Map<ProductDTO>(result);
        }

        // public async Task<ProductDTO> GetProductBuCategory(int id)
        // {
        //     var productsMediator = new GetProductQuery(id);
        //     if(productsMediator == null)
        //         throw new ApplicationException(nameof(productsMediator));

        //     var result = await _mediator.Send(productsMediator);
        //     return _mapper.Map<ProductDTO>(result);
        // }

        public async Task Add(ProductDTO product)
        {
            var productEntity = _mapper.Map<ProductCreateCommand>(product);
            await _mediator.Send(productEntity);
        }

        public async Task Update(ProductDTO product)
        {
            var productEntity = _mapper.Map<ProductCreateCommand>(product);
            await _mediator.Send(productEntity);
        }

        public async Task Delete(int id)
        {
            var productsMediator = new ProductRemoveCommand(id);
            if(productsMediator == null)
                throw new ApplicationException(nameof(productsMediator));
            
            await _mediator.Send(productsMediator);
        }
    }
}