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
    public class TransactionsController : ControllerBase
    {
        // GET api/transactions
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            var result = SqlConnector.ExecuteQuery(@"
SELECT [TransactionId], [AccountId], [TransactionType], [Amount], [Description], [ProcessingDate]
FROM [dbo].[Transaction]")
                .AsEnumerable()
                .Select(o => new Transaction(o));
            return result;
        }

        // GET api/transactions/[transactionId]
        [HttpGet("{transactionId}")]
        public ActionResult<Transaction> Get(string transactionId)
        {
            var result = new Transaction(SqlConnector.ExecuteRowQuery($@"
SELECT [TransactionId], [AccountId], [TransactionType], [Amount], [Description], [ProcessingDate]
FROM [dbo].[Transaction]
WHERE [TransactionId] = '{transactionId}'"));
            return result;
        }

        // POST api/transactions
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            var result = SqlConnector.ExecuteNonQuery($@"
INSERT INTO [dbo].[Transaction] ([TransactionId], [AccountId], [TransactionType], [Amount], [Description], [ProcessingDate])
VALUES ('{transaction.TransactionId.ToString()}', '{transaction.AccountId.ToString()}', {transaction.TransactionType}, {transaction.Amount}, '{transaction.Description}', '{transaction.ProcessingDate}'");
        }

        // DELETE api/transactions
        [HttpDelete("transactionId")]
        public void Delete(string transactionId)
        {
            var result = SqlConnector.ExecuteNonQuery($@"
DELETE FROM [dbo].[Transaction]
WHERE [TransactionId] = '{transactionId}'");
        }
    }
}