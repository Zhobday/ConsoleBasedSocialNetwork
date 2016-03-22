using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedSocialNetworkApplication
{
    public class User
    {
        private readonly List<Post> _timeline = new List<Post>(); 
        private readonly List<User> _following = new List<User>(); 
        
        public User(string name)
        {
            Name = name;
        }

        public void AddPost(string postMessage,string userName)
        {
            var post = new Post(postMessage,userName);
            _timeline.Add(post);
        }

        public void AddFollowing(User user)
        {
            _following.Add(user);
        }


        public string Name { get; set; }

        public List<Post> Timeline
        {
            get { return _timeline; }
        }

        public List<User> Following
        {
            get { return _following; }
        }
    }
}
