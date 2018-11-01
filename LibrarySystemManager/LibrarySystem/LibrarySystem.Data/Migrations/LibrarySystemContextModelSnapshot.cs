﻿// <auto-generated />
using System;
using LibrarySystem.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibrarySystem.Data.Migrations
{
    [DbContext(typeof(LibrarySystemContext))]
    partial class LibrarySystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibrarySystem.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new { Id = 1, Name = "George R. R. Martin" },
                        new { Id = 2, Name = "Jorge Bucay" },
                        new { Id = 3, Name = "Paulo Coelho" },
                        new { Id = 4, Name = "Dr Radeva" }
                    );
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("BooksInStore");

                    b.Property<int>("GenreId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new { Id = new Guid("73a1a1de-a54f-4578-a51f-6fe896f5c630"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Game of Thrones" },
                        new { Id = new Guid("136c7bfc-c5b9-41a3-909f-b20fed4f188f"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Clash of Kings" },
                        new { Id = new Guid("354690b9-d516-454e-9651-15d7d9e504e1"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Storm of Swords" },
                        new { Id = new Guid("b01b4f03-20ea-4dd6-a0a2-3bab3db66cbf"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Feast for Crows" },
                        new { Id = new Guid("e90de0c0-9666-46d2-a015-f1d25c6e7c20"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Dance with Dragons" },
                        new { Id = new Guid("bd7fc284-bc29-43be-b9ac-93f313f9ccfb"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "The Winds of Winter" },
                        new { Id = new Guid("41e3ccaa-144c-4f8f-9740-61d73da359fb"), AuthorId = 1, BooksInStore = 10, GenreId = 1, Title = "A Dream of Spring" }
                    );
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new { Id = 1, GenreName = "Fantasy" },
                        new { Id = 2, GenreName = "Drama" },
                        new { Id = 3, GenreName = "Action and Adventure" },
                        new { Id = 4, GenreName = "Romance" },
                        new { Id = 5, GenreName = "Mystery" },
                        new { Id = 6, GenreName = "Horror" },
                        new { Id = 7, GenreName = "Science" },
                        new { Id = 8, GenreName = "History" },
                        new { Id = 9, GenreName = "Math" },
                        new { Id = 10, GenreName = "Comics" }
                    );
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TownName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Towns");

                    b.HasData(
                        new { Id = 1, TownName = "Westphalia" },
                        new { Id = 2, TownName = "Jardine" },
                        new { Id = 3, TownName = "Brambleton" },
                        new { Id = 4, TownName = "Coleville" },
                        new { Id = 5, TownName = "Cressey" },
                        new { Id = 6, TownName = "Kiskimere" },
                        new { Id = 7, TownName = "Williamson" },
                        new { Id = 8, TownName = "Foscoe" },
                        new { Id = 9, TownName = "Stockdale" },
                        new { Id = 10, TownName = "Kimmell" },
                        new { Id = 11, TownName = "Escondida" },
                        new { Id = 12, TownName = "Zeba" },
                        new { Id = 13, TownName = "Brutus" },
                        new { Id = 14, TownName = "Galesville" },
                        new { Id = 15, TownName = "Hatteras" },
                        new { Id = 16, TownName = "Dupnitsa" }
                    );
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("AddOnDate");

                    b.Property<int>("AddressId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.UsersBooks", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("BookId");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("UsersBooks");
                });

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

            modelBuilder.Entity("LibrarySystem.Data.Models.Address", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.Town", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.Book", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Data.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.User", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibrarySystem.Data.Models.UsersBooks", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.Book", "Book")
                        .WithMany("UsersBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibrarySystem.Data.Models.User", "User")
                        .WithMany("UsersBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("LibrarySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.User")
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

                    b.HasOne("LibrarySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LibrarySystem.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
