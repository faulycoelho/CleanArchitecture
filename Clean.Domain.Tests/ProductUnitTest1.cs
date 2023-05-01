using Clean.Domain.Entities;
using Clean.Domain.Validation;
using FluentAssertions;

namespace Clean.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]        
        public void CreateProduct_WithValidaParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "product name","product description", 99M, 10, "//images/path");
            action.Should()
                .NotThrow<Exception>();
        }


        [Fact(DisplayName = "Create Product With Negative Id Value Should Throw Domain Exception")]        
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(-1, "product name", "product description", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product.Id value.");
        }

        [Fact(DisplayName = "Create Product Long Image Value Should Throw Domain Exception")]
        public void CreateProduct_InvalidStockValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", "description", 99M, -1, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product.Stock value.");
        }

        [Fact(DisplayName = "Create Product Long Image Value Should Throw Domain Exception")]
        public void CreateProduct_InvalidPriceValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", "description", -1M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product.Price value.");
        }


        //testing Image property
        [Fact(DisplayName = "Create Product With Empty Image Valid State")]
        public void CreateProduct_WithEmptyImagemValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "name", "description", 99M, 10, "");
            action.Should()
                .NotThrow<Exception>();

        }

        [Fact(DisplayName = "Create Product With Blank Image Valid State")]
        public void CreateProduct_WithBlankImagemValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "name", "description", 99M, 10, " ");
            action.Should()
                .NotThrow<Exception>();
                
        }

        [Fact(DisplayName = "Create Product With Null Image Valid State")]
        public void CreateProduct_WithNullImagemValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "name", "description", 99M, 10, null);
            action.Should()
                .NotThrow<Exception>();                
        }


        [Fact(DisplayName = "Create Product Long Image Value Should Throw Domain Exception")]
        public void CreateProduct_LongImagemValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "name", "description", 99M, 10, "toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Image maximum length is 250.");
        }


        //testing name property
        [Fact(DisplayName = "Create Product With Short Name Should Throw Domain Exception")]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "ca", "product description", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Name minimum length is 3.");
        }

        [Fact(DisplayName = "Create Product With Empty Name Should Throw Domain Exception")]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "", "product description", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Name is required.");
        }

        [Fact(DisplayName = "Create Product With Blank Name Should Throw Domain Exception")]
        public void CreateProduct_WithBlankNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, " ", "product description", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Name is required.");
        }

        [Fact(DisplayName = "Create Product With Null Name Should Throw Domain Exception")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, null, "product description", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Name is required.");
        }



        //testing description property

        [Fact(DisplayName = "Create Product With Short Description Should Throw Domain Exception")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", "desc", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Description minimum length is 5.");
        }

        [Fact(DisplayName = "Create Product With Empty Description Should Throw Domain Exception")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", "", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Description is required.");
        }

        [Fact(DisplayName = "Create Product With Blank Description Should Throw Domain Exception")]
        public void CreateProduct_WithBlankDescriptionValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", " ", 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Description is required.");
        }

        [Fact(DisplayName = "Create Product With Null Description Should Throw Domain Exception")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalid()
        {
            Action action = () => new Product(1, "name", null, 99M, 10, "//images/path");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product.Description is required.");
        }
    }
}
