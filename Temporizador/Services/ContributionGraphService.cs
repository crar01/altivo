using Altivo.Dtos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altivo.Services
{
    public class ContributionGraphService
    {
        private readonly SQLiteConnection _connection;

        public ContributionGraphService()
        {
            _connection = DatabaseInitializer.Connection();
        }

        /// <summary>
        /// Obtiene las sesiones completadas de los últimos 365 días
        /// </summary>
        public List<DayContributionDto> GetYearContributions()
        {
            try
            {
                DateTime startDate = DateTime.Now.AddDays(-364);
                DateTime endDate = DateTime.Now;

                string query = @"
                    WITH RECURSIVE DateRange AS (
                        SELECT date(@startDate) AS dateDay
                        UNION ALL
                        SELECT date(dateDay, '+1 day')
                        FROM DateRange
                        WHERE dateDay < date(@endDate)
                    )
                    SELECT 
                        dr.dateDay AS Date,
                        IFNULL(COUNT(cs.Id), 0) AS SessionCount,
                        IFNULL(SUM(cs.DurationInMinutes), 0) AS TotalMinutes
                    FROM 
                        DateRange dr
                    LEFT JOIN 
                        ConcentrationSession cs
                        ON strftime('%Y-%m-%d', cs.CreatedAt) = dr.dateDay
                        AND cs.State = 2
                    GROUP BY 
                        dr.dateDay
                    ORDER BY 
                        dr.dateDay;
                ";

                var results = _connection.Query<(string Date, int SessionCount, int TotalMinutes)>(
                    query,
                    startDate.ToString("yyyy-MM-dd"),
                    endDate.ToString("yyyy-MM-dd")
                );

                return results.Select(r => new DayContributionDto
                {
                    Date = DateTime.Parse(r.Date),
                    SessionCount = r.SessionCount,
                    TotalMinutes = r.TotalMinutes
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener contribuciones del año: {ex.Message}");
                return new List<DayContributionDto>();
            }
        }
    }
}
