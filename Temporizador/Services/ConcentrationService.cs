using Altivo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altivo.Services
{
    public class ConcentrationService
    {
        private readonly SQLiteConnection _connection;

        public ConcentrationService()
        {
            _connection = DatabaseInitializer.Connection();
        }

        /// <summary>
        /// Start a new concentration session
        /// </summary>
        /// <param name="durationInMinutes"></param>
        /// <returns>id of the concentration session</returns>
        public int StartSession(int durationInMinutes)
        {
            try
            {
                var session = new ConcentrationSession { TaskName = "Task1", DurationInMinutes = durationInMinutes };
                
                _connection.Insert(session);
                return session.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EndCompletedSession(int sessionId, ConcentrationLevel concentrationLevel)
        {
            return EndSession(sessionId, concentrationLevel);            
        }

        public int EndInterruptedSession(int sessionId)
        {
            return EndSession(sessionId);
        }

        private int EndSession(int sessionId, ConcentrationLevel concentrationLevel = ConcentrationLevel.Low)
        {
            try
            {
                var session = _connection.Table<ConcentrationSession>().Where(x => x.Id == sessionId).FirstOrDefault();
                session.ConcentrationLevel = concentrationLevel;
                session.State = ConcentrationState.Complete;

                return _connection.Update(session);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
