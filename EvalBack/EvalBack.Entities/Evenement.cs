namespace EvalBack.Entities
{
    public class Evenement
    {
        public Guid Id { get; set; }
        public string Titre { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Heure { get; set; } = default!;
        public string Lieu { get; set; } = default!;
    }
}
