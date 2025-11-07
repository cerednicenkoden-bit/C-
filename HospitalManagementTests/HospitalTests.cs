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
    public class HospitalTests
    {
        private Hospital hospital;

        [SetUp]
        public void SetUp()
        {
            hospital = new Hospital();
        }

        [Test]
        public void Hospital_Constructor_ShouldInitializeEmptyLists()
        {
            Assert.That(hospital.Doctors, Is.Not.Null);
            Assert.That(hospital.Patients, Is.Not.Null);
            Assert.That(hospital.Rooms, Is.Not.Null);
            Assert.That(hospital.Records, Is.Not.Null);
            Assert.That(hospital.Doctors.Count, Is.EqualTo(0));
            Assert.That(hospital.Patients.Count, Is.EqualTo(0));
            Assert.That(hospital.Rooms.Count, Is.EqualTo(0));
            Assert.That(hospital.Records.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddDoctor_ShouldAddDoctorToList()
        {
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");

            hospital.AddDoctor(doctor);

            Assert.That(hospital.Doctors.Count, Is.EqualTo(1));
            Assert.That(hospital.Doctors, Does.Contain(doctor));
        }

        [Test]
        public void AddDoctor_CanAddMultipleDoctors()
        {
            var doctor1 = new Doctor(1, "Іванов Іван", "Терапевт");
            var doctor2 = new Doctor(2, "Петрова Марія", "Хірург");

            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);

            Assert.That(hospital.Doctors.Count, Is.EqualTo(2));
            Assert.That(hospital.Doctors, Does.Contain(doctor1));
            Assert.That(hospital.Doctors, Does.Contain(doctor2));
        }

        [Test]
        public void RegisterPatient_ShouldAddPatientToList()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);

            hospital.RegisterPatient(patient);

            Assert.That(hospital.Patients.Count, Is.EqualTo(1));
            Assert.That(hospital.Patients, Does.Contain(patient));
        }

        [Test]
        public void RegisterPatient_CanAddMultiplePatients()
        {
            var patient1 = new Patient(1, "Коваленко Тарас", 35);
            var patient2 = new Patient(2, "Шевченко Ольга", 28);

            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);

            Assert.That(hospital.Patients.Count, Is.EqualTo(2));
            Assert.That(hospital.Patients, Does.Contain(patient1));
            Assert.That(hospital.Patients, Does.Contain(patient2));
        }

        [Test]
        public void CreateRoom_ShouldAddRoomToList()
        {
            var room = new HospitalRoom(101, 2);

            hospital.CreateRoom(room);

            Assert.That(hospital.Rooms.Count, Is.EqualTo(1));
            Assert.That(hospital.Rooms, Does.Contain(room));
        }

        [Test]
        public void CreateRoom_CanAddMultipleRooms()
        {
            var room1 = new HospitalRoom(101, 2);
            var room2 = new HospitalRoom(102, 3);

            hospital.CreateRoom(room1);
            hospital.CreateRoom(room2);

            Assert.That(hospital.Rooms.Count, Is.EqualTo(2));
            Assert.That(hospital.Rooms, Does.Contain(room1));
            Assert.That(hospital.Rooms, Does.Contain(room2));
        }

        [Test]
        public void HospitalizePatient_WithValidIds_ShouldAddPatientToRoom()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var room = new HospitalRoom(101, 2);
            hospital.RegisterPatient(patient);
            hospital.CreateRoom(room);

            hospital.HospitalizePatient(1, 101);

            Assert.That(room.Patients.Count, Is.EqualTo(1));
            Assert.That(room.Patients, Does.Contain(patient));
        }

        [Test]
        public void HospitalizePatient_WithInvalidPatientId_ShouldNotAddToRoom()
        {
            var room = new HospitalRoom(101, 2);
            hospital.CreateRoom(room);

            hospital.HospitalizePatient(999, 101);

            Assert.That(room.Patients.Count, Is.EqualTo(0));
        }

        [Test]
        public void HospitalizePatient_WithInvalidRoomNumber_ShouldNotAddPatient()
        {
          
            var patient = new Patient(1, "Коваленко Тарас", 35);
            hospital.RegisterPatient(patient);

            hospital.HospitalizePatient(1, 999);

            Assert.That(hospital.Rooms.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddMedicalRecord_ShouldAddRecordToList()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var record = new MedicalRecord(patient, doctor, DateTime.Now, "Діагноз");

            hospital.AddMedicalRecord(record);

            Assert.That(hospital.Records.Count, Is.EqualTo(1));
            Assert.That(hospital.Records, Does.Contain(record));
        }

        [Test]
        public void AddMedicalRecord_CanAddMultipleRecords()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var record1 = new MedicalRecord(patient, doctor, DateTime.Now, "Діагноз 1");
            var record2 = new MedicalRecord(patient, doctor, DateTime.Now.AddDays(1), "Діагноз 2");

            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);

            Assert.That(hospital.Records.Count, Is.EqualTo(2));
            Assert.That(hospital.Records, Does.Contain(record1));
            Assert.That(hospital.Records, Does.Contain(record2));
        }

        [Test]
        public void GetPatientHistory_WithExistingRecords_ShouldReturnRecords()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var record1 = new MedicalRecord(patient, doctor, DateTime.Now, "Діагноз 1");
            var record2 = new MedicalRecord(patient, doctor, DateTime.Now.AddDays(1), "Діагноз 2");
            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);

            var history = hospital.GetPatientHistory(1);

            Assert.That(history.Count, Is.EqualTo(2));
            Assert.That(history, Does.Contain(record1));
            Assert.That(history, Does.Contain(record2));
        }

        [Test]
        public void GetPatientHistory_WithNoRecords_ShouldReturnEmptyList()
        {
            var history = hospital.GetPatientHistory(1);

            Assert.That(history, Is.Not.Null);
            Assert.That(history.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetPatientHistory_ShouldReturnOnlySpecificPatientRecords()
        {
            var patient1 = new Patient(1, "Пацієнт 1", 35);
            var patient2 = new Patient(2, "Пацієнт 2", 28);
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var record1 = new MedicalRecord(patient1, doctor, DateTime.Now, "Діагноз для пацієнта 1");
            var record2 = new MedicalRecord(patient2, doctor, DateTime.Now, "Діагноз для пацієнта 2");
            var record3 = new MedicalRecord(patient1, doctor, DateTime.Now.AddDays(1), "Ще один для пацієнта 1");

            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);
            hospital.AddMedicalRecord(record3);

            var history = hospital.GetPatientHistory(1);

            Assert.That(history.Count, Is.EqualTo(2));
            Assert.That(history.All(r => r.Patient.Id == 1), Is.True);
        }

        [Test]
        public void GetStatistics_ShouldReturnCorrectCounts()
        {
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");
            var patient1 = new Patient(1, "Пацієнт 1", 35);
            var patient2 = new Patient(2, "Пацієнт 2", 28);
            var room = new HospitalRoom(101, 2);
            var record = new MedicalRecord(patient1, doctor, DateTime.Now, "Діагноз");

            hospital.AddDoctor(doctor);
            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);
            hospital.CreateRoom(room);
            hospital.HospitalizePatient(1, 101);
            hospital.AddMedicalRecord(record);

            string stats = hospital.GetStatistics();

            Assert.That(stats, Does.Contain("1"));
            Assert.That(stats, Does.Contain("2"));
            Assert.That(stats, Does.Contain("1"));
            Assert.That(stats, Does.Contain("1"));
        }

        [Test]
        public void GetStatistics_WithEmptyHospital_ShouldReturnZeros()
        {
            string stats = hospital.GetStatistics();

            Assert.That(stats, Does.Contain("0"));
            Assert.That(stats, Does.Contain("СТАТИСТИКА"));
        }

        [Test]
        public void GetStatistics_ShouldCountPatientsInRoomsCorrectly()
        {
            var patient1 = new Patient(1, "Пацієнт 1", 35);
            var patient2 = new Patient(2, "Пацієнт 2", 28);
            var patient3 = new Patient(3, "Пацієнт 3", 42);
            var room1 = new HospitalRoom(101, 2);
            var room2 = new HospitalRoom(102, 2);

            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);
            hospital.RegisterPatient(patient3);
            hospital.CreateRoom(room1);
            hospital.CreateRoom(room2);
            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);

            string stats = hospital.GetStatistics();

            Assert.That(stats, Does.Contain("3"));
            Assert.That(stats, Does.Contain("2"));
            Assert.That(stats, Does.Contain("Кількість пацієнтів у палатах: 3"));
        }
    }
}
