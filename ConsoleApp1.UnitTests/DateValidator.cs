using DateValidatorProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateValidatorTests
{
    [TestClass]
    public class DateValidatorTests
    {
        private DateValidator? _dateValidator;

        [TestMethod]
        [DataRow("10-12")] // Pas assez de tirets
        [DataRow("10-12-2020-01")] // Trop de tirets
        public void TestNumberOfDashes(string date)
        {
            Assert.ThrowsException<Exception>(() => _dateValidator = new DateValidator(date));
        }

        [TestMethod]
        [DataRow("10-12-2020", true)] // Cas valide
        [DataRow("xx-12-2020", false)] // Jour non numérique
        [DataRow("10-xx-2020", false)] // Mois non numérique
        [DataRow("10-12-xx", false)] // Année non numérique
        public void TestAllNumbersAreIntegers(string date, bool expected)
        {
            var validator = new DateValidator(date);
            Assert.AreEqual(expected, validator.CheckAllNumbersAreIntegers());
        }

        // CheckDayNumber
        [TestMethod]
        [DataRow("10-12-2020", true)] // Cas valide
        [DataRow("00-12-2020", false)] // Jour invalide
        [DataRow("32-12-2020", false)] // Jour invalide (supérieur à 31)
        public void TestDayNumber(string date, bool expected)
        {
            var validator = new DateValidator(date);
            Assert.AreEqual(expected, validator.CheckDayNumber());
        }

        // CheckMonthNumber
        [TestMethod]
        [DataRow("10-12-2020", true)] // Cas valide
        [DataRow("10-00-2020", false)] // Mois invalide
        [DataRow("10-13-2020", false)] // Mois invalide (supérieur à 12)
        public void TestMonthNumber(string date, bool expected)
        {
            var validator = new DateValidator(date);
            Assert.AreEqual(expected, validator.CheckMonthNumber());
        } 

        // CheckYearNumber
        [TestMethod]
        [DataRow("10-12-2020", true)] // Cas valide
        [DataRow("10-12-1999", false)] // Année invalide
        [DataRow("10-12-2024", false)] // Année invalide (supérieur à l'année courante)
        public void TestYearNumber(string date, bool expected)
        {
            var validator = new DateValidator(date);
            Assert.AreEqual(expected, validator.CheckYearNumber());
        }

        // Test des exceptions
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestExceptionForNonIntegerValues()
        {
            var validator = new DateValidator("xx-12-2020");
            validator.ThrowExceptionIfNumbersAreNotIntegers();
        }
    }
}