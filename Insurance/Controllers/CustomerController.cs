using FluentValidation;
using Insurance.Interfaces;
using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly IValidator<Customer> _validator;

        public CustomerController(ILogger<AccountController> log, ICustomer customer, IValidator<Customer> validator)
        {
            _customer = customer;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Required] Customer customer)
        {
            _validator.Validate(customer).Errors.ForEach(x => throw new ArgumentException($"{x.ErrorMessage}"));
            await _customer.CreateCustomer(customer);
            return Ok();
        }

        [HttpGet]
        public async Task<Customer?> Get(Guid? Guid, int? Id)
        {
            if(Guid == null && Id == null)
                throw new ArgumentNullException("Even guid or Id should be provided");

            return await _customer.GetCustomer(Guid, Id);
        }
    }
}
