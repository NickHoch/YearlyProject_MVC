﻿using System.Data.Entity;
using Home3__MVC.Models.DbModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Home3__MVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb")
        {
            Database.SetInitializer<ApplicationContext>(new CustomInitializer<ApplicationContext>());
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ItemOrder> ItemOrder { get; set; }
        public virtual DbSet<Basis> Basis { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
    }
}