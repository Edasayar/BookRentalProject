using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Abstract
{
    public interface IBookHistoryService:IGenericService<BookHistory>
    {
        void TBorrowBook(Member member, BookHistory book);
        void TReturnBook(Member member, BookHistory book);
    }
}
