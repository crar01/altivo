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

        public List<SessionWeekDto> GetCompletedPomodorosThisWeek()
        {
            try
            {
                string query = @"
                    WITH RECURSIVE DateRange AS (
                    SELECT date('now', 'weekday 0', '-6 days') AS dateWeek
                    UNION ALL
                    SELECT date(dateWeek, '+1 day')
                    FROM DateRange
                    WHERE dateWeek < date('now', 'weekday 1')
                        )
                        SELECT 
                            dr.dateWeek AS dateWeek,
                            IFNULL(COUNT(cs.Id), 0) AS Completed
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

                var res = _connection.Query<(string dateWeek, int completed)>(query);
                var resList = res.Select(r => new SessionWeekDto
                { Date = DateTime.Parse(r.dateWeek), Completed = r.completed })
                    .ToList();

                resList.RemoveAt(7); // remove last day of the week next monday
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
