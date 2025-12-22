using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AppAgency.ASP.Models.DataAnnotation;

namespace AppAgency.ASP.Models
{
    public class CreateBookingForm
    {
        [DisplayName("Nom du client")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Le nom du client est obligatoire !")]
        [MaxLength(70, ErrorMessage = "Le nom du client a dépassé la limite de 70 caractères.")]
        public string ClientName { get; set; }
        [DisplayName("Date de réservation")]
        [DataType(DataType.Date, ErrorMessage = "Valeur non valide")]
        [Required(ErrorMessage = "La date de réservation est obligatoire !")]
        [NotEarlierThanNow(ErrorMessage = "La date sélectionnée doit être ultérieure à aujourd'hui. ")]
        public DateTime BookingDate { get; set; }

        public int DestinationId { get; set; }
        [Required(ErrorMessage = "Au moins une activité doit être sélectionnée")]
        public IEnumerable<int> ActivitiesIds { get; set; }
    }
}
