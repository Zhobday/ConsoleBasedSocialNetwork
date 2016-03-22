using System;
using System.Linq;
using ConsoleBasedSocialNetworkApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ConsoleBasedSocialNetworkApplicationTests
{
    [TestFixture]
    public class SocialNetworkTestFixture
    {
        [Test]
        public void SocialNetworkPost_InputValidNewUser_CreateNewUserWithPost()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            // act
            socialNetwork.Post("newuser -> hello world");

            // assert
            var newUser = socialNetwork.Users.Single(u => u.Name == "newuser");
            Assert.IsNotEmpty(socialNetwork.Users);
            Assert.AreEqual(newUser.Timeline[0].Message," hello world");
            
        }
        [Test]
        public void SocialNetworkPost_InputValidExistingUser_CreateNewUserWithPost()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            socialNetwork.Users.Add(new User("existinguser"));
            // act
            socialNetwork.Post("existinguser -> hello world");

            // assert
            var existingUser = socialNetwork.Users.Single(u => u.Name == "existinguser");
            Assert.IsNotEmpty(socialNetwork.Users);
            Assert.AreEqual(existingUser.Timeline[0].Message, " hello world");

        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SocialNetworkPost_InputInValid_ExpectException()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            socialNetwork.Users.Add(new User("existinguser"));
            // act
            socialNetwork.Post("abcdefg");

            // assert

        }

        [Test]
        public void SocialNetworkRead_ReadExistingUserFromNetwork_ReturnUser()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            var user = new User("existinguser");
            // act
            var returnedUser = socialNetwork.Read("existinguser");

            // assert
            Assert.AreEqual(returnedUser.Name,user.Name);

        }

        [Test]
        public void SocialNetworkRead_ReadNewUserFromNetwork_ReturnUser()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            // act
            var returnedUser = socialNetwork.Read("newUser");

            // assert
            Assert.AreEqual(returnedUser.Name, "newUser");

        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SocialNetworkRead_InputIsInvalid_ExpectException()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            // act
            socialNetwork.Read("abcdefg");

            // assert
        }

        [Test]
        public void SocialNetworkFollowing_InputNewUserToFollowExistingUser_NewUserFollowsExistingUser()
        {
            // arrange
            var socialNetwork = new SocialNetwork();
            socialNetwork.Users.Add(new User("existinguser"));

            // act
            socialNetwork.Follow("newuser follows existinguser");

            // assert

            var existingUser = socialNetwork.Users.Single(u => u.Name == "existinguser");
            var newUser = socialNetwork.Users.Single(u => u.Name == "newuser");
            Assert.AreEqual(socialNetwork.Users.Count,2);
            Assert.IsNotNull(existingUser);
            Assert.IsNotNull(newUser);
            Assert.IsTrue(newUser.Following[0].Name == "existinguser");
            
        }

        [Test]
        public void SocialNetworkFollowing_InputNewUserFollowNewUser_NewUserFollowsNewUser()
        {
            // arrange
            var socialNetwork = new SocialNetwork();

            // act
            socialNetwork.Follow("newuser follows newusertofollow");

            // assert

            var existingUser = socialNetwork.Users.Single(u => u.Name == "newusertofollow");
            var newUser = socialNetwork.Users.Single(u => u.Name == "newuser");
            Assert.AreEqual(socialNetwork.Users.Count, 2);
            Assert.IsNotNull(existingUser);
            Assert.IsNotNull(newUser);
            Assert.IsTrue(newUser.Following[0].Name == "newusertofollow");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SocialNetworkFollowing_InvalidInput_ExpectException()
        {
            // arrange
            var socialNetwork = new SocialNetwork();

            // act
            socialNetwork.Follow("abcdefg");
            // assert
        }

        [Test]
        public void SocialNetworkWall_InputExistingUserWall_ListOfCorrectPostsAreReturned()
        {
            // arrange
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1 -> hello");
            socialNetwork.Post("user2 -> world");
            socialNetwork.Post("user3 -> konechiwa");

            socialNetwork.Follow("user1 follows user2");
            socialNetwork.Follow("user1 follows user3");

            // act
            var wall = socialNetwork.Wall("user1 wall");
            // assert
            Assert.AreEqual(wall.Count,3);
            Assert.AreEqual(wall[0].Message, " hello");
            Assert.AreEqual(wall[1].Message, " world");
            Assert.AreEqual(wall[2].Message, " konechiwa");

        }

        [Test]
        public void SocialNetworkWall_InputNewUserWall_ListOfCorrectPostsAreReturned()
        {
            // arrange
            var socialNetwork = new SocialNetwork();


            // act
            var wall = socialNetwork.Wall("newuser wall");
            // assert
            Assert.AreEqual(wall.Count, 0);

        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void SocialNetworkWall_InvalidInput_ExpectException()
        {
            // arrange
            var socialNetwork = new SocialNetwork();


            // act
            var wall = socialNetwork.Wall("abcdefg");
            // assert

        }
    }
}
