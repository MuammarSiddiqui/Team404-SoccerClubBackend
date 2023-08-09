using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PlayerImagesRepository
{
    public class PlayerImagesRepository : Repository<PlayerImages>, IPlayerImagesRepository
    {
        public PlayerImagesRepository(MyContext db) : base(db)
        {
        }

        public async Task<IEnumerable<PlayerImages>> AddRange(List<PlayerImages> playerImages)
        {
            await DbSet.AddRangeAsync(playerImages);
            await SaveChanges();
            return playerImages;
        }

        public async Task<IEnumerable<PlayerImages>> GetByPlayerId(Guid id)
        {
            return await DbSet.Where(x => x.PlayerId == id).ToListAsync();
        }
    }
}
