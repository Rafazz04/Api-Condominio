namespace ApiNext.Data.Dtos.Morador
{
    public class CreateMoradorDto
    {
        public int Id { get; set; }
        public int IdFamilia { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
