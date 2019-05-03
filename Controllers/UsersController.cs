using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketChange.API.Data;
using PocketChange.API.Models;

namespace PocketChange.API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var result = SqlConnector.ExecuteQuery(@"
SELECT [UserId], [FirstName], [LastName], [EmailAddress]
FROM [dbo].[User]")
                .AsEnumerable()
                .Select(o => new User(o));
            return result;
        }

        // GET api/users/[userId]
        [HttpGet("{userId}")]
        public ActionResult<User> Get(string userId)
        {
            var user = new User(SqlConnector.ExecuteRowQuery($@"
SELECT [UserId], [FirstName], [LastName], [EmailAddress]
FROM [dbo].[User]
WHERE [UserId] = '{Guid.Parse(userId)}'"));
            return user;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            var result = SqlConnector.ExecuteNonQuery($@"
INSERT INTO [dbo].[User] ([UserId], [FirstName], [LastName], [EmailAddress])
VALUES ('{user.UserId}', '{user.FirstName}', '{user.LastName}', '{user.EmailAddress}')");
        }

        // DELETE api/users/[userId]
        [HttpDelete("{userId}")]
        public void Delete(Guid userId)
            => SqlConnector.ExecuteNonQuery($@"
DELETE FROM [dbo].[User]
WHERE [UserId] = {userId}");
    }
}
