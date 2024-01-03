using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCI_WebAPI.Models
{
    public class Visit
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

        [ForeignKey(nameof(Hospital))]
        public Guid HospitalId { get; set; }
        public virtual Hospital? Hospital { get; set; }

    }
}
