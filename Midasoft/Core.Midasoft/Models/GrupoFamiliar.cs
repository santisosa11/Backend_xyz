namespace Core.Midasoft.Models
{
    public class GrupoFamiliar
    {
        public string? Usuario { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Genero { get; set; }
        public string? Parentesco { get; set; }
        public string? Edad { get; set; }
        public bool MenorEdad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
