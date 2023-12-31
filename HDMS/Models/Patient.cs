using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public string BSN { get; set; }
    public string Sex { get; set; }
    public string? Diagnosis { get; set; }

}

