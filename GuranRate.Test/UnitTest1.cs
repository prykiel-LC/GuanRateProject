using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuranRateHost;
using System.Collections;
using System.Collections.Generic;

namespace GuranRate.Test
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void GetDataintheDataBase()
        {
            PersonsController per = new PersonsController();
            var p = per.Get() as List<Person>;
            Assert.AreEqual(p.Count, 30);
         
        }

        [TestMethod]
        public void GetDataBySortValueName()
        {
            string id = "Name";
            PersonsController per = new PersonsController();
            var p = per.Get(id) as List<Person>;
            Assert.AreEqual(id, "Name");
            
        }

        [TestMethod]
        public void GetDataBySortValueGender()
        {
            string id = "Gender";
            PersonsController per = new PersonsController();
            var p = per.Get(id) as List<Person>;
            Assert.AreEqual(id, "Gender");

        }

        [TestMethod]
        public void GetDataBySortValueBirthDate()
        {
            string id = "BirthDate";
            PersonsController per = new PersonsController();
            var p = per.Get(id) as List<Person>;
            Assert.AreEqual(id, "BirthDate");

        }

        [TestMethod]
        public void PostaNewRecord()
        {
            Person p = new Person();
            p.LastName = "Smith";
            p.FirstName = "Bob";
            p.Gender = "M";
            p.FavoriteColor = "Blue";
            p.DateOfBirth = "03-01-1970";
            p.DateOfBirthIndex = new System.DateTime(03011970);
            PersonsController per = new PersonsController();
            var list = per.Get() as List<Person>;
            per.Post(p);
            Assert.IsNotNull(p);
            Assert.AreEqual(list.Count, 31);

        }
    }
}
