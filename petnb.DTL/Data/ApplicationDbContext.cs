﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data.Models;
using petnb.DTL.Migrations;
using petnb.DTL.Models;

namespace petnb.DTL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PetOffer> PetOffers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetSitterOffer> PetSitterOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pet>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(p => p.Pets)
                .HasForeignKey(k => k.UserId);

            builder.Entity<ApplicationUser>()
                .HasMany(a => a.Reviews)
                .WithOne(b => b.ReviewedApplicationUser);

            builder.Entity<PetSitterOffer>()
                .HasOne(a => a.User)
                .WithMany(b => b.PetSitterOffers);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
