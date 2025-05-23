using FinalExam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DataAccessLayer
{
    public class EateryCafeDbContext:IdentityDbContext<User>
    {
        public EateryCafeDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position>Positions { get; set; }
    }
}
