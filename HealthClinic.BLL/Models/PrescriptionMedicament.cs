namespace HealthClinic.BLL.Models
{
    public partial class PrescriptionMedicament
    {
        public int IdPrescriptionMedicament { get; set; }
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

        public virtual Medicament IdMedicamentNavigation { get; set; }
        public virtual Prescription IdPrescriptionNavigation { get; set; }
    }
}
