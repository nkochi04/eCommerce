using DesktopAppAPI.Models;

namespace DesktopAppAPI
{
    public class SeedData
    {
        //Initializing the database 
        public static void Initialize(desktopAppDbContext _db)
        {
            if (_db.Users.Any())
            {
                return;
            }

            _db.Users.AddRange(
                new UserModel
                {
                    ID = Guid.NewGuid(),
                    Username = "user1",
                    Password = "password1",
                    Firstname = "John",
                    Lastname = "Doe",
                    Department_ID = Guid.NewGuid()
                },
                new UserModel
                {
                    ID = Guid.NewGuid(),
                    Username = "user2",
                    Password = "password2",
                    Firstname = "Jane",
                    Lastname = "Doe",
                    Department_ID = Guid.NewGuid()
                }
            );
            _db.SaveChanges();
        }
    }
}
