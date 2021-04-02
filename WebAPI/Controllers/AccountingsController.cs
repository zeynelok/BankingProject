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
    public class AccountingsController : ControllerBase
    {
        IAccountingService _accountingService;
        public AccountingsController(IAccountingService accountingService)
        {
            _accountingService = accountingService;
        }

        [HttpGet("getlistofmoneytransactions")]
        public IActionResult GetListofMoneyTransactions()
        {
            var result = _accountingService.GetAll();
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("createmoneytransaction")]
        public IActionResult CreateMoneyTransaction(Accounting accounting)
        {
            var result = _accountingService.Add(accounting);
            if (!result.IsError)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
