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
    public class BookNovelService : IBookNovelService
    {
        private readonly IBookNovelDal _bookNovelDal;
       
        public BookNovelService(IBookNovelDal bookDal)
        {
            _bookNovelDal = bookDal;
            

        }

        public void TBorrowBook(Member member, BookNovel book)
        {
            _bookNovelDal.NBorrowBook(member, book);
        }

        public void TDelete(BookNovel t)
        {
            _bookNovelDal.Delete(t);
        }

        public BookNovel TGetById(int id)
        {
            return _bookNovelDal.GetById(id);
        }

        public List<BookNovel> TGetList()
        {
            return _bookNovelDal.GetList();
        }

        public void TInsert(BookNovel t)
        {
            _bookNovelDal.Insert(t);
        }

        public void TReturnBook(Member member, BookNovel book)
        {
            _bookNovelDal.NReturnBook(member, book);
        }

        public void TUpdate(BookNovel t)
        {
            _bookNovelDal.Update(t);
        }
    }
}
