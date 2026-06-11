using Hospital_Management_System.Module;

namespace Hospital_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalContext mainContext = new HospitalContext();
            mainContext.Patients = new List<Patient>();
            mainContext.Doctors= new List<Doctor>();
            mainContext.Appointments= new List<Appointment>();
            mainContext.AvailableSlots = new List<AvailableSlot>();
            mainContext.MedicalRecords = new List<MedicalRecord>();


         
        }
    }
}
