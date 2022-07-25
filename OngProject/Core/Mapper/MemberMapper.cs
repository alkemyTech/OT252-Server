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
    }
}
