using Microsoft.AspNetCore.Mvc;
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


        public async Task<bool> Delete(int id)
        {
            var deleteMember =await _unitOfWork.MemberRepository.GetById(id);
            if (deleteMember == null)
            {
                return false;
            }
            await _unitOfWork.MemberRepository.Delete(deleteMember);
            return true;
        }

        public IEnumerable<Member> Find(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewMemberDto>> GetAll()
        {
            memberMapper = new MemberMapper();
            var listMember =await _unitOfWork.MemberRepository.GetAll();
            var membersDto = memberMapper.ConvertListToViewDto(listMember);
            return membersDto;
        }

        public Task<ViewMemberDto> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public ViewMemberDto Insert(MemberDto memberDto)
        {
            memberMapper = new MemberMapper();
            Member member = memberMapper.ConvertToMember(memberDto);

            _unitOfWork.MemberRepository.Insert(member);
            _unitOfWork.Save();

            ViewMemberDto newMember = memberMapper.ConvertToViewDto(member);

            return newMember;
        }

        public async Task<ViewMemberDto> putActionMember(MemberDto member, int id)
        {
            if (_unitOfWork.MemberRepository.GetById(id) is null) return null;
            await _unitOfWork.MemberRepository.Update(new MemberMapper().ConvertToMember(member));
            _unitOfWork.Save();
            ViewMemberDto newMember = memberMapper.ConvertToViewDto(new MemberMapper().ConvertToMember(member));
            return newMember;
        }
    }
}
