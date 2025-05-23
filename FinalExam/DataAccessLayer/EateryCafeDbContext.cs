using FinalExam.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DataAccessLayer
{
    public class EateryCafeDbContext:DbContext
    {
        public EateryCafeDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position>Positions { get; set; }
    }
}
