using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data.Models;
using petnb.DTL.Data.Models.Enums;
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
        public DbSet<PetSitter> PetSitters { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

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

            builder.Entity<PetSitter>()
                .HasOne(p => p.ApplicationUser)
                .WithOne(o => o.PetSitter)
                .HasForeignKey<PetSitter>(u => u.UserId);

            builder.Entity<PetSitterOffer>()
                .HasOne(u => u.PetSitter)
                .WithMany(p => p.PetSitterOffers)
                .HasForeignKey(k => k.PetSitterId);

            builder.Entity<PetSitterOfferPetTypeModel>()
                .HasKey(ps => new {ps.PetSitterOfferId, ps.PetTypeId});

            builder.Entity<PetSitterOfferPetTypeModel>()
                .HasOne(a => a.PetTypeModel)
                .WithMany(o => o.PetSitterOfferPetTypeModels)
                .HasForeignKey(o => o.PetTypeId);

            builder.Entity<PetSitterOfferPetTypeModel>()
                .HasOne(k => k.PetSitterOffer)
                .WithMany(u => u.PetSitterOfferPetTypeModels)
                .HasForeignKey(k => k.PetSitterOfferId);

            builder.Entity<Experience>()
                .HasOne(p => p.PetSitter)
                .WithOne(o => o.Experience)
                .HasForeignKey<Experience>(u => u.PetSitterId);

            builder.Entity<PetType>().HasData(
                new PetType {PetTypeEnum = PetTypeEnum.Dog, PetTypeId = 1},
                new PetType { PetTypeEnum = PetTypeEnum.Cat, PetTypeId = 2 },
                new PetType { PetTypeEnum = PetTypeEnum.Bird, PetTypeId = 3 },
                new PetType { PetTypeEnum = PetTypeEnum.Fish, PetTypeId = 4 },
                new PetType { PetTypeEnum = PetTypeEnum.Reptile, PetTypeId = 5 },
                new PetType { PetTypeEnum = PetTypeEnum.Hamster, PetTypeId = 6 }
            );

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
