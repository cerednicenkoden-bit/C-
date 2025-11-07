using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using HospitalManagementSystem;

using System.Threading.Tasks;

namespace HospitalManagementTests
{
    [TestFixture]
    public class DoctorTests
    {
        [Test]
        public void Doctor_Constructor_ShouldSetAllProperties()
        {
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");

            Assert.That(doctor.Id, Is.EqualTo(1));
            Assert.That(doctor.Name, Is.EqualTo("Іванов Іван"));
            Assert.That(doctor.Specialization, Is.EqualTo("Терапевт"));
        }

        [Test]
        public void Doctor_Properties_CanBeModified()
        {
            var doctor = new Doctor(1, "Іванов Іван", "Терапевт");

            doctor.Id = 2;
            doctor.Name = "Петров Петро";
            doctor.Specialization = "Хірург";

            Assert.That(doctor.Id, Is.EqualTo(2));
            Assert.That(doctor.Name, Is.EqualTo("Петров Петро"));
            Assert.That(doctor.Specialization, Is.EqualTo("Хірург"));
        }

        [Test]
        public void Doctor_CanCreateMultipleDoctors()
        {
            var doctor1 = new Doctor(1, "Іванов Іван", "Терапевт");
            var doctor2 = new Doctor(2, "Петрова Марія", "Хірург");

            Assert.That(doctor1.Id, Is.Not.EqualTo(doctor2.Id));
            Assert.That(doctor1.Specialization, Is.Not.EqualTo(doctor2.Specialization));
        }
    }
}
