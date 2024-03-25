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
    public class MemberService : IMemberService
    {
        private readonly IMemberDal _memberDal;

        public MemberService()
        {
            
        }
        public void TDelete(Member t)
        {
            throw new NotImplementedException();
        }

        public Member TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Member> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Member t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Member t)
        {
            throw new NotImplementedException();
        }
    }
}
