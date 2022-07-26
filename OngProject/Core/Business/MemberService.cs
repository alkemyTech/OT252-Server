using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
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
        private MemberMapper memberMapper;

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

        public async Task<IEnumerable<MemberDto>> GetAll()
        {
            memberMapper = new MemberMapper();
            var listMember =await _unitOfWork.MemberRepository.GetAll();
            var membersDto = memberMapper.ConvertListToDto(listMember);
            return membersDto;
        }

        public Task<MemberDto> GetById(int? id)
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
