using EvalBack.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvalBack.Context
{
    public class EvenementContext : DbContext
    {
        public EvenementContext(DbContextOptions<EvenementContext> options)
    : base(options)
        {
        }

        public DbSet<Evenement> Evenements => Set<Evenement>();
    }
}
