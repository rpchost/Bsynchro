using Insurance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(ILogger<AccountController> log, IAccount account)
        {
            _account = account;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int CustomerId, double InitialCredit)
        {
            await _account.CreateAccount(CustomerId, InitialCredit);
            return Ok();
        }
		
    }
}
