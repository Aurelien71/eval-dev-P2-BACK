using EvalBack.Entities;
using EvalBack.Services.Contracts.DTOs;

namespace EvalBack.Repositories.Contracts
{
    public interface IEvenementRepository
    {
        Task AddEvenement(Evenement evenement);
    }
}
