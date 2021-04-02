using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("getlistofaccounts")]
        public IActionResult GetListofAccounts()
        {
            var result = _accountService.GetAll();
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
           
        }

        [HttpPost("createaccount")]
        public IActionResult CreateAccount(Account account)
        {
            var result = _accountService.Add(account);
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
