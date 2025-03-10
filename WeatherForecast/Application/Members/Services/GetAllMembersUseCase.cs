using WeatherForecast.Application.Members.DTOs;
using WeatherForecast.Domain.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Application.Members.Mappers;

namespace WeatherForecast.Application.Members.UseCases
{
    public class GetAllMembersUseCase
    {
        private readonly IMemberRepository _memberRepository;

        public GetAllMembersUseCase(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberDTO>> ExecuteAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            return members.Select(MemberMapper.ToDTO);  
        }
    }
}
