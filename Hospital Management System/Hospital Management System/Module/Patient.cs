using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Module
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }

        public Patient(int Id, string Name, int Age, string Gender, string Phone, string Email, string BloodType)
        {
            patientId = Id;
            patientName = Name;
            patientAge = Age;
            patientGender = Gender;
            patientPhone = Phone;
            patientEmail = Email;
            patientBloodType = BloodType;
        }
        //public override string ToString() =>
        //    $"[{patientId}] {patientName,-10} | {patientAge,-8}|{patientGender,-7}|{patientPhone,-6}|{patientEmail}|{patientBloodType}";

        public void printInfo()
        {
            Console.WriteLine($"ID:{patientId} | Name:{patientName} |Age{patientAge}"+
              $"Gender:{ patientGender}|phone:{ patientPhone}|Email:{ patientEmail}|blood:{ patientBloodType}" );
        }


    }
}

