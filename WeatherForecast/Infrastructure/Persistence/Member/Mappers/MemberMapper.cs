using WeatherForecast.Domain.Entities.Member;
using WeatherForecast.Domain.Entities.Shared;
using WeatherForecast.Infrastructure.Persistence.Member.Entities;

namespace WeatherForecast.Infrastructure.Persistence.Member.Mappers
{
    public static class MemberMapper
    {
        public static WeatherForecast.Domain.Entities.Member.Member MapToDomain(MemberEntity entity)
        {
            return new WeatherForecast.Domain.Entities.Member.Member(
                new MemberID(entity.MemberID),
                new MemberFullName(entity.FullName),
                new MemberEmail (entity.Email),
                new MemberPhone (entity.Phone),
                entity.JoinDate
            );
        }

        //public static MemberEntity MapToEntity(WeatherForecast.Domain.Entities.Member.Member domainEntity)
        //{
        //    return new MemberEntity
        //    {
        //        MemberID = domainEntity.MemberID.Value, // Asignamos MemberID directamente
        //        FullName = domainEntity.FullName,       // FullName es igual
        //        Email = domainEntity.Email,             // Email es igual
        //        Phone = domainEntity.Phone,             // Phone es igual
        //        JoinDate = domainEntity.JoinDate.DateTime // Convertimos JoinDate a DateTime
        //    };
        //}

    }
}
