using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            // Створення об'єкта лікарні
            // Додавання лікарів (мінімум 2-3)
            // Реєстрація пацієнтів (мінімум 3-4)
            // Створення палат (мінімум 2-3)
            // Госпіталізація пацієнтів у палати
            // Додавання медичних записів (мінімум 2-3)
            // Перегляд історії конкретного пацієнта
            // Виклик та вивід статистики лікарні

            hospital.AddDoctor(new Doctor(1, "Іванов Іван", "Терапевт"));
            hospital.AddDoctor(new Doctor(2, "Петров Петро", "Хірург"));

            hospital.RegisterPatient(new Patient(1, "Сидоренко Ольга", 30));
            hospital.RegisterPatient(new Patient(2, "Коваленко Андрій", 45));
            hospital.RegisterPatient(new Patient(3, "Мельник Катерина", 25));

            hospital.CreateRoom(new HospitalRoom(101, 2));
            hospital.CreateRoom(new HospitalRoom(102, 1));

            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);

            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], hospital.Doctors[0], DateTime.Now, "Звичайний огляд"));
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], hospital.Doctors[1], DateTime.Now, "Операція на апендикс"));

            Console.WriteLine("\n=== ІСТОРІЯ ПАЦІЄНТА ===");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date:d}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            Console.WriteLine(hospital.GetStatistics());
        }

    }
}
