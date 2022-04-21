using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        #region Props & Ctor

        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public void Create(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
            => _context.Platforms.ToList();

        public Platform GetById(int id)
            => _context.Platforms.FirstOrDefault(f => f.Id == id);

        public bool SaveChanges()
            => _context.SaveChanges() > 0;
    }
}