using System;

namespace ConsoleBasedSocialNetworkApplication
{
    public class Post
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public Post(string message,string name)
        {
            Name = name;
            Message = message;
            Created = DateTime.Now;
        }

        public string GetFullPost()
        {
            string createdString = "unknown date";
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - Created.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                createdString = ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 120)
            {
                createdString = "a minute ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 2700) // 45 * 60
            {
                createdString = ts.Minutes + " minutes ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 5400) // 90 * 60
            {
                createdString = "an hour ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                createdString = ts.Hours + " hours ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                createdString = "yesterday";
                return string.Format("{0} ({1})", Message, createdString);
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                createdString = ts.Days + " days ago";
                return string.Format("{0} ({1})", Message, createdString);
            }
            return string.Format("{0} ({1})", Message, createdString);
            
        }
    }
}