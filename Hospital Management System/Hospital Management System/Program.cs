using Hospital_Management_System.Module;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital_Management_System
{
    public  class Program
    {
        //Patient Registration
        public static void RegisterPationt(List<Patient> patients)
        {
            Console.WriteLine("Patient Name");
            string patientName=Console.ReadLine();

            Console.WriteLine("Patient Age ");
            int patientAge = int.Parse(Console.ReadLine());

            Console.WriteLine("patient Gender (male /Female)");
            string patientGender=Console.ReadLine();

            Console.WriteLine("patient Phone");
            string patientPhone=Console.ReadLine();

            Console.WriteLine("patient Email");
            string patientEmail=Console.ReadLine();

            Console.WriteLine("patient Blood Type");
            string patientBlood=Console.ReadLine();

            int patientId = (patients.Count)+ 1;

            //add patient
            //patientList.Add(
            //    new Patient
            //    {
            //        patientId = patientId,
            //        patientName = patientName,
            //        patientAge = patientAge,
            //        patientGender = patientGender,
            //        patientBloodType = patientBlood,
            //        patientEmail = patientEmail,
            //        patientPhone = patientPhone

            //    }
            //    );
            patients.Add(new Patient(patientId, patientName, patientAge, patientGender, patientPhone, patientEmail, patientBlood));
            Console.WriteLine($"patient Added Successfully with id : +patientId");

            //take first 3 patient
            var TakePatient = patients.Take(3).ToList();
           

        }

        //Add a New Doctor
        public static void AddDoctor(List<Doctor> doctors)
        {
            Console.WriteLine("Enter doctor Name");
            string doctorName = Console.ReadLine();

            Console.WriteLine("Enter doctor Specialization");
            string doctorSpecial = Console.ReadLine();

            Console.WriteLine(" Enter doctor Phone number");
            string doctorPhone = Console.ReadLine();

            Console.WriteLine("Entetr doctor Email");
            string doctorEmail = Console.ReadLine();

            Console.WriteLine("Entetr consulation fee");
            decimal fee =decimal.Parse(Console.ReadLine());

            int doctorId = (doctors.Count) + 1;
            //calculation fee


            // Add new doctor
            //DoctorList.Add(new Doctor
            //{
            //    doctorId = doctorId,
            //    doctorName = doctorName,
            //    doctorSpecialization = doctorSpecial,
            //    doctorEmail = doctorEmail,
            //    doctorPhone = doctorPhone

            //});
            doctors.Add(new Doctor(doctorId,doctorName,doctorSpecial,doctorPhone,doctorEmail,fee));
            Console.WriteLine($"Doctor Added successfuly with id :+doctorId");
        }

        //View All Patients
        // Patients only  →  receives List<Patient>
        public static void ViewPatient(List<Patient>patients)
        {
        //    bool isfound = false;
        //    foreach(Patient patient in context.Patients) 
        //    {if (patient == null)
        //        {
        //            isfound = true;
                  
        //           Console.WriteLine($"pationId:" + patient.patientId + "Pation Name:" + patient.patientName +
        //           "patient phone :" + patient.patientPhone);
        //        }
                               
        //    }
        //    if (isfound==false) {
        //        Console.WriteLine("patent not found!");
        //    }

           Console.WriteLine("All Registerd Patients");
            if(patients.Count==0)
            {
                Console.WriteLine("No patent have registerd");
                return;
            }
            //to print each patient
            foreach (Patient p in patients)
            {
                p.printInfo();
            }
        }
        public static void viewAllPatientOlderThanFifty(List<Patient> patients)
        {
            Console.WriteLine("All Registerd Patients");
            if(patients.Count == 0) 
            {
                Console.WriteLine("No patients Registerd");
                return;
            }
            List<Patient> olderThanFifty=patients.Where(p=>p.patientAge>50).ToList();

            foreach(Patient p in olderThanFifty)
            {
                p.printInfo();
            }
        }

        //View All Doctors by Specialization
        //recives List<doctor>
        public static void viewDoctorSpecialization(List<Doctor>doctors)
        {
            Console.WriteLine("Serch for specialization");

            Console.WriteLine("Enter specialization");
            string specialization= Console.ReadLine();

            //bool found = false;

            //foreach (Doctor doctor in context.Doctors)
            //{
            //    if (doctor.doctorSpecialization.Equals(specialization))
            //    {

            //        found = true;

            //        Console.WriteLine("Doctor Id:" + doctor.doctorId + "Doctor Name:" +
            //        doctor.doctorName + "Doctor spetilization:" + doctor.doctorSpecialization);
            //    }

            //}

            //if (found == false)
            //{

            //    Console.WriteLine("No doctor found with specialization =" + specialization);

            //}
        
            List<Doctor> matched= doctors
                .Where(d=>d.doctorSpecialization==specialization)
                .ToList() ;

            if (matched.Count== 0)
            {
                Console.WriteLine($"No doctor found with specialization+ {matched}" );
                return;
            }
            foreach (Doctor doctor in matched)
            {
                Console.WriteLine("Doctor ID: " + doctor.doctorId +
                                  " Doctor Name: " + doctor.doctorName +
                                  " Doctor Specialization: " + doctor.doctorSpecialization);
            }
            //same (another way)
            matched.ForEach(doctor => Console.WriteLine("Doctor ID: " + doctor.doctorId + " Doctor Name: " + doctor.doctorName));
        }


        //Add an Available Time Slot for a Doctor
        //Doctors (read) + AvailableSlots (write) 
        public static void TimeSlotForDoctor(HospitalContext context)
        {

            Console.WriteLine("Add available slot for doctor");

            if(context.Doctors.Count==0)
            {
                Console.WriteLine("no doctor in the system ,please add doctor first");
                return;
            }

            Console.WriteLine(" Available Doctor ");
            //FOREACH to print all doctor
            context.Doctors.ForEach(d => Console.WriteLine($"ID:{d.doctorId}|Name:{d.doctorName}spe:{d.doctorSpecialization}"));

            Console.WriteLine("Enter Doctor Id");
            int doctorid=int.Parse(Console.ReadLine());

            //will use any because we need only check if doctorId valid, we don't need doctor object himself
            bool result=context.Doctors.Any(d=>d.doctorId == doctorid);
            if (result == false)
            {
                Console.WriteLine("no doctor found with Id ");
                return;
            }


             Console.WriteLine("Enter slot date(2026-07-01)");
            string date=Console.ReadLine();

            Console.WriteLine("Enter slot Time(4:00PM)");
            string time=Console.ReadLine();

            int slotId = context.AvailableSlots.Count + 1;


            //create slot
            context.AvailableSlots.Add(new AvailableSlot
            {
                slotId= slotId,
                doctorId= doctorid,
                slotDate=date,
                slotTime=time,
                isBooked=false

            }
             );
            Console.WriteLine("Slot Add successfuly");
        }



        //Console.WriteLine("Available state");

        //    //add slot
        //    AvailableSlot slot=new AvailableSlot();

        //    slot.isBooked = false;


        //    foreach(AvailableSlot availableSlot in context.AvailableSlots)
        //    {
        //        if (doctorid == doctorid)
        //        {
        //            Console.WriteLine("doctor is available");
        //            return;
        //        }
        //        else
        //        {
        //            Console.WriteLine("doctor not available");
        //        }
        //    }

        //    context.Appointments.Add(new Appointment
        //    {
        //        appointmentId = appointmentId,
        //        doctorId = doctorid,
        //        appointmentDate = appointDate,
        //        appointmentTime = appointTime,

        //    });

        //    slot.isBooked = true;


        //}



        //Book an Appointment
       //        عملية الحجز تمر بـ 7 خطوات:

       //إدخال رقم المريض.
       //التحقق من وجود المريض.
      //اختيار التخصص والطبيب.
     //التحقق من وجود الطبيب.
      //عرض المواعيد المتاحة.
      //اختيار الموعد.
        //إنشاء الحجز وتغيير حالة الموعد إلى محجوز.
        // Patients, Doctors, AvailableSlots, Appointments  →  keeps context
        public static void BookAppointment(HospitalContext context)
        {
            Console.WriteLine("\n=== Book an Appointment ===");

            Console.WriteLine("Enter patient Id :");
            int patientId = int.Parse(Console.ReadLine());

            // LINQ: FirstOrDefault() to find patient by ID
            Patient patient = context.Patients.FirstOrDefault(p => p.patientId == patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient Not Found");
                return;
            }
            //let the user choose from the doctors list in specific specialization
            viewDoctorSpecialization(context.Doctors);

            Console.WriteLine("Enter doctor Id");
            int doctorId = int.Parse(Console.ReadLine());

            // LINQ: FirstOrDefault() to find doctor by ID
            Doctor doctor = context.Doctors.FirstOrDefault(d => d.doctorId == doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor Not Found");
                return;

            }
            // LINQ: Where() to filter unbooked slots for this doctor
            List<AvailableSlot> openSlot = context.AvailableSlots.Where(s => s.doctorId == doctorId && s.isBooked == false)
                .ToList();
            if (openSlot.Count == 0)
            {
                Console.WriteLine("No available slot for this doctor");
                return;
            }

            Console.WriteLine($"Available slot for Doctor .{doctor.doctorName}");
            openSlot.ForEach(s => Console.WriteLine($"slot Id:{s.slotId} | Date:{s.slotDate} |Time :{s.slotTime}"));

            Console.WriteLine("Enter Slot Id to book :");
            int slotId = int.Parse(Console.ReadLine());

            // LINQ: FirstOrDefault() to confirm chosen slot is valid and unbooked
            AvailableSlot selectSlot = openSlot.FirstOrDefault(s => s.slotId == slotId);

            if (selectSlot == null)
            {
                Console.WriteLine("slot Not Found or Alredy booked");
                return;
            }

            int appointmentId = context.Appointments.Count + 1;

            context.Appointments.Add(
                new Appointment
                {
                    appointmentId = appointmentId,
                    patientId = patientId,
                    doctorId = doctorId,
                    appointmentDate = selectSlot.slotDate,
                    appointmentTime = selectSlot.slotTime,
                    status = "Scheduled"
                }
                );

            selectSlot.isBooked = true;
            Console.WriteLine($"Appointment booked Successfully ! AppointmentId:{appointmentId}"+
                $"|Date:{selectSlot.slotDate}|Time:{selectSlot.slotTime}");
        }
        //Appointment appointment = new Appointment();
        //foreach (AvailableSlot slot in context.AvailableSlots)
        //{
        //    if (slot.doctorId == doctorId && slot.isBooked == false)
        //    {
        //        Console.WriteLine("Available time for doctor" + slot);


        //    }
        //    else
        //    {
        //        slot.isBooked = false;
        //        appointment.status = "Booked";
        //        Console.WriteLine("The Doctor Not Available");

        //    }
        //}





        //Cancel an Appointment
          //        يطلب النظام رقم الموعد.
         //يبحث عن الموعد.
        //يتأكد أن الموعد موجود.
        //يتأكد أن الموعد غير ملغي.
        //يتأكد أن الموعد غير مكتمل.
       //يعيد فتح الوقت للطبيب.
          //يغير حالة الموعد إلى Cancelled.
        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("\n=== Cancel an Appointment ===");

            Console.WriteLine("Enter Appintment id");
            int appointmentId = int.Parse(Console.ReadLine());

            //foreach (Appointment appointment in context.Appointments)
            //{
            //    if(appointment.status=="Canceled")
            //    {
            //        Console.WriteLine("Appointment is Cancelled");
            //    }
            //    else
            //    {

            //        appointment.status = "Cancelled";

            //    }
            //    AvailableSlot slot = new AvailableSlot();
            //    slot.isBooked = false;

            //}

            //find appointment 
            Appointment appointment = context.Appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId );
            Console.WriteLine("Appointment is Allredy cancelled");
            if(appointment==null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }
            if(appointment.status =="Cancelled")
            {
                Console.WriteLine("This appointment is already cancelled.");
                return;
            }
            if (appointment.status == "Completed")
            {
                Console.WriteLine("cannot cancelled compleate appointment");
                return;
            }
            // free the slot 
            AvailableSlot slot = context.AvailableSlots
                .FirstOrDefault(s => s.doctorId == appointment.doctorId &&
                s.doctorId==appointment.doctorId&&
                s.slotDate==appointment.appointmentDate&&
                s.slotTime==appointment.appointmentTime);

            if (slot != null)
                slot.isBooked = false;

            appointment.status = "Cancelled";
            Console.WriteLine($"Appointment {appointmentId} has been cancelled and the time slot is now available again.");
        }

        //Create a Medical Record After a Visit
        //   إدخال رقم الموعد.
        //البحث عن الموعد.
          //التأكد أن الموعد موجود.
        //التأكد أن الموعد ليس ملغيًا.
       //التأكد أن الموعد لم يُكمل سابقًا.
       //جلب رسوم الطبيب.
        //إدخال التشخيص والعلاج.
        //إنشاء سجل طبي جديد.
        //تغيير حالة الموعد إلى Completed.
         public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.WriteLine("Enter Appointment Id");
            int appointmentId=int.Parse(Console.ReadLine());

            //find appointment
            Appointment appointment = context.Appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found");
                return;
            }
            if (appointment.status=="Cancelled")
            {
                Console.WriteLine("cannet create medical record");
                return;
            }
            if (appointment.status=="Completed")
            {
                Console.WriteLine("medical record alredy exist");
                return;
            }

            // LINQ: FirstOrDefault() + Select() to get the doctor's consultation fee
            decimal fee = context.Doctors.Where(d => d.doctorId == appointment.doctorId)
                                       .Select(d => d.consultationFee)
                                       .FirstOrDefault();

            Console.WriteLine("Enter Diagnosis");
            string diagnosis = Console.ReadLine();

            Console.WriteLine("Enter prescription");
            string prescription=Console.ReadLine();

            Console.Write("Enter visit date (e.g. 2026-07-10): ");
            string visitDate = Console.ReadLine();

            int recordId = context.MedicalRecords.Count + 1;

            //Add medical record
            context.MedicalRecords.Add(
                 new MedicalRecord
                 {
                     recordId = recordId,
                     patientId=appointment.patientId,
                     doctorId=appointment.doctorId,
                     appointmentId = appointmentId,
                     diagnosis = diagnosis,
                     prescription = prescription,
                     visitDate=visitDate,
                     visitFee = fee,
                 }

                 );
            //update appointment status
            appointment.status = "Completed";
            Console.WriteLine($"Medical record created successfuly .RecordId:{recordId} fee:{fee}");
        }



        //Generate a Patient Medical History Report
       //  تطلب رقم المريض.
       //تبحث عن المريض.
       //تتأكد أن المريض موجود.
        //تبحث عن جميع السجلات الطبية الخاصة به.
       //تعرض بيانات كل زيارة.
         //تعرض اسم الطبيب لكل زيارة.
       //تحسب إجمالي المبالغ المدفوعة.
        public static void PatientMedicalHistory(HospitalContext context)
        {
            Console.WriteLine("Enter Patient Id");
            int patientId=int.Parse(Console.ReadLine());
      
            //find patient
           Patient patient=context.Patients.FirstOrDefault(p=>p.patientId==patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            // LINQ: Where() to get all records for this patient
            List<MedicalRecord>records=context.MedicalRecords
                .Where(r=>r.patientId==patientId)
                .ToList();

            if(records.Count==0)
            {
                Console.WriteLine("No medical records found for this patient.");
                return;

            }
            Console.WriteLine($"Medical History for {patient.patientName} Id:{patientId}");

            records.ForEach(r =>
            {  // LINQ: FirstOrDefault() + Select() to resolve doctor name
                string doctorName=context.Doctors
                .Where(d=>d.doctorId==r.recordId)
                .Select(d=>d.doctorName)
                .FirstOrDefault() ??"Unknown";

                Console.WriteLine($"\n  Record ID   : {r.recordId}");
                Console.WriteLine($"  Visit Date  : {r.visitDate}");
                Console.WriteLine($"  Doctor      : {doctorName}");
                Console.WriteLine($"  Diagnosis   : {r.diagnosis}");
                Console.WriteLine($"  Prescription: {r.prescription}");
                Console.WriteLine($"  Fee Charged : {r.visitFee}");

            });
            //sum total fee
            decimal totalCharged = records.Sum(r => r.visitFee);
            Console.WriteLine($"\n  TOTAL AMOUNT CHARGED: {totalCharged}");
        }

        //Doctor Workload and Revenue Summary
        // Doctors, Appointments, MedicalRecords  
     //  Checks whether any appointments exist:
          //If there are none, it displays a message and exits.
      //Uses LINQ to create a summary for each doctor:
       //Doctor ID
        //Doctor name
        //Specialization
        //Number of completed appointments
       //Number of cancelled appointments
       //Total revenue earned from medical records
        //Sorts doctors by revenue in descending order.
         //Displays the results in a formatted table with rankings.
        public static void WorkloadAndRevenue(HospitalContext context)
        {
            Console.WriteLine("\n=== Doctor Workload & Revenue Summary ===");
            if(context.Appointments.Count==0)
            {
                Console.WriteLine("No appointments have been recorded yet.");
                return;
            }
            // LINQ: Select() to project each doctor into a summary anonymous object,
            //       then OrderByDescending() to rank by total revenue
            var summary = context.Doctors.Select(d => new
            {
                d.doctorId,
                d.doctorName,
                d.doctorSpecialization,

                //count complete appointment
                completed = context.Appointments.Count(a => a.doctorId == d.doctorId && a.status == "Completed"),
                cancelled = context.Appointments.Count(a => a.doctorId == d.doctorId && a.status == "Cancelled"),

                //total revenu
                totalRevenue = context.MedicalRecords
                .Where(r => r.doctorId == d.doctorId)
                .Sum(r => r.visitFee)
            }

            )
                .OrderByDescending(x => x.totalRevenue)
                .ToList();


            Console.WriteLine("  Rank  | Doctor Name | Specialization  | Completed | Cancelled | Total Revenue");
        

            for (int i = 0; i < summary.Count; i++)
            {
                var x = summary[i];
                Console.WriteLine($"  #{i + 1,-5} | {x.doctorName,-25} | {x.doctorSpecialization,-20} |" +
                                  $" {x.completed,-9} | {x.cancelled,-9} | {x.totalRevenue:C}");
            }
        }
        static void Main(string[] args)
        {
            HospitalContext mainContext = new HospitalContext();
            mainContext.Patients = new List<Patient>()//seed Data
            {
                new Patient(1,"Ali",22,"Male","987665","ali@gmail","a"),
                new Patient(1,"sara",27,"Female","24267","sara@gmail","b"),
            };
            mainContext.Doctors = new List<Doctor>()
            {
                new Doctor(43,"salim","sergery","8896","Salim@gmail",22),
                new Doctor(55,"fatma","sergery","8855","fatma@gmail",82)
            };

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
                        RegisterPationt(mainContext.Patients);
                        break;
                    case 2:
                        AddDoctor(mainContext.Doctors);
                        break;
                    case 3:
                        ViewPatient(mainContext.Patients);
                        break;
                    case 4:
                        viewDoctorSpecialization(mainContext.Doctors);
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
            //static void Print(List<HospitalContext>Print)
            //{
            //    foreach(var h in Print)
            //    {
            //        h.convertDataToString();
            //    }
            //}
        }
    }
}


