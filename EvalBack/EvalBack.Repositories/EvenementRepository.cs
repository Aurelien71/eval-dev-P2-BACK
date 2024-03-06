using EvalBack.Context;
using EvalBack.Entities;
using EvalBack.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Evenement> EditEvent(Evenement evenement)
        {
            var result = Context.Evenements.Update(evenement);

            await Context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Evenement>> GetAllEvenements()
        {
            return await Context.Evenements.ToListAsync();
        }
    }
}
