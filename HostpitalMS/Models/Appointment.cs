namespace HostpitalMS.Models
{
    public class Appointment
    {
        public int  AppointmentId { get; set; }
        public string patientName { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
