using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Abstract
{
    public interface IBookHistoryDal:IGenericDal<BookHistory>
    {
        void HBorrowBook(Member member, BookHistory book);
        void HReturnBook(Member member, BookHistory book);
    }
}
