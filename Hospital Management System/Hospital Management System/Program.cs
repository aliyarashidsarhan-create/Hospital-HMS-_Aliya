using Hospital_Management_System.Module;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

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

        //View All Patients
        public static void ViewPatient(HospitalContext context)
        {

            foreach(Patient patient in context.Patients) 
            {if (patient != null)
                {
                    Console.WriteLine("No patient");
                }
                else { 
                Console.WriteLine("pationId:"+patient.patientId+"Pation Name:"+patient.patientName+
                    "patient phone :"+patient.patientPhone);
            }
            }
        }
       

        //View All Doctors by Specialization
        public static void viewDoctorSpecialization(HospitalContext context)
        {
            Console.WriteLine("Serch for specialization");
            string specialization= Console.ReadLine();

           bool found= false;

           foreach(Doctor doctor in context.Doctors)
            {
                if (found == true)
                { 
                Console.WriteLine("Doctor Id:"+doctor.doctorId+"Doctor Name:"+
                    doctor.doctorName+"Doctor spetilization:"+doctor.doctorSpecialization);
            }
                else
                {
                    Console.WriteLine("No doctor found with specialization ="+specialization);
                }
            }
           

        }
        //Add an Available Time Slot for a Doctor
        public static void TimeSlotForDoctor(HospitalContext context)
        {
            Console.WriteLine("Enter Doctor Id");
            int doctorid=int.Parse(Console.ReadLine());
            Console.WriteLine("appointment id");
            int appointmentId=int.Parse(Console.ReadLine());
            Console.WriteLine("Appointment Date ");
            string appointDate=Console.ReadLine();
            Console.WriteLine("Enter Apoointment Time ");
            string appointTime=Console.ReadLine();
            Console.WriteLine("Available state");
            
            //add slot
            AvailableSlot slot=new AvailableSlot();
            slot.isBooked = false;

            
            foreach(AvailableSlot availableSlot in context.AvailableSlots)
            {
                if (doctorid == doctorid)
                {
                    Console.WriteLine("doctor is available");
                    return;
                }
                else
                {
                    Console.WriteLine("doctor not available");
                }
            }

            context.Appointments.Add(new Appointment
            {
                appointmentId = appointmentId,
                doctorId = doctorid,
                appointmentDate = appointDate,
                appointmentTime = appointTime,

            });

            slot.isBooked = true;


        }
        //Book an Appointment
        public static void BookAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter patient Id :");
            int patientId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter doctor Id");
            int doctorId=int.Parse(Console.ReadLine());

            Appointment appointment = new Appointment();

            foreach (AvailableSlot slot in context.AvailableSlots)
            {
                if (slot.doctorId == doctorId && slot.isBooked == false)
                {
                    Console.WriteLine("Available time for doctor" + slot);

                  
                }
                else
                {
                    slot.isBooked = false;
                    appointment.status = "Booked";
                    Console.WriteLine("The Doctor Not Available");

                }
            }
            

        }
        //Cancel an Appointment
        public static void CancelAppointment(HospitalContext context)
        { 
            Console.WriteLine("Enter Appintment id");
            int appointmentId = int.Parse(Console.ReadLine());

            foreach (Appointment appointment in context.Appointments)
            {
                if(appointment.status=="Canceled")
                {
                    Console.WriteLine("Appointment is Cancelled");
                }
                else
                {
                 
                    appointment.status = "Cancelled";

                }
                AvailableSlot slot = new AvailableSlot();
                slot.isBooked = false;

            }
        }
        //Create a Medical Record After a Visit
         public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.WriteLine("Enter Appointment Id");
            int appointmentId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Diagnosis");
            string diagnosis = Console.ReadLine();
            Console.WriteLine("Enter prescription");
            string prescription=Console.ReadLine();

            Appointment foundAppointment=null;

            foreach(Appointment appointment in context.Appointments)
            {
                if (appointment.appointmentId == appointmentId)
                {
                    foundAppointment = appointment;
                    break;
                }
                else
                {
                    Console.WriteLine("Appointment not found");
                    return;
                }

            }
            //add medical record 
           decimal visitFee=foundAppointment.Doctor.consultationFee;


            context.MedicalRecords.Add(
                new MedicalRecord
                {
                    appointmentId = appointmentId,
                    diagnosis = diagnosis,
                    prescription= prescription,
                    visitFee = visitFee,
                }

                );

            foundAppointment.status = "Complete";


        }
     
        //Generate a Patient Medical History Report
        public static void PatientMedicalHistory(HospitalContext context)
        {
            Console.WriteLine("Enter Patient Id");
            int patientId=int.Parse(Console.ReadLine());
      

            foreach(MedicalRecord record in context.MedicalRecords)
            {
                if(record.patientId == patientId) { 
           

                Console.WriteLine("visitDate"+ visitDate+ "doctorName"+ doctorName+
                    "diagnosis"+ diagnosis+ "prescription"+ prescription);
                }
                decimal total = 0;
                total = record.visitFee;
            }
         

        }
        //Doctor Workload and Revenue Summary
        public static void WorkloadAndRevenue(HospitalContext context)
        {
            //completed appointments//status compleate
            // cancelled.// appointment status canncelled 
            //revenue from medical record 
            //


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
                        ViewPatient(mainContext);
                        break;
                    case 4:
                        viewDoctorSpecialization(mainContext);
                        break;
                    case 5:
                        TimeSlotForDoctor(mainContext);
                        break;
                    case 6:
                        BookAppointment(mainContext);
                        break;
                    case 7:
                        CancelAppointment(mainContext);
                        break;
                    case 8:
                        CreateMedicalRecord(mainContext);
                        break;
                    case 9:
                        CreateMedicalRecord(mainContext);
                        break;
                    case 10:
                        PatientMedicalHistory(mainContext);
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


