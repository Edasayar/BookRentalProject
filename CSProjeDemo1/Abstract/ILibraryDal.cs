using CSProjeDemo1.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Abstract
{
    public interface ILibraryDal:IGenericDal<Library>
    {
        List<BaseBook> GetAvailableBooks();
        List<BaseBook> GetBorrowedBooks();
        List<Member> GetMembers();
    }
}
