﻿using DomainLayer.Models;
using Infrastructure.Repositories.BaseRepository;

namespace Infrastructure.Repositories.MatchesRepository
{
    public interface IMatchesRepository : IRepository<Matches>
    {
        Task<IEnumerable<Matches>> GetByCompetitionId(Guid id);
        Task<IEnumerable<Matches>> GetByTeamId(Guid id);
    }
}