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
    public class HospitalRoomTests
    {
        [Test]
        public void HospitalRoom_Constructor_ShouldInitializeProperties()
        {
            var room = new HospitalRoom(101, 2);

            Assert.That(room.RoomNumber, Is.EqualTo(101));
            Assert.That(room.Capacity, Is.EqualTo(2));
            Assert.That(room.Patients, Is.Not.Null);
            Assert.That(room.Patients.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPatient_WhenRoomHasSpace_ShouldAddPatient()
        {
            var room = new HospitalRoom(101, 2);
            var patient = new Patient(1, "Коваленко Тарас", 35);

            room.AddPatient(patient);

            Assert.That(room.Patients.Count, Is.EqualTo(1));
            Assert.That(room.Patients, Does.Contain(patient));
        }

        [Test]
        public void AddPatient_WhenRoomIsFull_ShouldNotAddPatient()
        {
            // Arrange
            var room = new HospitalRoom(101, 1);
            var patient1 = new Patient(1, "Пацієнт 1", 30);
            var patient2 = new Patient(2, "Пацієнт 2", 40);

            room.AddPatient(patient1);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                room.AddPatient(patient2);
                string output = sw.ToString();

                Assert.That(room.Patients.Count, Is.EqualTo(1));
                Assert.That(room.Patients, Does.Contain(patient1));
                Assert.That(room.Patients, Does.Not.Contain(patient2));
                Assert.That(output, Does.Contain("переповнена"));
            }

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        [Test]
        public void AddPatient_CanAddMultiplePatients_UpToCapacity()
        {
            var room = new HospitalRoom(102, 3);
            var patient1 = new Patient(1, "Пацієнт 1", 30);
            var patient2 = new Patient(2, "Пацієнт 2", 40);
            var patient3 = new Patient(3, "Пацієнт 3", 50);

            room.AddPatient(patient1);
            room.AddPatient(patient2);
            room.AddPatient(patient3);

            Assert.That(room.Patients.Count, Is.EqualTo(3));
            Assert.That(room.Patients, Does.Contain(patient1));
            Assert.That(room.Patients, Does.Contain(patient2));
            Assert.That(room.Patients, Does.Contain(patient3));
        }

        [Test]
        public void HospitalRoom_WithZeroCapacity_ShouldNotAcceptPatients()
        {
            var room = new HospitalRoom(103, 0);
            var patient = new Patient(1, "Пацієнт", 30);

            room.AddPatient(patient);

            Assert.That(room.Patients.Count, Is.EqualTo(0));
        }
    }
}
