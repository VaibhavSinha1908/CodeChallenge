using CodeTask.API.Models;
using CodeTask.API.Services;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using System;

namespace Service.Test
{
    [TestFixture]
    public class PremiumServiceTests
    {
        private IPremiumService _premiumService;
        private PremiumCalculationRequest _premiumCalculationRequest;
        private readonly IHostingEnvironment host;

        //Arrange
        [SetUp]
        public void Setup()
        {

        }

        //Act
        [TestCase("1999/09/30")]
        [TestCase("2000/11/16")]
        [TestCase("1950/01/20")]
        [TestCase("2015/05/01")]
        public void GetYears_Should_Return_Age_When_Dob_Is_Valid(string dob)
        {
            _premiumService = new PremiumService();

            var age = _premiumService.GetYears(dob);

            Assert.IsNotNull(age);

        }

        [Test]
        public void GetYears_Should_Throw_Exception_When_Input_Is_Nll()
        {
            _premiumService = new PremiumService();

            Assert.Throws<ArgumentNullException>(() => _premiumService.GetYears(null));

        }

        [TestCase(55, "2000", "1.25")]
        [TestCase(65, "20000", "1.50")]
        [TestCase(15, "200000", "1.00")]
        public void CalculatePremium_Should_Return_Premium_When_Input_Is_Valid(int age, string sumInsured, decimal factor)
        {
            _premiumService = new PremiumService();

            var premium = _premiumService.CalculatePremium(age, sumInsured, factor);

            Assert.IsNotNull(premium);
        }

        [TestCase(-1, "2000", "1.25")]
        [TestCase(65, "", "1.50")]
        [TestCase(15, null, "1.00")]
        [TestCase(-9, null, "1.25")]
        [TestCase(65, " ", "1.50")]
        [TestCase(-3, "200000", "1.00")]
        public void CalculatePremium_Should_Throw_Exception_When_Input_Is_InValid(int age, string sumInsured, decimal factor)
        {
            _premiumService = new PremiumService();

            Assert.Throws<Exception>(() => _premiumService.CalculatePremium(age, sumInsured, factor));
        }
    }
}
