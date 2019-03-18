using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PocketChange.Data;
using PocketChange.Models;

namespace PocketChange.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index(Guid id)
        {
            var account = MockDataStore.Accounts.Single(o => o.Id == id);
            return View(account);
        }
    }
}