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
    public class EfBookNovelDal:GenericRepository<BookNovel>, IBookNovelDal
    {
        public EfBookNovelDal(Context context) : base(context)
        {
            
        }

        public void NBorrowBook(Member member, BookNovel book)
        {
            if (book.Status != Status.MevcutDeğil)
            {
                return;
            }

            book.Status = Status.Mevcut;
            member.NBorrowedBooks.Add(book);
        }

        public void NReturnBook(Member member, BookNovel book)
        {
            if (member.NBorrowedBooks.Contains(book))
            {
                book.Status = Status.Mevcut;
                member.NBorrowedBooks.Remove(book);
            }
        }
    }
}
