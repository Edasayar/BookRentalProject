
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Entitys
{
    public class Library:BaseEntity
    {
      
        public string LibraryName { get; set; }
        public  List<BaseBook> Books { get; set; }
        public  List<Member> Members { get; set; }


     
    }
}
