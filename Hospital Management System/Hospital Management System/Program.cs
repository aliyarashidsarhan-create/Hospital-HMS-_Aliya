using Hospital_Management_System.Module;

namespace Hospital_Management_System
{
    public  class Program
    {
        //Patient Registration
        public static void RegisterPationt(HospitalContext context)
        {
            Console.WriteLine("Patient Name");
            string patientName=Console.ReadLine();
            Console.WriteLine("Patient Age ");
            int patientAge = int.Parse(Console.ReadLine());
            Console.WriteLine("patient Gender");
            string patientGender=Console.ReadLine();
            Console.WriteLine("patient Phone");
            string patientPhone=Console.ReadLine();
            Console.WriteLine("patient Email");
            string patientEmail=Console.ReadLine();
            Console.WriteLine("patient Blood Type");
            string patientBlood=Console.ReadLine();

            int patientId = (context.Patients.Count)+ 1;

            //add patient
            context.Patients.Add(
                new Patient
                {
                    patientId = patientId,
                    patientName=patientName,
                    patientAge=patientAge,
                    patientGender=patientGender,
                    patientBloodType=patientBlood,
                    patientEmail=patientEmail,
                    patientPhone=patientPhone

                }
                );
            Console.WriteLine("patient Added Successfully with id :" +patientId);


        }

        //Add a New Doctor
        public static void AddDoctor(HospitalContext context)
        {
            Console.WriteLine("Enter doctor Name");
            string doctorName = Console.ReadLine();
            Console.WriteLine("Enter doctor Specialization");
            string doctorSpecial = Console.ReadLine();
            Console.WriteLine(" Enter doctor Phone number");
            string doctorPhone = Console.ReadLine();
            Console.WriteLine("Entetr doctor Email");
            string doctorEmail = Console.ReadLine();

            int doctorId = (context.Doctors.Count) + 1;
            //calculation fee


            // Add new doctor
            context.Doctors.Add(new Doctor
            {
                doctorId = doctorId,
                doctorName = doctorName,
                doctorSpecialization = doctorSpecial,
                doctorEmail = doctorEmail,
                doctorPhone = doctorPhone

            });
            Console.WriteLine("Doctor Added successfuly with id :"+doctorId);
        }
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
                        RegisterPationt(mainContext);
                        break;
                    case 2:
                        AddDoctor(mainContext);
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


