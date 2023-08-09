using DomainLayer.Models;
using Infrastructure.Repositories.PlayerImagesRepository;


namespace ApplicationLayer.Services.PlayerImagesService
{
    public class PlayerImagesService : IPlayerImagesService
    {
        private readonly IPlayerImagesRepository _repository;

        public PlayerImagesService(IPlayerImagesRepository repository)
        {
            _repository = repository;
        }
        public async Task<PlayerImages> Add(PlayerImages PlayerImages)
        {
            try
            {
                PlayerImages.Active = "Y";
                var res = await _repository.Add(PlayerImages);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<PlayerImages>> AddRange(List<PlayerImages> PlayerImages)
        {
            try
            {
                    foreach (var item in PlayerImages)
                    {
                        item.Active = "Y";
                    }
                return await _repository.AddRange(PlayerImages);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlayerImages>> GetAll()
        {
            try
            {
                var PlayerImages = await _repository.GetAll();
                return (from u in PlayerImages.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<IEnumerable<PlayerImages>> GetByPlayerId(Guid Id)
        {
            try
            {
                var PlayerImages = await _repository.GetByPlayerId(Id);
                return (from u in PlayerImages.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerImages> GetById(Guid id)
        {
            PlayerImages res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<PlayerImages> Remove(PlayerImages PlayerImages)
        {
            try
            {
                PlayerImages.Active = "N";
                var res = await _repository.Update(PlayerImages);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerImages> Update(PlayerImages PlayerImages)
        {
            try
            {
                PlayerImages.Active = "Y";
                var res = await _repository.Update(PlayerImages);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
