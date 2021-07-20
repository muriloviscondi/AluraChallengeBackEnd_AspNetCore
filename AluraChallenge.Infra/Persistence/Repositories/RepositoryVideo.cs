using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces.Repositories;
using AluraChallenge.Infra.Persistence.Repositories.Base;
using System;

namespace AluraChallenge.Infra.Persistence.Repositories
{
    public class RepositoryVideo : RepositoryBase<Video>, IRepositoryVideo
    {
        protected readonly AluraChallengeContext _context;

        public RepositoryVideo(AluraChallengeContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
