using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDesSoutenaces.Models
{
    public class PFE_ETUDIANT
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("PFE")]
        public int PFEID { get; set; }

        public virtual PFE PFE { get; set; }

        [ForeignKey("Etudiant")]
        public int EtudiantID { get; set; }

        public virtual ETUDIANT Etudiant { get; set; }
    }

}
