using System;
using System.ComponentModel.DataAnnotations.Schema;
using TesteEngegraph.Models;

namespace TesteEngegraph.Triggers
{
    public class Logs
    {
        public int Id { get; set; }
        public int IdContact { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Acao { get; set; }
    }
}
