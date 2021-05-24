using HealthClinic.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthClinic.DAL.Contexts
{
    public partial class HealthcareContext : DbContext
    {

        public HealthcareContext()
        {
        }

        public HealthcareContext(DbContextOptions<HealthcareContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(c => c.IdDoctor);

            modelBuilder.Entity<Medicament>()
                .HasKey(c => c.IdMedicament);

            modelBuilder.Entity<Patient>()
                .HasKey(c => c.IdPatient);

            modelBuilder.Entity<Prescription>()
                .HasKey(c => c.IdPrescription);

            modelBuilder.Entity<Prescription>()
                .HasOne(c => c.IdDoctorNavigation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(c => c.IdDoctor);

            modelBuilder.Entity<Prescription>()
                .HasOne(c => c.IdPatientNavigation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(c => c.IdPatient);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(c => c.IdPrescriptionMedicament);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(c => c.IdPrescriptionNavigation)
                .WithMany(c => c.PrescriptionMedicaments)
                .HasForeignKey(c => c.IdPrescription);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(c => c.IdMedicamentNavigation)
                .WithMany(c => c.PrescriptionMedicaments)
                .HasForeignKey(c => c.IdMedicament);


            modelBuilder.Entity<Doctor>().HasData(
                new object[]
                {
                    new Doctor
                    {
                        FirstName = "Andrzej",
                        LastName = "Malewski",
                        Email = "malewski@wp.pl",
                        IdDoctor = 1
                    },
                    new Doctor
                    {
                        FirstName = "Marcin",
                        LastName = "Malędowski",
                        Email = "moleda@wp.pl",
                        IdDoctor = 2
                    },
                    new Doctor
                    {
                        FirstName = "Krzysztof",
                        LastName = "Kowalewicz",
                        Email = "kowalewicz@wp.pl",
                        IdDoctor = 3
                    }
                }

            );

            modelBuilder.Entity<Medicament>().HasData(
                new object[]
                {
                    new Medicament
                    {
                        Name = "Xanax",
                        Description = "Lorem ipsum...",
                        Type = "Depression",
                        IdMedicament = 1
                    },
                    new Medicament
                    {
                        Name = "Abilify",
                        Description = "Lorem",
                        Type = "Tabletki",
                        IdMedicament = 2
                    },
                    new Medicament
                    {
                        Name = "Abra",
                        Description = "Lorem ips",
                        Type = "Żel",
                        IdMedicament = 3
                    }
                }

            );

            modelBuilder.Entity<Patient>().HasData(
                new object[]
                {
                    new Patient
                    {
                        FirstName= "Jan",
                        LastName = "Andrzejewski",
                        Birthdate = DateTime.Now,
                        IdPatient = 1
                    },
                    new Patient
                    {
                        FirstName= "Krzysztof",
                        LastName = "Kowalewicz",
                        Birthdate = DateTime.Now,
                        IdPatient = 2
                    },
                    new Patient
                    {
                        FirstName= "Marcin",
                        LastName = "Andrzejewicz",
                        Birthdate = DateTime.Now,
                        IdPatient = 3
                    }
                }

            );

            modelBuilder.Entity<Prescription>().HasData(
                new object[]
                {
                    new Prescription
                    {
                        Date = new DateTime(2019,05,09,9,15,0),
                        DueDate = new DateTime(2020,05,09,9,15,0),
                        IdPatient = 1,
                        IdDoctor = 2,
                        IdPrescription = 1
                    },
                    new Prescription
                    {
                        Date = new DateTime(2009,05,09,9,15,0),
                        DueDate = new DateTime(2010,05,09,9,15,0),
                        IdPatient = 2,
                        IdDoctor = 1,
                        IdPrescription = 2
                    },
                    new Prescription
                    {
                        Date = new DateTime(2013,05,09,9,15,0),
                        DueDate = new DateTime(2014,05,09,9,15,0),
                        IdPatient = 3,
                        IdDoctor = 3,
                        IdPrescription = 3
                    }
                }

            );


            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new object[]
                {
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose = 4,
                        Details = "Take every morning",
                        IdPrescriptionMedicament = 1
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Dose = 1,
                        Details = "Once a week",
                        IdPrescriptionMedicament = 2
                    },
                    new PrescriptionMedicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 3,
                        Dose = 3,
                        Details = "once every two weeks",
                        IdPrescriptionMedicament = 3
                    }
                }

            );

        }
    }
}
