using WeatherForecast.Domain.Entities.AccessLog;
using WeatherForecast.Domain.Entities.Shared;
using WeatherForecast.Infrastructure.Persistence.AccessLog.Entities;

namespace Infrastructure.Persistence.AccessLog.Mappers
{
    public static class AccessLogMapper
    {
        public static WeatherForecast.Domain.Entities.AccessLog.AccessLog MapToDomain(AccessLogEntity entity)
        {
            var accessType = string.IsNullOrEmpty(entity.AccessType) ? "Unknown" : entity.AccessType;

            return new WeatherForecast.Domain.Entities.AccessLog.AccessLog(
                entity.MemberID.HasValue ? new MemberID(entity.MemberID.Value) : null,
                new AccessDateTime(entity.AccessDateTime),
                new AccessType(accessType),
                new AccessStatus(entity.AccessStatus ?? "Unknown")
            );
        }

        public static AccessLogEntity MapToEntity(WeatherForecast.Domain.Entities.AccessLog.AccessLog domainEntity)
        {
            return new AccessLogEntity
            {
                MemberID = domainEntity.MemberID?.Value,
                AccessDateTime = domainEntity.AccessDateTime.Value,
                AccessType = domainEntity.AccessType.Value,
                AccessStatus = domainEntity.AccessStatus.Value
            };
        }
    }
}
