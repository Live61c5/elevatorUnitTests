using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UnitTests

{
    [TestClass]
    public class ElevatorTests
    {
        private Elevator _elevator;

        [TestInitialize]
        public void Initialize()
        {
            _elevator = new Elevator(100);
        }

        [TestMethod]
        public void TestInUser()
        {
            var user = new Employee { Weight = 50 };
            _elevator.InUser(user);
            Assert.AreEqual(50, _elevator.CurrentWeight);
        }

        [TestMethod]
        public void TestOutUser()
        {
            var user = new Employee { Weight = 50 };
            _elevator.InUser(user);
            _elevator.OutUser(user);
            Assert.AreEqual(0, _elevator.CurrentWeight);
        }

        [TestMethod]
        public void TestCheckMaxWeightAllowedReached()
        {
            var user = new Employee { Weight = 110 };
            _elevator.InUser(user);
            Assert.IsTrue(_elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        public void TestGoToVipSection()
        {
            var user = new Employee { Weight = 50, IsExecutive = true };
            _elevator.InUser(user);
            Assert.IsTrue(_elevator.GoToVipSection(user));
        }
    }   
}

