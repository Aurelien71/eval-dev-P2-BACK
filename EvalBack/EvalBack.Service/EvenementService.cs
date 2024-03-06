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
        public async Task AddEvenement(EvenementDTO evenement)
        {
            Evenement evenementDb = new Evenement()
            {
                Description = evenement.Description,
                Heure = evenement.Heure,
                Lieu = evenement.Lieu,
                Titre = evenement.Titre,
            };

            await _evenementRepository.AddEvenement(evenementDb);
        }

        public async Task<IEnumerable<Evenement>> GetAllEvenements()
        {
            return await _evenementRepository.GetAllEvenements();
        }
    }
}
