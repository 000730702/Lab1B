// I, Nigel Reimer, student number 000730702, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1B.Data;
using Lab1B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab1B.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Seed()
        {
            ApplicationUser user1 = new ApplicationUser { FirstName = "User", LastName = "One", BirthDate = DateTime.Now, Email = "User1@website.com", UserName = "User1@website.com" };
            ApplicationUser user2 = new ApplicationUser { FirstName = "User", LastName = "Two", BirthDate = DateTime.Now, Email = "User2@website.com", UserName = "User2@website.com" };

            IdentityResult result = await _userManager.CreateAsync(user1, "Password1!");

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user." });

            result = await _userManager.CreateAsync(user2, "Password2!");

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user." });

            result = await _roleManager.CreateAsync(new IdentityRole("Staff"));

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role." });

            result = await _roleManager.CreateAsync(new IdentityRole("Manager"));

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role." });

            result = await _userManager.AddToRoleAsync(user1, "Staff");

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign role." });

            result = await _userManager.AddToRoleAsync(user2, "Manager");

            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign role." });

            return RedirectToAction("Index", "Home");
        }
    }
}