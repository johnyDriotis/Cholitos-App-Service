namespace CholitosGymWebApi.Models
{
    public class ClientDTO
    {
        #region Propiedades Not Null
        public int CodigoCliente { get; set; }
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
        public string? CorreoElectronico { get; set; }
        #endregion
    }
}
