﻿using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            LibraryDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<LibraryDbContext>();

            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // Add Lender
            var user = new IdentityUser("Miroslav Mikus");
            await userManager.CreateAsync(user, "%Miro1");

            // Add Customers
            var justin = new Customer { Name = "Justin Noon" };

            var willie = new Customer { Name = "Willie Parodi" };

            var leoma = new Customer { Name = "Leoma  Gosse" };

            context.Customers.Add(justin);
            context.Customers.Add(willie);
            context.Customers.Add(leoma);

            // Add Author
            var authorDeMarco = new Author
            {
                Name = "M J DeMarco",
                Books = new List<Book>()
                {
                    new Book { Title = "The Millionaire Fastlane" },
                    new Book { Title = "Unscripted" }
                }
            };

            var authorCardone = new Author
            {
                Name = "Grant Cardone",
                Books = new List<Book>()
                {
                    new Book { Title = "The 10X Rule"},
                    new Book { Title = "If You're Not First, You're Last"},
                    new Book { Title = "Sell To Survive"}
                }
            };

            context.Authors.Add(authorDeMarco);
            context.Authors.Add(authorCardone);

            context.SaveChanges();
        }
    }
}
