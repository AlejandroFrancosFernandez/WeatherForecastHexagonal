﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WeatherForecast.Domain.Ports;
using WeatherForecast.Infrastructure.Persistence.DBConexion;
using WeatherForecast.Domain.Entities.AccessLogs;
using Infrastructure.Persistence.AccessLogs.Mappers;

namespace WeatherForecast.Infrastructure.Persistence.AccessLogs.Repository
{
    public class AccessLogsRepository : IAccessLogsRepository
    {
        private readonly ApplicationDbContext _context;

        public AccessLogsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All AccessLog and transform to entity domain
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AccessLog>> GetAllAsync()
        {
            string sql = "SELECT * FROM AccessLogs";
            var accessLogEntities = await _context.AccessLogs
                .FromSqlRaw(sql)
                .ToListAsync();

            return accessLogEntities.Select(entity => AccessLogMapper.MapToDomain(entity)).ToList();
        }

        /// <summary>
        /// Get AccessLog by id and transform to entity domain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccessLog?> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM AccessLogs WHERE AccessID = @AccessID";
            var parameter = new SqlParameter("@AccessID", id);

            var accessLogEntities = await _context.AccessLogs
                .FromSqlRaw(sql, parameter)
                .ToListAsync();

            return accessLogEntities.Select(entity => AccessLogMapper.MapToDomain(entity)).FirstOrDefault();
        }

        /// <summary>
        /// Create AccessLog
        /// </summary>
        /// <param name="accessLog"></param>
        /// <returns></returns>
        public async Task<AccessLog> AddAsync(AccessLog accessLog)
        {
            string sql = @"INSERT INTO AccessLogs (MemberID, AccessDateTime, AccessType, AccessStatus)
                           VALUES (@MemberID, @AccessDateTime, @AccessType, @AccessStatus);";

            var parameters = new[] {
                new SqlParameter("@MemberID", (object?)accessLog.MemberID?.Value ?? DBNull.Value),
                new SqlParameter("@AccessDateTime", accessLog.AccessDateTime.Value),
                new SqlParameter("@AccessType", accessLog.AccessType.Value),
                new SqlParameter("@AccessStatus", accessLog.AccessStatus.Value)
            };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            return accessLog;
        }

        /// <summary>
        /// Delete AccessLog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE FROM AccessLogs WHERE AccessID = @AccessID";
            var parameter = new SqlParameter("@AccessID", id);

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, parameter);
            return rowsAffected > 0;
        }
    }
}
