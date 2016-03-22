using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedSocialNetworkApplication
{
    public class SocialNetwork
    {
        private readonly List<User> _users = new List<User>();

        public void Post(string input)
        {
            var userName = input.Split(' ').First();
            var postMessage = input.Split('>').Last();

            var existingUser = _users.FirstOrDefault(u => u.Name == userName);

            if (existingUser != null)
            {
                existingUser.AddPost(postMessage,existingUser.Name);
                return;
            }

            var newUser = new User(userName);
            newUser.AddPost(postMessage,newUser.Name);
            _users.Add(newUser);
        }

        public User Read(string input)
        {
            var userName = input;
            if (_users.Any(u => u.Name == userName))
            {
                return _users.FirstOrDefault(u => u.Name == userName);
            }
            var newUser = new User(userName);
            _users.Add(newUser);
            return newUser;
        }

        public void Follow(string input)
        {
            var userName = input.Split(' ').First();
            var userToFollowName = input.Split(' ').Last();
            var userToFollow = _users.FirstOrDefault(u => u.Name == userToFollowName);

            if (userToFollow == null)
            {
                userToFollow = new User(userToFollowName);
                _users.Add(userToFollow);
            }
            if (_users.Any(u => u.Name == userName))
            {
                var existingUser = _users.FirstOrDefault(u => u.Name == userName);

                existingUser.AddFollowing(userToFollow);
                return;
            }

            var newUser = new User(userName);
            newUser.AddFollowing(userToFollow);
            _users.Add(newUser);
        }

        public List<Post> Wall(string input)
        {
            var userName = input.Split(' ').First();
            var posts = new List<Post>();
            if (_users.Any(u => u.Name == userName))
            {
                var existingUser = _users.Single(u => u.Name == userName);
                posts.AddRange(existingUser.Timeline);

                var followers = existingUser.Following;

                foreach (var follower in followers)
                {
                    posts.AddRange(follower.Timeline);
                }

                return posts.OrderByDescending(x => x.Created).ToList();
            }
            var newUser = new User(userName);
            _users.Add(newUser);
            return newUser.Timeline;
        }

        public List<User> Users
        {
            get { return _users; }
        }
    }
}
