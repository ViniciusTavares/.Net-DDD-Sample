
using Domain.Enums;
using Domain.Models;
using Domain.Services.Contracts;
using Infrastructure.Config;
using Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap;

namespace Domain.Services.Tests
{
    [TestClass]
    public class PeopleServiceTests
    {
        [TestMethod]
        public void GetByIdTest()
        {
            Mock<IPeopleService> mockService = new Mock<IPeopleService>();

            mockService.Setup(t => t.Single(1)).Returns(new People()
            {
                Name = "Vinicius R. T",
                Age = 21,
                Id = 1
            });

            People people = mockService.Object.Single(1);

            mockService.VerifyAll();

            Assert.IsNotNull(people);
        }
    }
}
