using Dept_Labour_Immi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dept_Labour_Immi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agency> agencies { get; set; }
        public DbSet<Blacklist> blacklists { get; set; }
        public DbSet<BOD> bODs { get; set; }
        public DbSet<ThaiCompany> thaiCompanies { get; set; }
        public DbSet<DOE> dOEs { get; set; }
    }
}