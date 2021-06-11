using BookStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book>()
        {
                new Book{Id=1,Title="Deneme",GenreId=1,PageCount=350,PublishDate=new DateTime(2018,2,5)},
                new Book{Id=2,Title="Deneme2",GenreId=2,PageCount=450,PublishDate=new DateTime(2019,2,5)},
                new Book{Id=3,Title="Deneme3",GenreId=3,PageCount=550,PublishDate=new DateTime(2020,6,5)},
                new Book{Id=4,Title="Deneme4",GenreId=4,PageCount=650,PublishDate=new DateTime(2018,2,21)},
                new Book{Id=5,Title="Deneme5",GenreId=5,PageCount=750,PublishDate=new DateTime(2015,6,20)},
                new Book{Id=6,Title="Deneme6",GenreId=6,PageCount=850,PublishDate=new DateTime(2018,2,5)}
        };


        public List<Book> GetAll()
        {
            return _books.ToList();
        }

        public Book GetById(int id)
        {
            return _books.SingleOrDefault(x => x.Id == id);
        }

        public void Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            _books.Add(book);
        }

        public bool IsTitleExist(string title)
        {
            return _books.Any(x => x.Title == title);
        }

        public void Update(int id,Book updateBook)
        {
          
            var book = GetById(id);
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
        }

        public void Delete(int id)
        {
            _books.Remove(GetById(id));
        }
    }
} 
