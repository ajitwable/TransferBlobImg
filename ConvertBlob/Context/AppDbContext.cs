using ConvertBlob.Models;
using Microsoft.EntityFrameworkCore;

namespace ConvertBlob.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FileData> fileDatas { get; set; }
    }
}
