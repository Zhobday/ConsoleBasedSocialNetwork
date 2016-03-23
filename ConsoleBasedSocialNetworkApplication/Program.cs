using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedSocialNetworkApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var socialNetwork = new SocialNetwork();
            Boolean quitNow = false;
            string input;

            Console.WriteLine("Hello and welcome to The Console Based Social Network.");
            Console.WriteLine("If you're new here type 'help' for instructions!");

            while (!quitNow)
            {
                input = Console.ReadLine();

                if (input.Contains("->"))
                {
                    socialNetwork.Post(input);
                }
                else if (input.ToLower() == "exit")
                {
                    quitNow = true;
                }
                else if (input.ToLower() == "help")
                {
                    Console.WriteLine("To post a message type: <user name> -> <message>");
                    Console.WriteLine("To read an existing users timeline type: <user name>");
                    Console.WriteLine("To follow another user type: <user name> follows <another user>");
                    Console.WriteLine("To view a wall type:  <user name> wall");
                    Console.WriteLine("Dont worry if you're not an existing user, new user names will be added on commands!");
                    Console.WriteLine("If you're done having fun and want to leave type: exit");
                }
                else if (!input.Contains(" "))
                {
                    var user = socialNetwork.Read(input);

                    foreach (var post in user.Timeline)
                    {
                        Console.WriteLine(post.GetFullPost());
                    }
                }
                else if (input.Contains("follows"))
                {
                    socialNetwork.Follow(input);
                }
                else if (input.Contains("wall"))
                {
                    var wallPosts = socialNetwork.Wall(input);

                    foreach (var post in wallPosts)
                    {
                        Console.WriteLine("{0} - {1}",post.Name,post.GetFullPost());
                    }
                }
                

            }

        }
    }
}
