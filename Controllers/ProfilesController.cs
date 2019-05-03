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
    public class ProfilesController : ControllerBase
    {
        // GET api/profiles/[userId]
        [HttpGet("{userId}")]
        public ActionResult<Profile> Get(string userId)
        {
            var user = new User(SqlConnector.ExecuteRowQuery($@"
SELECT [UserId], [FirstName], [LastName], [EmailAddress]
FROM [dbo].[User]
WHERE [UserId] = '{Guid.Parse(userId)}'"));

            var accounts = SqlConnector.ExecuteQuery($@"
SELECT [AccountId], [UserId], [AccountType], [AccountNumber]
FROM [dbo].[Account]
WHERE [UserId] = '{userId}'")
                .AsEnumerable()
                .Select(o => new Account(o));

            var allTransactions = new List<Transaction>();
            foreach (var account in accounts)
            {
                var transactions = SqlConnector.ExecuteQuery($@"
SELECT [TransactionId], [AccountId], [TransactionType], [Amount], [Description], [ProcessingDate]
FROM [dbo].[Transaction]
WHERE [AccountId] = '{account.AccountId}'")
                    .AsEnumerable()
                    .Select(o => new Transaction(o));
                foreach (var transaction in transactions)
                {
                    allTransactions.Add(transaction);
                }
            }

            return new Profile(user, accounts, allTransactions);
        }
    }
}