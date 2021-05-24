using HealthClinic.BLL.DTOs;
using HealthClinic.BLL.Models;

namespace HealthClinic.BLL.Interfaces
{
    public interface IDbContext
    {
        PrescriptionDto GetPrescription(int id);
        Prescription AddPrescription(PrescriptionRequest p);
        Prescription UpdatePrescription(PrescriptionRequest p);
        Prescription DeletePrescription(int id);
    }
}
