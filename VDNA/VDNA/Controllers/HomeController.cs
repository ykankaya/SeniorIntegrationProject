﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDNA.Models;

namespace VDNA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Instructions()
        {
            return View();
        }

        public ActionResult ResetDatabase()
        {
            return View();
        }

        public ActionResult XSSAttack()
        {
            return View();
        }

        public ActionResult SQLInject()
        {
            return View();
        }

        public ActionResult BruteForce()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult GenerateDatabase()
        {
            //Create Empty Database
            var myDbContext = new ApplicationDbContext();
            myDbContext.Database.Delete();
            myDbContext.Database.Create();

            //Populate tables with initial data
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(myDbContext));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(myDbContext));

            // Create Admin Role
            RoleManager.Create(new IdentityRole("Admin"));
            RoleManager.Create(new IdentityRole("User"));

            //Creating Admin Account
            PasswordHasher hasher = new PasswordHasher();
            ApplicationUser adminUser = new ApplicationUser();
            adminUser.Email = "admin@test.com";
            adminUser.EmailConfirmed = true;
            adminUser.PasswordHash = hasher.HashPassword("mockingjay");
            adminUser.UserName = "admin@test.com";
            UserManager.Create(adminUser);
            //Giving it admin privliges
            var currentUser = UserManager.FindByName(adminUser.UserName);
            UserManager.AddToRole(currentUser.Id, "Admin");
            return RedirectToAction("Register", "Account");
        }

        public void XSSDemo()
        {
            
        }
    }
}