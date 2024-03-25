using CSProjeDemo1.Abstract;
using CSProjeDemo1.EntityFramework;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Concrete
{
    public class BookScienceService : IBookScienceService
    {
        private readonly IBookScienceDal _bookScienceDal;
        

        public BookScienceService(IBookScienceDal bookScienceDal)
        {
            _bookScienceDal = bookScienceDal;
           
        }

        public void TBorrowBook(Member member, BookScience book)
        {
            _bookScienceDal.SBorrowBook(member, book);
        }

        public void TDelete(BookScience t)
        {
            _bookScienceDal.Delete(t);
        }

        public BookScience TGetById(int id)
        {
            return _bookScienceDal.GetById(id);
        }

        public List<BookScience> TGetList()
        {
            return _bookScienceDal.GetList();
        }

        public void TInsert(BookScience t)
        {
            _bookScienceDal.Insert(t);
        }

        public void TReturnBook(Member member, BookScience book)
        {
            _bookScienceDal.SReturnBook(member, book);
        }

        public void TUpdate(BookScience t)
        {
           _bookScienceDal.Update(t);
        }
    }
}
