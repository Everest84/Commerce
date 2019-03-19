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
        public IActionResult Index(Guid accountId)
        {
            var model = new AccountViewModel(accountId);
            return View(model);
        }
    }
}