using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Abstract
{
    public interface IBookScienceService:IGenericService<BookScience>
    {
        void TBorrowBook(Member member, BookScience book);
        void TReturnBook(Member member, BookScience book);
    }
}
