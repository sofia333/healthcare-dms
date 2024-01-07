using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Models;

public class PatientData
{
    public int Id { get; set; }
    // corresponding patient id
    public int PatientId { get; set; }
    // heart rate value (average value throughout the day)
    public int HeartRate { get; set; }
    // steps number (average value throughout the day)
    public int Steps { get; set; }
    // dyastolic blood pressure (average value throughout the day)
    public int BPdyastolic { get; set; }
    // systolic blood pressure (average value throughout the day)
    public int BPsystolic { get; set; }
    // date in which he above values were recorded and sent to the DB
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }


    }


