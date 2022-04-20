using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        #region Ctor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #endregion
    }
}