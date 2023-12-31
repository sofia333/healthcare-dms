using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HDMS.Data;
using System;
using System.Linq;
using Humanizer;

namespace HDMS.Models;

public static class SeedData
{
    public static int GetRandomNumber(int min, int max)
    {
        Random rnd = new Random();
        int result = rnd.Next(min, max); //Gives you a number between min and max
        return result;
    }
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            if (context == null || context.Patient == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any patients.
            if (context.Patient.Any() == false)
            {


                context.Patient.AddRange(
                    new Patient
                    {
                        Name = "Sofia",
                        Surname = "Cecchini",
                        BirthDate = DateTime.Parse("1993-3-11"),
                        BSN = "93764977208",
                        Sex = "F",
                        Diagnosis = ""
                    },

                    new Patient
                    {
                        Name = "Topo",
                        Surname = "Gigio",
                        BirthDate = DateTime.Parse("1993-3-8"),
                        BSN = "298489656",
                        Sex = "M",
                        Diagnosis = ""
                    },

                    new Patient
                    {
                        Name = "Albert",
                        Surname = "Black",
                        BirthDate = DateTime.Parse("1960-3-11"),
                        BSN = "348758034578",
                        Sex = "M",
                        Diagnosis = ""
                    },

                    new Patient
                    {
                        Name = "Cinthia",
                        Surname = "Red",
                        BirthDate = DateTime.Parse("1970-3-11"),
                        BSN = "89374955",
                        Sex = "F",
                        Diagnosis = ""
                    }
                );
            }
            // Look for any patient data.
            if (context.PatientData.Any())
            {
                return;   // DB has been seeded
            }

            DateTime startDate = DateTime.Parse("2023-1-9");
            DateTime endDate = DateTime.Parse("2023-9-9");
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                context.PatientData.AddRange(

                    new PatientData
                    {
                        PatientId = 1,
                        HeartRate = GetRandomNumber(50, 70),
                        Steps = GetRandomNumber(1000, 15000),
                        BPdyastolic = GetRandomNumber(60, 80),
                        BPsystolic = GetRandomNumber(90, 120),
                        Date = date
                    },

                    new PatientData
                    {
                        PatientId = 2,
                        HeartRate = GetRandomNumber(50, 70),
                        Steps = GetRandomNumber(1000, 15000),
                        BPdyastolic = GetRandomNumber(60, 80),
                        BPsystolic = GetRandomNumber(90, 120),
                        Date = date
                    },

                    new PatientData
                    {
                        PatientId = 3,
                        HeartRate = GetRandomNumber(50, 70),
                        Steps = GetRandomNumber(1000, 15000),
                        BPdyastolic = GetRandomNumber(60, 80),
                        BPsystolic = GetRandomNumber(90, 120),
                        Date = date
                    },

                    new PatientData
                    {
                        PatientId = 4,
                        HeartRate = GetRandomNumber(50, 70),
                        Steps = GetRandomNumber(1000, 15000),
                        BPdyastolic = GetRandomNumber(60, 80),
                        BPsystolic = GetRandomNumber(90, 120),
                        Date = date
                    }
                );

            }
            context.SaveChanges();
        }
    }
}
