using HospitalManagementSystem;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTests
{
    [TestFixture]
    public class MedicalRecordTests
    {
        [Test]
        public void MedicalRecord_Constructor_ShouldSetAllProperties()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var date = new DateTime(2025, 9, 30);
            var description = "Грип, призначено медикаменти";

            var record = new MedicalRecord(patient, doctor, date, description);

            Assert.That(record.Patient, Is.EqualTo(patient));
            Assert.That(record.Doctor, Is.EqualTo(doctor));
            Assert.That(record.Date, Is.EqualTo(date));
            Assert.That(record.Description, Is.EqualTo(description));
        }

        [Test]
        public void MedicalRecord_Properties_CanBeModified()
        {
            var patient1 = new Patient(1, "Коваленко Тарас", 35);
            var doctor1 = new Doctor(1, "Іванов Іван", "Терапевт");
            var record = new MedicalRecord(patient1, doctor1, DateTime.Now, "Опис 1");

            var patient2 = new Patient(2, "Шевченко Ольга", 28);
            var doctor2 = new Doctor(2, "Петрова Марія", "Хірург");
            var newDate = DateTime.Now.AddDays(1);

            record.Patient = patient2;
            record.Doctor = doctor2;
            record.Date = newDate;
            record.Description = "Новий опис";

            Assert.That(record.Patient, Is.EqualTo(patient2));
            Assert.That(record.Doctor, Is.EqualTo(doctor2));
            Assert.That(record.Date, Is.EqualTo(newDate));
            Assert.That(record.Description, Is.EqualTo("Новий опис"));
        }

        [Test]
        public void MedicalRecord_CanCreateMultipleRecords()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var doctor1 = new Doctor(1, "Іванов Іван", "Терапевт");
            var doctor2 = new Doctor(2, "Петрова Марія", "Хірург");

            var record1 = new MedicalRecord(patient, doctor1, DateTime.Now, "Візит 1");
            var record2 = new MedicalRecord(patient, doctor2, DateTime.Now.AddDays(1), "Візит 2");

            Assert.That(record1.Doctor, Is.Not.EqualTo(record2.Doctor));
            Assert.That(record1.Description, Is.Not.EqualTo(record2.Description));
        }
    }
}
