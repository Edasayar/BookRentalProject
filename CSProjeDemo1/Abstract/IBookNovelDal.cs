using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Abstract
{
    public interface IBookNovelDal:IGenericDal<BookNovel>
    {
        void NBorrowBook(Member member, BookNovel book);
        void NReturnBook(Member member, BookNovel book);
    }
}
