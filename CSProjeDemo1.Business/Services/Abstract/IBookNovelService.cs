using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Abstract
{
    public interface IBookNovelService:IGenericService<BookNovel>
    {
        void TBorrowBook(Member member, BookNovel book);
        void TReturnBook(Member member, BookNovel book);
    }


}
