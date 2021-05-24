using HealthClinic.BLL.DTOs;
using HealthClinic.BLL.Models;
using HealthClinic.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.DAL.Contexts
{
    public class MsSqlContext : IDbContext
    {
        private readonly HealthcareContext _context;

        public MsSqlContext(HealthcareContext context)
        {
            _context = context;
        }
        public Prescription AddPrescription(PrescriptionRequest request)
        {
            var prescription = new Prescription()
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdDoctor = request.IdDoctor,
                IdPatient = request.IdPatient
            };

            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();

            return prescription;
        }

        public Prescription DeletePrescription(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.IdPrescription == id);

            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();

            return prescription;
        }

        public PrescriptionDto GetPrescription(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.IdPrescription == id);
            var prescriptionMeds = _context.PrescriptionMedicaments.Where(p => p.IdPrescription == id).Select(p => p.IdMedicament).ToList();
            var meds = _context.Medicaments.Where(p => prescriptionMeds.Contains(p.IdMedicament));

            if(prescription == null)
            {
                return null;
            }

            PrescriptionDto prescriptionDto = new PrescriptionDto
            {
                IdDoctor = prescription.IdDoctor,
                IdPatient = prescription.IdPatient,
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Medicaments = new List<MedicamentDto>()
            };

            foreach(var m in meds)
            {
                prescriptionDto.Medicaments.Add(new MedicamentDto
                {
                    IdMedicament = m.IdMedicament,
                    Description = m.Description,
                    Name = m.Name,
                    Type = m.Type
                });
            }

            return prescriptionDto;
        }

        public Prescription UpdatePrescription(PrescriptionRequest request)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.IdPrescription == request.IdPrescription);
            
            if(prescription == null)
            {
                return null;
            }
            
            prescription.IdDoctor = request.IdDoctor;
            prescription.IdPatient = prescription.IdPatient;
            prescription.Date = request.Date;
            prescription.DueDate = request.DueDate;
            _context.SaveChanges();
            

            return prescription;
        }
    }
}
