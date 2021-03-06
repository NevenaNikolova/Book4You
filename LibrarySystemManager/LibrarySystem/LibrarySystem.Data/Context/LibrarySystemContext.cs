﻿using LibrarySystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LibrarySystem.Data.Context
{
    public class LibrarySystemContext : IdentityDbContext<User>
    {
        public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<UsersBooks> UsersBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=LibrarySystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var genres = JsonConvert.DeserializeObject<Genre[]>(ReadJsonFile("Genres.json"));
            var authors = JsonConvert.DeserializeObject<Author[]>(ReadJsonFile("Authors.json"));
            var books = JsonConvert.DeserializeObject<Book[]>(ReadJsonFile("Books.json"));
            var towns = JsonConvert.DeserializeObject<Town[]>(ReadJsonFile("Towns.json"));

            modelBuilder.Entity<Town>().HasData(towns);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
            
            modelBuilder.Entity<UsersBooks>()
                .HasKey(p => new { p.UserId, p.BookId });

            base.OnModelCreating(modelBuilder);
        }

        private string ReadJsonFile(string fileName)
        {
            if (File.Exists("../LibrarySystem.Data/Files/" + fileName))
            {
                return File.ReadAllText("../LibrarySystem.Data/Files/" + fileName);
            }
            else
            {
                return File.ReadAllText("../../../../LibrarySystem.Data/Files/" + fileName);
            }
        }
    }
}
