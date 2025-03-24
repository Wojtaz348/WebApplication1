namespace WebApplication1.Model
{
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class Task
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int PriorityId { get; set; }
            public int StatusId { get; set; }
            public int CategoryId { get; set; }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Comment
        {
            public int Id { get; set; }
            public int TaskId { get; set; }
            public string Content { get; set; }
        }

        public class Priority
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Status
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }

