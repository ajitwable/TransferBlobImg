using ConvertBlob.Models;
using Microsoft.EntityFrameworkCore;

namespace ConvertBlob.Context
{
    public class TargetDbContext : DbContext
    {
        public TargetDbContext(DbContextOptions<TargetDbContext> options) : base(options) 
        {
        }

        public DbSet<FileData> fileData { get; set; }
    }
}
