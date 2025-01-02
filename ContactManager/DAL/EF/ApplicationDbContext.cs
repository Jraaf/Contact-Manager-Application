using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Contact> Contacts { get; set; }
}
