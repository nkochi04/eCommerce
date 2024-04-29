using Playground.Models;

namespace Playground
{
    public class SeedData
    {
        //Initializing the database 
        public static void Initialize(AppDbContext _db)
        {
            if (_db.TodoItems.Any())
            {
                return;
            }

            _db.TodoItems.AddRange(
                new TodoItem { Name = "Mathe", IsComplete = true },
                new TodoItem { Name = "Deutsch", IsComplete = true }
            );
            _db.SaveChanges();
        }
    }
}
