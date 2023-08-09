﻿using DomainLayer.Models;
using Infrastructure.Repositories.PlayerStatsRepository;


namespace ApplicationLayer.Services.PlayerStatsService
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly IPlayerStatsRepository _repository;

        public PlayerStatsService(IPlayerStatsRepository repository)
        {
            _repository = repository;
        }
        public async Task<PlayerStats> Add(PlayerStats PlayerStats)
        {
            try
            {
                PlayerStats.Active = "Y";
                var res = await _repository.Add(PlayerStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlayerStats>> GetAll()
        {
            try
            {
                var PlayerStats = await _repository.GetAll();
                return (from u in PlayerStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<PlayerStats>> GetByMatchId(Guid Id)
        {
            try
            {
                var PlayerStats = await _repository.GetByMatchId(Id);
                return (from u in PlayerStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<PlayerStats>> GetByPlayerId(Guid Id)
        {
            try
            {
                var PlayerStats = await _repository.GetByPlayerId(Id);
                return (from u in PlayerStats.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerStats> GetById(Guid id)
        {
            PlayerStats res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
                return null;
            }
            return res;
        }

        public async Task<PlayerStats> Remove(PlayerStats PlayerStats)
        {
            try
            {
                PlayerStats.Active = "N";
                var res = await _repository.Update(PlayerStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerStats> Update(PlayerStats PlayerStats)
        {
            try
            {
                PlayerStats.Active = "Y";
                var res = await _repository.Update(PlayerStats);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}