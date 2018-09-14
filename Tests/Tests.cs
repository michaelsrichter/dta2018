using System.IO;
using DTA2018.Helpers;
using NUnit.Framework;

namespace DTA2018.Tests
{
    [TestFixture]
    public class SimpleTests
    {

        [Test]
        public void ReturnTrueIsTrue()
        {
            var result = true;

            Assert.IsTrue(result, "true should be true");
        }
    }

    [TestFixture]
    public class UserInfoTests
    {

        [Test]
        public void GetUserIdFromMeJson()
        {
            var result = "mrichter@microsoft.com";

            var ui = new UserInfo(Path.Combine("Tests", "me.json"));
            Assert.AreEqual(result, ui.Id);
        }
    }
}