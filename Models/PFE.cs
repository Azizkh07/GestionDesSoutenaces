using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace GestionDesSoutenaces.Models
{
    public class PFE
    {
        [Key]
        public int PFEID { get; set; }

        [Required(ErrorMessage = "Le champ Titre est obligatoire.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le champ Description est obligatoire.")]
        public string Desc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Début")]
        public DateTime DateD { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Fin")]
        public DateTime DateF { get; set; }

        [ForeignKey("Encadrant")]
        public int EncadrantID { get; set; }

        public virtual ENSEIGNANT Encadrant { get; set; }

        [ForeignKey("Societe")]
        public int SocieteID { get; set; }

        public virtual SOCIETE Societe { get; set; }
    }
}
