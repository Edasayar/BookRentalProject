using CSProjeDemo1.Abstract;
using CSProjeDemo1.Concrete;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Enums;
using CSProjeDemo1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.EntityFramework
{
    public class EfBookHistoryDal : GenericRepository<BookHistory>, IBookHistoryDal
    {
        public EfBookHistoryDal(Context context) : base(context)
        {

        }

        public void HBorrowBook(Member member, BookHistory book)
        {
            if (book.Status != Status.MevcutDeğil)
            {
                return;
            }

            book.Status = Status.Mevcut;
            member.HBorrowedBooks.Add(book);
        }

        public void HReturnBook(Member member, BookHistory book)
        {
            if (member.HBorrowedBooks.Contains(book))
            {
                book.Status = Status.Mevcut;
                member.HBorrowedBooks.Remove(book);
            }
        }
    }
}
