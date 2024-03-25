using CSProjeDemo1.Abstract;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Concrete
{
    public class BookHistoryService : IBookHistoryService
    {
        private readonly IBookHistoryDal _bookHistoryDal;
      



        public BookHistoryService(IBookHistoryDal bookHistoryDal)
        {
            _bookHistoryDal = bookHistoryDal;
            
        }

        public void TBorrowBook(Member member, BookHistory book)
        {
            _bookHistoryDal.HBorrowBook(member, book);
        }

        public void TDelete(BookHistory t)
        {
            _bookHistoryDal.Delete(t);
        }

        public BookHistory TGetById(int id)
        {
            return _bookHistoryDal.GetById(id);
        }

        public List<BookHistory> TGetList()
        {
            return _bookHistoryDal.GetList();
        }

        public void TInsert(BookHistory t)
        {
            _bookHistoryDal.Insert(t);
        }

        public void TReturnBook(Member member, BookHistory book)
        {
            _bookHistoryDal.HReturnBook(member, book);
        }

        public void TUpdate(BookHistory t)
        {
           _bookHistoryDal.Update(t);
        }
    }
}
