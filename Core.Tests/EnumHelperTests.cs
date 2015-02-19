using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Util;

namespace Core.Tests
{
    [TestClass]
    public class EnumHelperTests
    {
        [TestMethod]
        public void EnumDescriptionTest()
        {
            string Description = PeopleType.Administrator.Description();

            Assert.IsTrue(Description == "Admin");
        }
    }
}
