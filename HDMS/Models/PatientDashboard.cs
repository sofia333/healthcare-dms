using HDMS.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

//Dashboard: objects containing the patient's data shown when first landing to GET: Patients/Details/5
namespace HDMS.Models
{
    public class PatientDashboard
    {

        public int PatientId { get; set; }
        // patient name
        public string Name { get; set; }
        // patient surname
        public string Surname { get; set; }
        // patient birthdate
        public DateTime BirthDate { get; set; }
        // patient sex
        public string Sex { get; set; }
        // patient diagnosis

        public string Diagnosis { get; set; }
        // latest heart rate value recorded
        public int HeartRateLatest { get; set; }
        // latest step number value recorded
        public int StepsLatest { get; set; }
        // latest dyasolic blood value pressure recorded
        public int BPdyastolicLatest { get; set; }
        // latest systolic blood value pressure recorded
        public int BPsystolicLatest { get; set; }
        // heart rate weekly trend (from 6 days prior the selected date to the selected date)
        public List<int> HeartRateTrend { get; set; }
        // steps weekly trend (from 6 days prior the selected date to the selected date)
        public List<int> StepsTrend { get; set; }
        // dyasolic blood pressure weekly trend (from 6 days prior the selected date to the selected date)
        public List<int> BPdyastolicTrend { get; set; }
        // systolic blood pressure weekly trend (from 6 days prior the selected date to the selected date)
        public List<int> BPsystolicTrend { get; set; }
        // respective dates, chart x axis
        public List<DateTime> Dates { get; set; }

        [Display(Name = "Select Date")]
        [DataType(DataType.Date)]
        // selectd date
        public DateTime LatestDate { get; set; }

    }
}
