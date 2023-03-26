using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Interfaces
{
    public interface IAccount
    {
        Task<IActionResult> CreateAccount(int customerId, double initialCredit);
    }
}
