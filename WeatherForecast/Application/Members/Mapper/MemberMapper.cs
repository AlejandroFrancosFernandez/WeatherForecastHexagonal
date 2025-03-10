using WeatherForecast.Application.Members.DTOs;
using WeatherForecast.Domain.Entities.Members;
using WeatherForecast.Domain.Entities.Shared;

namespace WeatherForecast.Application.Members.Mappers
{
    public static class MemberMapper
    {
        //Transform to Domain
        public static Member ToDomain(MemberDTO memberDTO)
        {
            var memberId = new MemberID(memberDTO.MemberID);
            var fullName = new MemberFullName(memberDTO.FullName);
            var email = new MemberEmail(memberDTO.Email);
            var phone = new MemberPhone(memberDTO.Phone);
            var joinDate = memberDTO.JoinDate;

            return new Member(
                memberId,
                fullName,
                email,
                phone,
                joinDate
            );
        }

        //Transform to DTO
        public static MemberDTO ToDTO(Member member)
        {
            return new MemberDTO
            {
                MemberID = member.MemberID?.Value ?? 0, 
                FullName = member.FullName.Value,
                Email = member.Email.Value,
                Phone = member.Phone?.Value,  
                JoinDate = member.JoinDate
            };
        }

       
    }
}
