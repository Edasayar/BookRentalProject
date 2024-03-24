
using CSProjeDemo1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Entitys
{

    public abstract class BaseBook:BaseEntity
    {
       

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }
        public Status Status { get; set; }
    }
}
