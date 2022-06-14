using Microsoft.EntityFrameworkCore;
using TesteEngegraph.Models;
using TesteEngegraph.Triggers;

namespace TesteEngegraph.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}