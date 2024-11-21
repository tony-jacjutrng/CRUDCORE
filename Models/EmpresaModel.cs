using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class EmpresaModel
    {
        [Required(ErrorMessage = "El campo Cif es obligatorio")]
        public int Cif { get; set; }

        [Required(ErrorMessage = "El campo Nombre completo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Localidad es obligatorio")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string Direccion { get; set; }
    }
}
