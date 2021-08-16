using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.VerifyPassword)
                {
                    User user = new User
                    {
                        Username = addUserViewModel.UserName,
                        Email = addUserViewModel.Email,
                        Password = addUserViewModel.Password,
                    };
                    //ViewBag.UserN = user.Username;
                    return View("Index", user);
                }
                else
                {
                    ViewBag.error = "Passwords do not match! Try again!";
                    return View("Add");
                }
            }
            else
            {
                return View("Add", addUserViewModel);
            }
        }

    }
}
