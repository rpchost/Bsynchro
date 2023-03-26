using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Interfaces
{
    public interface ICustomer
    {
        Task<IActionResult> CreateCustomer(Customer customer);
        Task<Customer?> GetCustomer(Guid? guid, int? Id);
    }
}
