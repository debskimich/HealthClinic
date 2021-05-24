using System;
using System.Collections.Generic;

namespace HealthClinic.BLL.DTOs
{
    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public ICollection<MedicamentDto> Medicaments { get; set; }
    }
}
