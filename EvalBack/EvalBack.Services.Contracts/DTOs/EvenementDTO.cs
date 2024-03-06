namespace EvalBack.Services.Contracts.DTOs
{
    /// <summary>
    /// Classe représentant un évènement.
    /// </summary>
    public class EvenementDTO
    {
        /// <summary>
        /// Titre de l'évènement.
        /// </summary>
        public string Titre { get; set; } = default!;
        /// <summary>
        /// Description de l'évènement.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// Heure de l'évènement.
        /// </summary>
        public string Heure { get; set; } = default!;
        /// <summary>
        /// Lieu de l'évènement.
        /// </summary>
        public string Lieu { get; set; } = default!;
    }
}
