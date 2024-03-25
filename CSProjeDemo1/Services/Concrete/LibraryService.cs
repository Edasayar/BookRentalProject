using CSProjeDemo1.Abstract;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Concrete
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryDal _libraryDal;

        public LibraryService(ILibraryDal libraryDal)
        {
            _libraryDal = libraryDal;
        }
        public void TDelete(Library t)
        {
            _libraryDal.Delete(t);
        }

        public Library TGetById(int id)
        {
            return _libraryDal.GetById(id);
        }

        public List<Library> TGetList()
        {
           return _libraryDal.GetList();
        }

        public void TInsert(Library t)
        {
            _libraryDal.Insert(t);
        }

        public void TUpdate(Library t)
        {
            _libraryDal.Update(t);
        }

        public List<BaseBook> GetBooks()
        {
            var libraries = _libraryDal.GetList();
            var allBooks = libraries.SelectMany(l => l.Books).ToList();
            return allBooks;
        }

        public List<Member> GetMembers()
        {
            var libraries = _libraryDal.GetList();
            var allMembers = libraries.SelectMany(l => l.Members).ToList();
            return allMembers;
        }



    }
}
