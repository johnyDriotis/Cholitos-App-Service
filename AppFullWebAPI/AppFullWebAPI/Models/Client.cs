namespace CholitosGymWebAPI.Models
{
    public class Client
    {
        #region Propiedades Not Null
        public int Id { get; set; }
        public int Edad { get; set; }
        #endregion

        #region Propiedades Null
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? TercerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Genero { get; set; }
        public string? ApellidoCasada { get; set; }
        #endregion


    }
}
