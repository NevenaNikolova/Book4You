﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Data.Models;
using LibrarySystem.Services;
using LibrarySystem.Services.Services;
using LibrarySystem.WebClient.Areas.Administration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.WebClient.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUsersServices _usersServices;
        private readonly IAddressService _addressService;
        private readonly ITownService _townService;

        public UsersController(UserManager<User> userManager, IUsersServices usersServices, IAddressService addressService, ITownService townService)
        {
            _userManager = userManager;
            _usersServices = usersServices;
            _addressService = addressService;
            _townService = townService;
        }

        public IActionResult Index()
        {
            var users = this._userManager
                .Users
                .Include(u => u.Address)
                    .ThenInclude(a => a.Town)
                .Include(u => u.UsersBooks)
                    .ThenInclude(ub => ub.Book)
                .Select(u => new UserViewModel(u))
                .ToList();

            return View(users);
        }
        public IActionResult ActiveUsers()
        {
            var users = this._usersServices
                .ListUsers(false)
                .Select(u => new UserViewModel(u))
                .ToList();
            return View(users);
        }

        public IActionResult Details(string id)
        {
            var user = this._usersServices.GetUserById(id);
            var model = new UserViewModel(user);
            return View(model);
        }
        public IActionResult Delete(string id)
        {
            this._usersServices.RemoveUserById(id);
            return this.RedirectToAction("ActiveUsers", "Users");
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(string id, string title)
        {
            if (this.ModelState.IsValid)
            {
                this._usersServices.BorrowBook(id, title);
            }
            return this.RedirectToAction("Details", "Users", new { id });
        }

        [HttpGet]
        public IActionResult RemoveBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveBook(string id, string title)
        {
            if (this.ModelState.IsValid)
            {
                this._usersServices.ReturnBook(id, title);
            }
            return this.RedirectToAction("Details", "Users", new { id });
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserViewModel model)
        {
            var town = this._townService.AddTown(model.Town);
            var address = this._addressService.AddAddress(model.Address, town);

            if (this.ModelState.IsValid)
            {
                this._usersServices.UpdateUser(model.Id, model.FirstName, model.MiddleName, model.LastName, model.Phone, address);
            }
            return this.RedirectToAction("Details", "Users", new { model.Id });
        }

    }
}