﻿namespace ApiNext.Data.Dtos.Familia
{
    public class UpdateFamiliaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCondominio { get; set; }
        public int Apto { get; set; }
    }
}
