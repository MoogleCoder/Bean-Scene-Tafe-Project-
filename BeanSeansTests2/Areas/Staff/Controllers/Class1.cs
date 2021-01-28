using BeanSeans.Data;
using BeanSeans.Models.Reservation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CreateReservationTest
{
    [TestClass()]
    public class UnitTest
    {
        [TestMethod()]
        public void PersonTestValid()
        {
            //set up the data
            Person person = new Person
            {
                FirstName = "Me",
                LastName = "MyLast",
                Email = "vcb@.com",
                Phone = "0000000000",
                RestuarantId = 1
            };
            CreateReservation create = new CreateReservation();
            create.Person = person;
            Assert.IsNotNull(create.Person);
            Assert.AreEqual(person, create.Person);
            Assert.AreEqual("vcb@.com", create.Person.Email);
            Assert.AreEqual("Me", create.Person.FirstName);
            Assert.AreEqual("MyLast", create.Person.LastName);
            Assert.AreEqual("1", create.Person.RestuarantId.ToString());
        }
        [TestMethod()]
        public void SittingTest()
        {
            Sitting sitting = new Sitting
            {
                RestuarantId = 1,
                SittingTypeId = 1,
                Start = new DateTime(2020, 12, 20, 8, 30, 00),
                End = new DateTime(2020, 12, 20, 12, 30, 00),
                Capacity = 100,
            };
            CreateReservation create = new CreateReservation();
            create.Sitting = sitting;
            Assert.IsNotNull(create.Sitting);
            Assert.AreEqual(1, create.Sitting.RestuarantId);
            Assert.AreEqual(1, create.Sitting.SittingTypeId);
            Assert.AreEqual(new DateTime(2020, 12, 20, 8, 30, 00), create.Sitting.Start);
            Assert.AreEqual(new DateTime(2020, 12, 20, 12, 30, 00), create.Sitting.End);
        }
        [TestMethod()]
        public void CreateGuestTest()
        {
            CreateReservation create = new CreateReservation();
            create.Guest = 12;
            Assert.IsTrue(create.Guest == 12);
        }
        [TestMethod()]
        public void CreateDurationTest()
        {
            CreateReservation create = new CreateReservation();
            create.Guest = 12;
            Assert.IsTrue(create.Guest == 12);
        }
        [TestMethod()]
        public void CreateNoteTest()
        {
            CreateReservation create = new CreateReservation();
            create.Note = "Extra Plates needed";
            Assert.IsTrue(create.Note == "Extra Plates needed");
        }
    }
}
