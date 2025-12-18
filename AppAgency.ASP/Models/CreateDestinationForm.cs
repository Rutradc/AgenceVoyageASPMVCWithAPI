using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppAgency.ASP.Models
{
    public class CreateDestinationForm
    {
        [DisplayName("Pays")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Le pays est obligatoire !")]
        [MaxLength(150, ErrorMessage = "Le pays a dépassé la limite de 150 caractères.")]
        public string Country { get; set; }
        [DisplayName("Ville")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La ville est obligatoire !")]
        [MaxLength(100, ErrorMessage = "La ville a dépassé la limite de 100 caractères.")]
        public string City { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La description est obligatoire !")]
        [MaxLength(255, ErrorMessage = "La description a dépassé la limite de 255 caractères.")]
        public string Description { get; set; }

        public CreateDestinationForm() {}
    }
}
