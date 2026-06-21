using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Module
{
    public  class Doctor
    {
        public int doctorId {  get; set; }
        public string doctorName { get; set; }
        public string doctorSpecialization { get; set; }
        public string doctorPhone { get; set; }
        public string doctorEmail { get; set; }
        public decimal consultationFee { get; set; }

        public Doctor (int Id, string Name, string Specialization, string Phone, string Email, decimal Fee)
        {
           doctorId = Id;
           doctorName = Name;
           doctorSpecialization = Specialization;
           doctorPhone = Phone;
           doctorEmail = Email;
           consultationFee =Fee;
        }
        public override string ToString() =>
            $"{doctorId} | {doctorName} | {doctorSpecialization} | {doctorPhone} |{doctorPhone}|{doctorEmail}|{consultationFee}";
     
    }
}
