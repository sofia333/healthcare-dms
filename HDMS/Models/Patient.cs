using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Models;
public class Patient
{
    public int Id { get; set; }
    // patient name
    public string Name { get; set; }
    // patient surname
    public string Surname { get; set; }
    // patient birthday

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    // patient BSN
    public string BSN { get; set; }
    // patient sex
    public string Sex { get; set; }
    // patient diagnosis
    public string? Diagnosis { get; set; }

}

