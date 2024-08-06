using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CholitosGymWebApi.Models
{
    public class ClientDTO
    {
        #region Propiedades Not Null

        [ValidateNever] // Permite que no se valide nunca una propiedad aunque la propiedad sea not null.
        public int CodigoCliente { get; set; }

        [Range(minimum: 1, maximum: 100, ConvertValueInInvariantCulture = false, ErrorMessage = "La Edad debe estar entre 1 y 100 anios")]
        public int Edad { get; set; }
        #endregion

        #region Propiedades Null
        [Required(AllowEmptyStrings = false, ErrorMessage = "Primer nombre es requerido")]
        public string? PrimerNombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo nombre es requerido")]
        public string? SegundoNombre { get; set; }

        public string? TercerNombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Primer apellido es requerido")]
        public string? PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo apellido es requerido")]
        public string? SegundoApellido { get; set; }
        public string? Genero { get; set; }
        public string? ApellidoCasada { get; set; }

        [EmailAddress(ErrorMessage = "El correo electronico es invaalido")]
        public string? CorreoElectronico { get; set; }

        public DateTime FechaNacimiento { get; set; }
        #endregion
    }
}
