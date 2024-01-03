using HCI_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HCI_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
