﻿using CSProjeDemo1.Abstract;
using CSProjeDemo1.Entitys;
using CSProjeDemo1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.Services.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IMemberDal _memberDal;

        public MemberService(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }
        public void TDelete(Member t)
        {
           _memberDal.Delete(t);
        }

        public Member TGetById(int id)
        {
            return _memberDal.GetById(id);
        }

        public List<Member> TGetList()
        {
            return _memberDal.GetList();
        }

        public void TInsert(Member t)
        {
            _memberDal.Insert(t);
        }

        public void TUpdate(Member t)
        {
            _memberDal.Update(t);
        }
    }
}
