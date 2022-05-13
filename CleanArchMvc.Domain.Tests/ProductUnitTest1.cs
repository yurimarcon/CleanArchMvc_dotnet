using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product With Valid Parameters")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product("Product Name", "Descricao", 10, 10, "Image.png");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Negative Id")]
    public void CreateProduct_WithNegativeId_ResultObjectValidState()
    {
        Action action = () => new Product(-1, "Product Name", "Descricao", 10, 10, "Image.png");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id Value.");
    }

    [Fact(DisplayName = "Create Product With Null Name")]
    public void CreateProduct_WithNullName_ResultObjectValidState()
    {
        Action action = () => new Product(null, "Descricao", 10, 10, "Image.png");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Product name is required.");
    }
    
    [Fact(DisplayName = "Create Product With Short Name")]
    public void CreateProduct_WithShortName_ResultObjectValidState()
    {
        Action action = () => new Product("Pr", "Descricao", 10, 10, "Image.png");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Product name must be more than 3 characters.");
    }
    
}