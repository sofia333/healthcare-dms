using HDMS.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HDMS.Models
{
    public class PatientDashboard
    {

        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }

        public string Diagnosis { get; set; }
        public int HeartRateLatest { get; set; }
        public int StepsLatest { get; set; }
        public int BPdyastolicLatest { get; set; }
        public int BPsystolicLatest { get; set; }
        public List<int> HeartRateTrend { get; set; }
        public List<int> StepsTrend { get; set; }
        public List<int> BPdyastolicTrend { get; set; }
        public List<int> BPsystolicTrend { get; set; }
        public List<DateTime> Dates { get; set; }

        [Display(Name = "Select Date")]
        [DataType(DataType.Date)]
        public DateTime LatestDate { get; set; }

    }
}
