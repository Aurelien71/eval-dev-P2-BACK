using EvalBack.Entities;
namespace EvalBack.Repositories.Contracts
{
    public interface IEvenementRepository
    {
        Task AddEvenement(Evenement evenement);
        Task<IEnumerable<Evenement>> GetAllEvenements();
    }
}
