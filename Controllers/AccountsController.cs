using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketChange.API.Data;
using PocketChange.API.Models;

namespace PocketChange.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        // GET api/accounts
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var result = SqlConnector.ExecuteQuery(@"
SELECT [AccountId], [UserId], [AccountType], [AccountNumber]
FROM [dbo].[Account]")
                .AsEnumerable()
                .Select(o => new Account(o));
            return result;
        }

        // GET api/accounts/[accountId]
        [HttpGet("{accountId}")]
        public ActionResult<IEnumerable<Account>> Get(string accountId)
        {
            var result = SqlConnector.ExecuteQuery($@"
SELECT [AccountId], [UserId], [AccountType], [AccountNumber]
FROM [dbo].[Account]
WHERE [AccountId] = '{accountId}'")
                .AsEnumerable()
                .Select(o => new Account(o));
            return result;
        }

        // POST api/accounts
        public void Post([FromBody] Account account)
        {
            var result = SqlConnector.ExecuteNonQuery($@"
INSERT INTO [dbo].[Account] ([AccountId], [UserId], [AccountType], [AccountNumber])
VALUES ('{account.AccountId.ToString()}', '{account.UserId.ToString()}', {account.AccountType}, '{account.AccountNumber}')");
        }

        // DELETE api/accounts/[accountId]
        [HttpDelete("accountId")]
        public void Delete(string accountId)
        {
            var result = SqlConnector.ExecuteNonQuery($@"
DELETE FROM [dbo].[Account]
WHERE [AccountId] = '{accountId}'");
        }
    }
}