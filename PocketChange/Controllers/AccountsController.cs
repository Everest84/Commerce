using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PocketChange.Data;
using PocketChange.Models;

namespace PocketChange.Controllers
{
    public class AccountsController : Controller
    {
        [Route("/accounts")]
        public IActionResult Index()
        {
            var model = new AccountsViewModel(DatabaseOperations.GetAccounts());
            return View(model);
        }

        [Route("/accounts/{id}")]
        public IActionResult Account(string id)
        {
            var model = DatabaseOperations.GetAccountByNumber(id);
            return View(model);
        }
    }
}