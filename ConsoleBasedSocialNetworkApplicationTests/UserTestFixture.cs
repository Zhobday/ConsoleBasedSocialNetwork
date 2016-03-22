using System;
using ConsoleBasedSocialNetworkApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ConsoleBasedSocialNetworkApplicationTests
{
    [TestFixture]
    public class UserTestFixture
    {
        [Test]
        public void UserAddPost_ValidInput_UserHasNewPostAdded()
        {
            // arrange
            var user = new User("user");
            // act
            user.AddPost("test post",user.Name);
            // assert
            Assert.AreEqual(user.Timeline.Count,1);
            Assert.AreEqual(user.Timeline[0].Message, "test post");
        }

        [Test]
        public void UserAddFollower_ValidInput_UserHasNewFollowerAdded()
        {
            // arrange
            var user = new User("user");
            var follower = new User("follower");
            // act
            user.AddFollowing(follower);
            // assert
            Assert.AreEqual(user.Following.Count, 1);
            Assert.AreEqual(user.Following[0].Name, "follower");
        }
    }
}
