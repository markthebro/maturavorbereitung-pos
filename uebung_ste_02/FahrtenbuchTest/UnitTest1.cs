using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FahrtenbuchTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new FahrtenbuchDB.FahrtenbuchDBEntities();
            var countEmployees = db.Employees.Count();

            Assert.AreEqual(0, countEmployees);
        }
    }
}
