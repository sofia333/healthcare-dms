namespace HDMS.Models
{
    // Input of POST: Patients/GetNewData
    public class Dataex
    {
        // selected date
        public DateTime Date { get; set; }
        // patient id
        public int PatientId { get; set; }
    }
}
