using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductQuery(int id)
        {
            Id = id;
        }        
    }
}