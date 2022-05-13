using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, decimal stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, decimal stock, string image)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id Value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, decimal stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidationDomain(string name, string description, decimal price, decimal stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Product name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Product name must be more than 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
                "Product description is required");
            DomainExceptionValidation.When(description.Length < 5, 
                "Product description must be more than 5 characters");
            DomainExceptionValidation.When(price <= 0,
                "Product price must be greater than 0");
            DomainExceptionValidation.When(stock < 0, 
                "Product stock must be greater than 0");
            DomainExceptionValidation.When(image.Length > 50, 
                "Product image name must be less than 50 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}