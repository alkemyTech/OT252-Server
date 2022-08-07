using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAll();

        Task<MemberDto> GetById(int? id);

        IEnumerable<Member> Find(Expression<Func<Member, bool>> predicate);

        MemberDto Insert(MemberDto member);
        Task<bool> Delete(int id);
        MemberDto putActionMember(MemberDto member, int id);
    }
}
