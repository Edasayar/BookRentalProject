using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Abstract
{
    public interface IBookScienceDal:IGenericDal<BookScience>
    {
        void SBorrowBook(Member member, BookScience book);
        void SReturnBook(Member member, BookScience book);
    }
}
