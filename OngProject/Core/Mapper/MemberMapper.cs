using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class MemberMapper
    {
        public IEnumerable<MemberDto> ConvertListToDto(IEnumerable<Member> listMembers)
        {
            List<MemberDto> listDtos = new List<MemberDto>();

            foreach (Member member in listMembers)
            {
                MemberDto memberDto = new MemberDto();
                memberDto.Name = member.Name;
                memberDto.FacebookUrl = member.FacebookUrl;
                memberDto.InstagramUrl = member.InstragramUrl;
                memberDto.LinkedinUrl = member.LinkedinUrl;
                memberDto.Image = member.Image;
                listDtos.Add(memberDto);
            }
            return listDtos;
        }

        public IEnumerable<ViewMemberDto> ConvertListToViewDto(IEnumerable<Member> listMembers)
        {
            List<ViewMemberDto> listDtos = new List<ViewMemberDto>();

            foreach (Member member in listMembers)
            {
                ViewMemberDto memberDto = new ViewMemberDto();
                memberDto.Id = member.Id;
                memberDto.Name = member.Name;
                memberDto.FacebookUrl = member.FacebookUrl;
                memberDto.InstagramUrl = member.InstragramUrl;
                memberDto.LinkedinUrl = member.LinkedinUrl;
                memberDto.Image = member.Image;
                listDtos.Add(memberDto);
            }
            return listDtos;
        }

        public MemberDto ConvertToDto (Member member)
        {
            MemberDto memberDto = new MemberDto();
            memberDto.Name = member.Name;
            memberDto.FacebookUrl = member.FacebookUrl;
            memberDto.InstagramUrl = member.InstragramUrl;
            memberDto.LinkedinUrl = member.LinkedinUrl;
            memberDto.Image = member.Image;

            return memberDto;
        }

        public ViewMemberDto ConvertToViewDto(Member member)
        {
            ViewMemberDto memberDto = new ViewMemberDto();
            memberDto.Id = member.Id;
            memberDto.Name = member.Name;
            memberDto.FacebookUrl = member.FacebookUrl;
            memberDto.InstagramUrl = member.InstragramUrl;
            memberDto.LinkedinUrl = member.LinkedinUrl;
            memberDto.Image = member.Image;

            return memberDto;
        }

        public Member ConvertToMember (MemberDto memberDto)
        {
            Member member = new Member();
            member.Name = memberDto.Name;
            member.FacebookUrl = memberDto.FacebookUrl;
            member.InstragramUrl = memberDto.InstagramUrl;
            member.LinkedinUrl = memberDto.LinkedinUrl;
            member.Image = memberDto.Image;
            
            return member;
        }
    }
}
