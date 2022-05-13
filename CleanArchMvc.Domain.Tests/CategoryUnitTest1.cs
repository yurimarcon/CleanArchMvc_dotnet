using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Invalid Id")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id Value.");
    }

    [Fact(DisplayName = "Create Category With Short Name")]
    public void CreateCategory_ShortName_DomainExceptionInvalid()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Category name must be more than 3 characters.");
    }

    [Fact(DisplayName = "Create Category Without Name")]
    public void CreateCategory_WithoutName_DomainExceptionInvalid()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Category name is required.");
    }

    [Fact(DisplayName = "Create Category With null Name")]
    public void CreateCategory_WithNullName_DomainExceptionInvalid()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Category name is required.");
    }
}