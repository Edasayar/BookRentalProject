using CSProjeDemo1.Abstract;
using CSProjeDemo1.Concrete;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.EntityFramework
{
    public class EfLibraryDal:GenericRepository<Library>, ILibraryDal
    {
        public EfLibraryDal(Context context) : base(context)
        {
            
        }
    }
}
