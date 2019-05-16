﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using petnb.DTL.Data;

namespace petnb.DTL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190514223034_petsitteradd")]
    partial class petsitteradd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.PetSitter", b =>
                {
                    b.Property<int>("PetSitterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("PetSitterId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("PetSitters");
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.PetSitterOffer", b =>
                {
                    b.Property<int>("PetSitterOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("EndOfSit");

                    b.Property<int>("ExpectedSalary");

                    b.Property<string>("Heading");

                    b.Property<string>("Location");

                    b.Property<int?>("PetSitterId");

                    b.Property<DateTime>("StartOfSit");

                    b.Property<string>("UserId");

                    b.HasKey("PetSitterOfferId");

                    b.HasIndex("PetSitterId");

                    b.HasIndex("UserId");

                    b.ToTable("PetSitterOffers");
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateGiven");

                    b.Property<string>("Heading");

                    b.Property<double>("Rating");

                    b.Property<string>("ReviewedApplicationUserId");

                    b.Property<int>("ReviewingApplicationUserId");

                    b.Property<int>("UserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewedApplicationUserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("petnb.DTL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<int?>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsPetOwner");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<double?>("Rating");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("petnb.DTL.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PetAge");

                    b.Property<string>("PetBreed");

                    b.Property<double>("PetDifficulty");

                    b.Property<string>("PetName");

                    b.Property<int>("PetType");

                    b.Property<double>("PetWeight");

                    b.Property<string>("UserId");

                    b.HasKey("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("petnb.DTL.Models.PetOffer", b =>
                {
                    b.Property<int>("PetOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("EndOfSit");

                    b.Property<string>("Heading");

                    b.Property<int?>("PetId");

                    b.Property<string>("PetLocation");

                    b.Property<string>("PetNeeds");

                    b.Property<decimal?>("Reward");

                    b.Property<DateTime>("StartOfSit");

                    b.Property<string>("UserId");

                    b.HasKey("PetOfferId");

                    b.HasIndex("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("PetOffers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("petnb.DTL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.PetSitter", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("PetSitter")
                        .HasForeignKey("petnb.DTL.Data.Models.PetSitter", "UserId");
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.PetSitterOffer", b =>
                {
                    b.HasOne("petnb.DTL.Data.Models.PetSitter")
                        .WithMany("PetSitterOffers")
                        .HasForeignKey("PetSitterId");

                    b.HasOne("petnb.DTL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("petnb.DTL.Data.Models.Review", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser", "ReviewedApplicationUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewedApplicationUserId");
                });

            modelBuilder.Entity("petnb.DTL.Models.Pet", b =>
                {
                    b.HasOne("petnb.DTL.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Pets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("petnb.DTL.Models.PetOffer", b =>
                {
                    b.HasOne("petnb.DTL.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.HasOne("petnb.DTL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
