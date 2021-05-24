using System;
using System.ComponentModel.DataAnnotations;

namespace HealthClinic.BLL.DTOs
{
    public class PrescriptionRequest
    {
        
        public int? IdPrescription { get; set; }

        [Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "DueDate required")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "IdPatient required")]
        public int IdPatient { get; set; }
        [Required(ErrorMessage = "IdDoctor required")]
        public int IdDoctor { get; set; }

    }
}
