using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidation: AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidation()
        {
            RuleFor(a => a.UserName)
               .NotEmpty().WithMessage("{UserName} is required")
               .NotNull()
               .MaximumLength(50).WithMessage("{UserName} must not excced 50 chracters ");

            RuleFor(a => a.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required");

            RuleFor(a => a.TotalPrice)
               .NotEmpty().WithMessage("{TotalPrice} is required")
               .GreaterThan(0).WithMessage("{TotalPrice} should be greatr then 0");
        }
    }
}
