using System.ComponentModel.DataAnnotations;

namespace GestionDesSoutenaces.Models
{
    public class ETUDIANT
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaiss { get; set; }

    }
}
