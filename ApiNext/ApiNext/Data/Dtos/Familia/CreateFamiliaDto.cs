namespace ApiNext.Data.Dtos.Familia
{
    public class CreateFamiliaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCondominio { get; set; }
        public int Apto { get; set; }
    }
}
