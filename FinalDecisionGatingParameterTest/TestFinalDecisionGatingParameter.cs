using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalDecisionGatingParameter;


namespace FinalDecisionGatingParameterTest
{
    [TestClass]
    public class TestFinalDecisionGatingParameter
    {
        [TestMethod]
        public void When_Input_totalNumberOfIssues_Is_Greater_Than_AcceptedNumberOfissues_Should_Return_False()
        {
            FinalDecisionGatingParameter.FinalDecisionGatingParameter obj = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();
            int totalNumberOfIssues = 9;
            int acceptedNumberOfIssues = 8;

            var actual = obj.MakeFinalDecisionAbsoluteParameter(totalNumberOfIssues,acceptedNumberOfIssues);
            var expected = false;

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void When_Input_totalNumberOfIssues_Is_Lesser_Than_AcceptedNumberOfissues_Should_Return_True()
        {
            FinalDecisionGatingParameter.FinalDecisionGatingParameter obj = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();
            int totalNumberOfIssues = 6;
            int acceptedNumberOfIssues = 8;

            var actual = obj.MakeFinalDecisionAbsoluteParameter(totalNumberOfIssues, acceptedNumberOfIssues);
            var expected = true;

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void When_Input_totalNumberOfIssues_Is_Greater_Than_AcceptedNumberOfissues_Should_Return_False_But_Asserted_With_True()
        {
            FinalDecisionGatingParameter.FinalDecisionGatingParameter obj = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();
            int totalNumberOfIssues = 9;
            int acceptedNumberOfIssues = 8;

            var actual = obj.MakeFinalDecisionAbsoluteParameter(totalNumberOfIssues, acceptedNumberOfIssues);
            var expected = true;

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void When_Input_totalNumberOfIssues_Is_Lesser_Than_AcceptedNumberOfissues_Should_Return_True_But_Asserted_Against_False()
        {
            FinalDecisionGatingParameter.FinalDecisionGatingParameter obj = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();
            int totalNumberOfIssues = 6;
            int acceptedNumberOfIssues = 8;

            var actual = obj.MakeFinalDecisionAbsoluteParameter(totalNumberOfIssues, acceptedNumberOfIssues);
            var expected = false;

            Assert.AreNotEqual(actual, expected);

        }




    }
}
