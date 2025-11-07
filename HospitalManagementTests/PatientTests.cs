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
    public class PatientTests
    {
        [Test]
        public void Patient_Constructor_ShouldSetAllProperties()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);

            Assert.That(patient.Id, Is.EqualTo(1));
            Assert.That(patient.Name, Is.EqualTo("Коваленко Тарас"));
            Assert.That(patient.Age, Is.EqualTo(35));
        }

        [Test]
        public void Patient_Properties_CanBeModified()
        {
            var patient = new Patient(1, "Коваленко Тарас", 35);

            patient.Id = 2;
            patient.Name = "Шевченко Ольга";
            patient.Age = 28;

            Assert.That(patient.Id, Is.EqualTo(2));
            Assert.That(patient.Name, Is.EqualTo("Шевченко Ольга"));
            Assert.That(patient.Age, Is.EqualTo(28));
        }

        [Test]
        public void Patient_CanCreateMultiplePatients()
        {
            var patient1 = new Patient(1, "Коваленко Тарас", 35);
            var patient2 = new Patient(2, "Шевченко Ольга", 28);

            Assert.That(patient1.Id, Is.Not.EqualTo(patient2.Id));
            Assert.That(patient1.Name, Is.Not.EqualTo(patient2.Name));
        }

        [Test]
        public void Patient_Age_CanBeZero()
        {
            var patient = new Patient(1, "Немовля", 0);

            Assert.That(patient.Age, Is.EqualTo(0));
        }
    }
}
