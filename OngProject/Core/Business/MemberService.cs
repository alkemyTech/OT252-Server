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
        private IImageHelper _imageHelper;
        private MemberMapper memberMapper;


        public MemberService(IUnitOfWork unitOfWork, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            memberMapper = new MemberMapper();
        }


        public async Task<bool> Delete(int id)
        {
            var deleteMember =await _unitOfWork.MemberRepository.GetById(id);
            if (deleteMember == null)
            {
                return false;
            }
            await _unitOfWork.MemberRepository.Delete(deleteMember);
            _unitOfWork.Save();
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

        public async Task<ViewMemberDto> Insert(CreationMemberDto memberDto)
        {
            var imgUrl = await _imageHelper.UploadImage(memberDto.Image);
            
            Member member = memberMapper.ConvertToCreation(memberDto);
            member.Image = imgUrl;
            await _unitOfWork.MemberRepository.Insert(member);
            _unitOfWork.Save();

            ViewMemberDto newMember = memberMapper.ConvertToViewDto(member);

            return newMember;
        }

        public async Task<ViewMemberDto> putActionMember(int id, CreationMemberDto member)
        {
            var newMember = await _unitOfWork.MemberRepository.GetById(id);
            if (newMember == null)
                return null;
            var imgUrl = await _imageHelper.UploadImage(member.Image);

            if (imgUrl != null)
                newMember.Image = imgUrl.ToString();
            newMember.Name = member.Name;
            newMember.FacebookUrl = member.FacebookUrl;
            newMember.InstragramUrl = member.InstagramUrl;
            newMember.LinkedinUrl = member.LinkedinUrl;
            
            await _unitOfWork.MemberRepository.Update(newMember);
            _unitOfWork.Save();
            var viewMember = memberMapper.ConvertToViewDto(newMember);
            return viewMember;
        }
    }
}
