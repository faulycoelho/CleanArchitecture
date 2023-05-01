using Clean.Domain.Entities;
using Clean.Domain.Validation;
using FluentAssertions;

namespace Clean.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidaParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "category name");
            action.Should()
                .NotThrow<Exception>();
        }

        [Fact(DisplayName = "Create Category With Negative Id Value Should Throw Domain Exception")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "category name");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Category.Id value.");
        }

        [Fact(DisplayName = "Create Category With Short Name Should Throw Domain Exception")]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, "ca");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category.Name minimum length is 3.");
        }

        [Fact(DisplayName = "Create Category With Empty Name Should Throw Domain Exception")]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category.Name is required.");
        }

        [Fact(DisplayName = "Create Category With Blank Name Should Throw Domain Exception")]
        public void CreateCategory_WithBlankNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, " ");
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category.Name is required.");
        }

        [Fact(DisplayName = "Create Category With Null Name Should Throw Domain Exception")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category.Name is required.");
        }
    }
}