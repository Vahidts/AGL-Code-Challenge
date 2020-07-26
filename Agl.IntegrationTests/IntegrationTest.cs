using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGL_Code_Challenge;
using System.Threading.Tasks;

namespace Agl.IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void AGLCodeChallengeIntegrationTestAsync()
        {
            var args = new string[] { "cat" };
            Task.Run(async () => await Program.Main(args));
            Assert.AreEqual(0, Environment.ExitCode);
        }
    }
}
