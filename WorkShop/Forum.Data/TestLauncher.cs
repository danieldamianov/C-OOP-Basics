using System;

namespace Forum.Data
{
    class TestLauncher
    {
        static void Main(string[] args)
        {
            ForumData forumData = new ForumData();
            foreach (var category in forumData.Categories)
            {
                Console.WriteLine(category.Name);
            }
            foreach (var post in forumData.Posts)
            {
                Console.WriteLine(post.Content);
            }
            foreach (var user in forumData.Users)
            {
                Console.WriteLine(user.Password);
            }
            foreach (var reply in forumData.Replies)
            {
                Console.WriteLine(reply.Content);
            }
            forumData.SaveChanges();
        }
    }
}
