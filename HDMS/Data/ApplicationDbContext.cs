using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HDMS.Models;

namespace HDMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HDMS.Models.Patient> Patient { get; set; } = default!;
        public DbSet<HDMS.Models.PatientData> PatientData { get; set; } = default!;
    }
}
