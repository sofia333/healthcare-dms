using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Models;

public class PatientData
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int HeartRate { get; set; }
    public int Steps { get; set; }
    public int BPdyastolic { get; set; }
    public int BPsystolic { get; set; }

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }


    }


