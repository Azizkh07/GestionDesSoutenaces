using System.ComponentModel.DataAnnotations;

namespace GestionDesSoutenaces.Models
{
    public class SOCIETE
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ Libellé est obligatoire.")]
        public string Lib { get; set; }

        [Required(ErrorMessage = "Le champ Adresse est obligatoire.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est obligatoire.")]
        public string Tel { get; set; }
    }
}
