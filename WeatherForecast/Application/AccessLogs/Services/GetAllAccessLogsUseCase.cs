using WeatherForecast.Domain.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entities.AccessLogs;

namespace WeatherForecast.Application.AccessLogs.UseCases
{
    public class GetAllAccessLogsUseCase
    {
        private readonly IAccessLogsRepository _accessLogsRepository;

        public GetAllAccessLogsUseCase(IAccessLogsRepository accessLogsRepository)
        {
            _accessLogsRepository = accessLogsRepository;
        }

        public async Task<IEnumerable<AccessLog>> ExecuteAsync()
        {
            return await _accessLogsRepository.GetAllAsync();
        }
    }
}
