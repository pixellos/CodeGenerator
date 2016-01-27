using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Tests
{
    [TestClass()]
    public class FriendlyCodeGeneratorAvrTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            FriendlyCodeGeneratorAvr friendlyCodeGeneratorAvr = new FriendlyCodeGeneratorAvr();
            friendlyCodeGeneratorAvr.GenerateFromAvrModel();

        }

        [TestMethod()]
        public void FriendlyCodeGeneratorAvrTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GenerateFromAvrModelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GenerateFromAllFilesTest()
        {
            Assert.Fail();
        }
    }
}