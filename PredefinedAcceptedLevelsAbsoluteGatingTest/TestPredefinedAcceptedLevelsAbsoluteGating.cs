using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PredefinedAcceptedLevelsAbsoluteGating;

namespace PredefinedAcceptedLevelsAbsoluteGatingTest
{
    [TestClass]
    public class TestPredefinedAcceptedLevelsAbsoluteGating
    {
        [TestMethod]
        public void When_Input_Given_Belongs_To_Dictionary_Should_Return_True()
        {
            ValidityOfUserInput obj = new ValidityOfUserInput();
            
            string p1 = "Level1";
            var actual = obj.CheckValidityOfUserInput(p1);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_Input_Given_Belongs_To_Dictionary_Should_Return_True_But_Asserted_Against_False()
        {
            ValidityOfUserInput obj = new ValidityOfUserInput();
            
            string p1 = "Level21";
            var actual = obj.CheckValidityOfUserInput(p1);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }
    }


}
