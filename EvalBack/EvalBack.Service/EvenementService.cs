using EvalBack.Entities;
using EvalBack.Repositories.Contracts;
using EvalBack.Services.Contracts;
using EvalBack.Services.Contracts.DTOs;

namespace EvalBack.Service
{
    public class EvenementService : IEvenementService
    {
        private readonly IEvenementRepository _evenementRepository;
        public EvenementService(IEvenementRepository evenementRepository)
        {
            _evenementRepository = evenementRepository;
        }
        public async Task AddEvenement(Evenement evenement)
        {
            await _evenementRepository.AddEvenement(evenement);
        }

        public async Task<Evenement> EditEvenement(Evenement evenement)
        {
            return await _evenementRepository.EditEvent(evenement);
        }

        public async Task<IEnumerable<Evenement>> GetAllEvenements()
        {
            return await _evenementRepository.GetAllEvenements();
        }

    }
}
