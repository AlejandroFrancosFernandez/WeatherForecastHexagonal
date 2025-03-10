
using WeatherForecast.Domain.Entities.AccessLogs;
using WeatherForecast.Domain.Entities.Shared;
using WeatherForecast.Infrastructure.Persistence.AccessLogs.Entities;

namespace Infrastructure.Persistence.AccessLogs.Mappers
{
    public static class AccessLogMapper
    {
        public static AccessLog MapToDomain(AccessLogEntity entity)
        {
            var accessType = string.IsNullOrEmpty(entity.AccessType) ? "Unknown" : entity.AccessType;

            return new AccessLog(
                entity.MemberID.HasValue ? new MemberID(entity.MemberID.Value) : null,
                new AccessDateTime(entity.AccessDateTime),
                new AccessType(accessType),
                new AccessStatus(entity.AccessStatus ?? "Unknown")
            );
        }

        public static AccessLogEntity MapToEntity(AccessLog domainEntity)
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
