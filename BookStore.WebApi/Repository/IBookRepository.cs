using BookStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.WebApi.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        bool IsTitleExist(string title);
        void Add(Book book);
        void Update(int id,Book updateBook);

        void Delete(int id);
    }
}
