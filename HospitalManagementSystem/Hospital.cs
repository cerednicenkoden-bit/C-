using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи.");
        }

        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований у системі.");
        }

        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} з місткістю {room.Capacity} створена.");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == patientId);
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (patient != null && room != null)
            {
                room.AddPatient(patient);
            }
            else
            {
                Console.WriteLine("Пацієнт або палата не знайдені.");
            }
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId).ToList();
        }

        public string GetStatistics()
        {
            return $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                   $"Кількість лікарів: {Doctors.Count}\n" +
                   $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                   $"Кількість палат: {Rooms.Count}\n" +
                   $"Кількість пацієнтів у палатах: {Rooms.Sum(r => r.Patients.Count)}\n" +
                   $"Кількість медичних записів: {Records.Count}\n";
        }
    }
}
