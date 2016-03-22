using System;
using ConsoleBasedSocialNetworkApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ConsoleBasedSocialNetworkApplicationTests
{
    [TestFixture]
    public class PostTestFixture
    {
        [Test]
        public void PostGetFullPost_ValidInput_GetCorrectStringBack()
        {
            // arrange

            var post = new Post("test post", "userName");
            // act

            var fullpost = post.GetFullPost();
            // assert
            Assert.AreEqual("test post (0 seconds ago)",fullpost);
        }
    }
}
