using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppAgency.ASP.Models
{
    public class CreateActivityForm
    {
        [DisplayName("Titre")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Le titre est obligatoire !")]
        [MaxLength(150, ErrorMessage = "Le titre a dépassé la limite de 150 caractères.")]
        public string Title { get; set; }
        [DisplayName("Description")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La description est obligatoire !")]
        [MaxLength(200, ErrorMessage = "La description a dépassé la limite de 200 caractères.")]
        public string Description { get; set; }
        [DisplayName("Prix")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Le prix est obligatoire !")]
        public decimal Price { get; set; }
        [DisplayName("Pays")]
        [Range(0, int.MaxValue, ErrorMessage = "Veuillez indiquer une valeur d'id valide")]
        [Required(ErrorMessage = "L'id de destination est obligatoire !")]
        public int DestinationId { get; set; }

        public CreateActivityForm()
        {
        }
    }
}
