﻿using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Models;
using LibrarySystem.Services.Abstract;
using System.Linq;
using LibrarySystem.Services.ViewModels;
using System.Collections.Generic;
using LibrarySystem.Services.Exceptions.BookServices;
using LibrarySystem.Services.Exceptions.BookServiceExeptions;
using LibrarySystem.Services.Exceptions.GenreServices;
using LibrarySystem.Services.Exceptions.AuthorServices;
using LibrarySystem.Services.Abstract.Contracts;

namespace LibrarySystem.Services
{
    public class BooksServices : BaseServicesClass, IBooksServices
    {
        public BooksServices(ILibrarySystemContext context, IValidations validations) : base(context, validations)
        {
        }

        public Book AddBook(string title, Genre genre, Author author, string bookInStore)
        {
            this.validations.BookTitleValidation(title);

            int numberOfBook;
            if (!int.TryParse(bookInStore, out numberOfBook))
            {
                throw new InvalidBookServiceParametersExeption("Invalid number");
            }

            this.validations.BookInStoreValidation(numberOfBook);

            var currentBook = this.context.Books.FirstOrDefault(b => b.Title == title);

            if (currentBook == null)
            {
                currentBook = new Book
                {
                    Title = title,
                    GenreId = genre.Id,
                    AuthorId = author.Id,
                    BooksInStore = numberOfBook
                };

                this.context.Books.Add(currentBook);
            }
            else
            {
                currentBook.BooksInStore += numberOfBook;
            }

            this.context.SaveChanges();
            return currentBook;
        }

        public BookViewModel GetBook(string bookTitle)
        {
            this.validations.BookTitleValidation(bookTitle);

            var findBook = context.Books
                .Select(b => new BookViewModel
                {
                    Title = b.Title,
                    Author = b.Author.Name,
                    Genre = b.Genre.GenreName
                })
                .Where(b => b.Title == bookTitle).ToList();

            if (!findBook.Any())
            {
                throw new AddBookNullableExeption("There is no such book in this Library.");
            }

            return findBook[0];
        }

        public IEnumerable<BookViewModel> ListOfBooksByGenre(string byGenre)
        {
            this.validations.GenreValidation(byGenre);

            var booksByGenre = context.Books
                .Select(b => new BookViewModel
                {
                    Title = b.Title,
                    Author = b.Author.Name,
                    Genre = b.Genre.GenreName
                })
                .Where(g => g.Genre == byGenre).ToList();

            if (!booksByGenre.Any())
            {
                throw new AddGenreNullableExeption("There is no such genre in this Library.");
            }

            return booksByGenre;
        }

        public IEnumerable<BookViewModel> ListOfBooksByAuthor(string byAuthor)
        {
            this.validations.AuthorValidation(byAuthor);

            var booksByAuthor = context.Books
                .Select(b => new BookViewModel
                {
                    Title = b.Title,
                    Author = b.Author.Name,
                    Genre = b.Genre.GenreName
                })
                .Where(g => g.Author == byAuthor).ToList();

            if (!booksByAuthor.Any())
            {
                throw new AddAuthorNullableExeption("There is no such author in this Library.");
            }

            return booksByAuthor;
        }

    }
}
