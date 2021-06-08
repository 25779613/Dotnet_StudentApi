using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentApi.Modals.Context
{
            public class StudentContext : IdentityDbContext {
            public StudentContext (DbContextOptions<StudentContext> options) : base (options) { }
            public DbSet<Student> students { get; set; }
        }
 }
    
        
    
