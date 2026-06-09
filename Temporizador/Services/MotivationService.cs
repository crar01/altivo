using Altivo.Dtos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Services
{
    public class MotivationService
    {
        private readonly SQLiteConnection _connection;

        public MotivationService() 
        {
            _connection = DatabaseInitializer.Connection();
        }

        public List<Altivo.Models.ConcentrationSession> GetCompletedSessionsThisMonth()
        {
            try
            {
                var beginningOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd 00:00:00");
                string query = "SELECT * FROM ConcentrationSession WHERE State = 2 AND CreatedAt >= ?";
                return _connection.Query<Altivo.Models.ConcentrationSession>(query, beginningOfMonth);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Altivo.Models.ConcentrationSession>();
            }
        }

        public List<Altivo.Models.ConcentrationSession> GetCompletedSessionsLastMonth()
        {
            try
            {
                var beginningOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var beginningOfLastMonth = beginningOfMonth.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00");
                var endOfLastMonth = beginningOfMonth.AddSeconds(-1).ToString("yyyy-MM-dd 23:59:59");
                string query = "SELECT * FROM ConcentrationSession WHERE State = 2 AND CreatedAt >= ? AND CreatedAt <= ?";
                return _connection.Query<Altivo.Models.ConcentrationSession>(query, beginningOfLastMonth, endOfLastMonth);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Altivo.Models.ConcentrationSession>();
            }
        }

        public List<Altivo.Models.ConcentrationSession> GetCompletedSessionsLastSixMonths()
        {
            try
            {
                var beginningOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var beginningOfPeriod = beginningOfCurrentMonth.AddMonths(-6).ToString("yyyy-MM-dd 00:00:00");
                var endOfPeriod = beginningOfCurrentMonth.AddMonths(1).ToString("yyyy-MM-dd 00:00:00");

                string query = "SELECT * FROM ConcentrationSession WHERE State = 2 AND CreatedAt >= ? AND CreatedAt < ? ORDER BY CreatedAt ASC";
                return _connection.Query<Altivo.Models.ConcentrationSession>(query, beginningOfPeriod, endOfPeriod);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Altivo.Models.ConcentrationSession>();
            }
        }

        public List<SessionWeekDto> GetCompletedPomodorosThisWeek()
        {
            try
            {
                string query = @"
                    WITH RECURSIVE DateRange AS (
                    SELECT date('now', 'localtime', 'weekday 0', '-6 days') AS dateWeek
                    UNION ALL
                    SELECT date(dateWeek, '+1 day')
                    FROM DateRange
                    WHERE dateWeek < date('now', 'localtime', 'weekday 1')
                        )
                        SELECT 
                            dr.dateWeek AS dateWeek,
                            IFNULL(COUNT(cs.Id), 0) AS Completed,
                            IFNULL(SUM(cs.DurationInMinutes), 0) AS TotalMinutes
                        FROM 
                            DateRange dr
                        LEFT JOIN 
                            ConcentrationSession cs
                            ON strftime('%Y-%m-%d', cs.CreatedAt) = dr.dateWeek
                            AND cs.State = 2
                        GROUP BY 
                            dr.dateWeek
                        ORDER BY 
                            dr.dateWeek;
                    ";

                var res = _connection.Query<(string dateWeek, int completed, int totalMinutes)>(query);
                var resList = res.Select(r => new SessionWeekDto { 
                    Date = DateTime.Parse(r.dateWeek), 
                    Completed = r.completed,
                    TotalMinutes = r.totalMinutes
                }).ToList();

                if (resList.Count == 8)
                {
                    resList.RemoveAt(7); // remove last day of the week next monday
                }

                return resList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los pomodoros completados por día esta semana: {ex.Message}");
                return new List<SessionWeekDto>();
            }
        }
    }
}
