using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class MemberService : IMemberService
    {
        private IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Find(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Member Insert(Member member)
        {
            throw new NotImplementedException();
        }

        public Member Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
