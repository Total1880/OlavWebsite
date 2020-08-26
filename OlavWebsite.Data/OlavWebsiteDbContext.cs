using Microsoft.EntityFrameworkCore;
using OlavWebsite.Core;

namespace OlavWebsite.Data
{
    public class OlavWebsiteDbContext : DbContext
    {
        public DbSet<Cookie> CookieList { get; set; }

        public OlavWebsiteDbContext(DbContextOptions<OlavWebsiteDbContext> options) : base (options)
        {

        }
    }
}
