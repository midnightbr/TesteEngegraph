using System.Collections.Generic;
using System.Linq;
using TesteEngegraph.Database;
using TesteEngegraph.Triggers;

namespace TesteEngegraph.Services
{
    public class LogsService : ILogsService
    {
        private readonly DataContext _context;

        public LogsService(DataContext data)
        {
            _context = data;
        }

        public List<Logs> GetAll()
        {
            return _context.Logs.OrderBy(x => x.Id).ToList();
        }

        public Logs Insert(Logs log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();

            return log;
        }
    }
}
