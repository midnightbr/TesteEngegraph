using System.Collections.Generic;
using TesteEngegraph.Triggers;

namespace TesteEngegraph.Services
{
    public interface ILogsService
    {
        List<Logs> GetAll();
        Logs Insert(Logs log);
    }
}
