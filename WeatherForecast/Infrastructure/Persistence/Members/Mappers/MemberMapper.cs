using WeatherForecast.Domain.Entities.Members;
using WeatherForecast.Domain.Entities.Shared;
using WeatherForecast.Infrastructure.Persistence.Members.Entities;

namespace WeatherForecast.Infrastructure.Persistence.Members.Mappers
{
    public static class MemberMapper
    {
        public static Member MapToDomain(MemberEntity entity)
        {
            return new Member(
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
        //        FullName = domainEntity.FullName.Value,       // FullName es igual
        //        Email = domainEntity.Email.Value,             // Email es igual
        //        Phone = domainEntity.Phone.Value,             // Phone es igual
        //        JoinDate = domainEntity.JoinDate.DateTime // Convertimos JoinDate a DateTime
        //    };
        //}

    }
}
