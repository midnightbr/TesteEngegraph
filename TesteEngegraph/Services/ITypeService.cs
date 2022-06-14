using System.Collections.Generic;
using TesteEngegraph.Models;

namespace TesteEngegraph.Services
{
    public interface ITypeService
    {
        List<Types> GetAll();
        Types Insert(Types tipo);
    }
}
