using EvalBack.Context;
using EvalBack.Entities;
using EvalBack.Repositories.Contracts;

namespace EvalBack.Repositories
{
    public class EvenementRepository : IEvenementRepository
    {
        protected readonly EvenementContext Context;

        public EvenementRepository(EvenementContext context)
        {
            Context = context;
        }
        public async Task AddEvenement(Evenement evenement)
        {
            await Context.Evenements.AddAsync(evenement);
            await Context.SaveChangesAsync();
        }
    }
}
