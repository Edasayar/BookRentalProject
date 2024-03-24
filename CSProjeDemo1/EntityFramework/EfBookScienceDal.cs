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
    public class EfBookScienceDal:GenericRepository<BookScience>, IBookScienceDal
    {
        public EfBookScienceDal(Context context) : base(context) 
        {
            
        }

        public void SBorrowBook(Member member, BookScience book)
        {
            if (book.Status != Status.MevcutDeğil)
            {
                return;
            }

            book.Status = Status.Mevcut;
            member.SBorrowedBooks.Add(book);
        }

        public void SReturnBook(Member member, BookScience book)
        {
            if (member.SBorrowedBooks.Contains(book))
            {
                book.Status = Status.Mevcut;
                member.SBorrowedBooks.Remove(book);
            }
        }
    }
}
