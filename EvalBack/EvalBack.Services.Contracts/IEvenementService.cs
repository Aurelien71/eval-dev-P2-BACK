using EvalBack.Entities;
using EvalBack.Services.Contracts.DTOs;

namespace EvalBack.Services.Contracts
{
    public interface IEvenementService
    {
        Task AddEvenement(EvenementDTO evenement);
        Task<IEnumerable<Evenement>> GetAllEvenements();
    }
}
