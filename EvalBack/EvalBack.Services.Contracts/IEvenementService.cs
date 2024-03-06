using EvalBack.Entities;
namespace EvalBack.Services.Contracts
{
    public interface IEvenementService
    {
        Task AddEvenement(Evenement evenement);
        Task<IEnumerable<Evenement>> GetAllEvenements();
        Task<Evenement> EditEvenement(Evenement evenement);
        Task DeleteEvenement(Evenement evenement);
    }
}
