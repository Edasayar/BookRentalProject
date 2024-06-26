﻿using CSProjeDemo1.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Entitys
{
    public class Member : IdentityUser<int>,IMember
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MemberNumber { get; set; }
        public List<BookHistory>? HBorrowedBooks { get; set; }
        public List<BookNovel>? NBorrowedBooks { get; set; }
        public List<BookScience>? SBorrowedBooks { get; set; }

    }
}
