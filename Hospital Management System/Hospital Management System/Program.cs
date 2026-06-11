using Hospital_Management_System.Module;

namespace Hospital_Management_System
{
    public  class Program
    {

        static void Main(string[] args)
        {
            HospitalContext mainContext = new HospitalContext();
            mainContext.Patients = new List<Patient>();
            mainContext.Doctors= new List<Doctor>();
            mainContext.Appointments= new List<Appointment>();
            mainContext.AvailableSlots = new List<AvailableSlot>();
            mainContext.MedicalRecords = new List<MedicalRecord>();

            bool exit=false;
            while (exit == false)
            {
                Console.WriteLine("Welcome to the HMS System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1-Patient Registration");
                Console.WriteLine("2-Add a New Doctor");
                Console.WriteLine("3-View All Patients");
                Console.WriteLine("4-View All Doctors by Specialization");
                Console.WriteLine("5-Add an Available Time Slot for a Doctor");
                Console.WriteLine("6-Book an Appointment");
                Console.WriteLine("7-Cancel an Appointment");
                Console.WriteLine("8-Create a Medical Record After a Visit");
                Console.WriteLine("9-Generate a Patient Medical History Report");
                Console.WriteLine("10-Doctor Workload and Revenue Summary");
                Console.WriteLine("0-exit");

                int option=int.Parse(Console.ReadLine());

                switch(option) 
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 0:
                        exit = true;
                        break;
            }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

