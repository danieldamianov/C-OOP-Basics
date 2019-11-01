using Forum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Forum.Data
{
    class DataMapper
    {
        private const string DATA_PATH = "../data/";

        private const string CONFIG_PATH = "config.ini";

        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        private static void EnsureConfigFile(string configPath)
        {
            if (File.Exists(configPath) == false)
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (File.Exists(path) == false)
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string , string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            string[] content = ReadLines(configPath);

            Dictionary<string, string> config = content.Select(x => x.Split('=')).ToDictionary(x => x[0], x => DATA_PATH + x[1]);

            return config;
        } 

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);

            var content = File.ReadAllLines(path);

            return content;
        }

        private static void WriteLines(string path , string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();

            string[] content = ReadLines(config["categories"]);

            foreach (var line in content)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string name = tokens[1];
                string posts = tokens[2];

                int[] postsSplitted = posts.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Category category = new Category(id, name, postsSplitted);

                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (var cateory in categories)
            {
                const string categoryFormat = "{0};{1};{2}";

                string line = string.Format(categoryFormat, cateory.Id, cateory.Name, string.Join(',', cateory.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            string[] content = ReadLines(config["users"]);

            foreach (var line in content)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string userName = tokens[1];
                string password = tokens[2];
                int[] postsSplitted = tokens[3].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                User user = new User(id, userName, password, postsSplitted);

                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (var user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";

                string line = string.Format(userFormat, user.Id, user.Username, user.Password, string.Join(',', user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }
       
        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();

            string[] content = ReadLines(config["posts"]);

            foreach (var line in content)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string title = tokens[1];
                string contentOfPost = tokens[2];
                int categoryId = int.Parse(tokens[3]);
                int authorId = int.Parse(tokens[4]);
                int[] repliesSplitted = tokens[5].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Post post = new Post(id,title,contentOfPost,categoryId,authorId,repliesSplitted);

                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (var post in posts)
            {
                const string postFormat = "{0};{1};{2};{3};{4};{5}";

                string line = string.Format(postFormat, post.Id, post.Title, post.Content,post.CategoryId,post.AuthorId, string.Join(',', post.ReplyIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();

            string[] content = ReadLines(config["replies"]);

            foreach (var line in content)
            {
                string[] tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(tokens[0]);
                string contentOfReply = tokens[1];
                int authorId = int.Parse(tokens[2]);
                int postId = int.Parse(tokens[3]);

                Reply reply = new Reply(id, contentOfReply, authorId, postId);

                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (var reply in replies)
            {
                const string replyFormat = "{0};{1};{2};{3}";

                string line = string.Format(replyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
