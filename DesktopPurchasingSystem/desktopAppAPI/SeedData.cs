using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DesktopAppAPI
{
    public class SeedData
    {
        //Initializing the database 
        public static void Initialize(desktopAppDbContext _db)
        {
            //empties all tables
            ClearAllTables(_db);
            _db.SaveChanges();

            //init users
            if (!_db.Users.Any())
            {
                InitializeUsers(_db);
                _db.SaveChanges();
            }

            //init suppliers
            if (!_db.Suppliers.Any())
            {
                InitializeSuppliers(_db);
                _db.SaveChanges();
            }

            //init sellers
            if (!_db.Sellers.Any())
            {
                InitializeSellers(_db);
                _db.SaveChanges();
            }

            //init addresses
            if (!_db.Addresses.Any())
            {
                InitializeAddresses(_db);
                _db.SaveChanges();
            }

            //init departments
            if (!_db.Departments.Any())
            {
                InitializeDepartments(_db);
                _db.SaveChanges();
            }

            //init products
            if (!_db.Products.Any())
            {
                InitializeProducts(_db);
                _db.SaveChanges();
            }

            //init product_serialnumbers
            if (!_db.Product_SerialNumbers.Any())
            {
                InitializeProductSerialNumber(_db);
                _db.SaveChanges();
            }

            _db.SaveChanges();
        }

        private static void ClearAllTables(desktopAppDbContext _db)
        {
            _db.Addresses.ExecuteDelete();
            _db.Departments.ExecuteDelete();
            _db.Orders.ExecuteDelete();
            _db.OrderXProducts.ExecuteDelete();
            _db.Products.ExecuteDelete();
            _db.Product_SerialNumbers.ExecuteDelete();
            _db.Sellers.ExecuteDelete();
            _db.Suppliers.ExecuteDelete();
            _db.Users.ExecuteDelete();
        }
        private static void InitializeSuppliers(desktopAppDbContext _db)
        {
            _db.Suppliers.AddRange(
                new SupplierModel
                {
                    ID = Guid.NewGuid(),
                    Name = "DHL",
                    Delivery_Period_In_Days = 7,
                    Price_Per_Delivery = 100.0f
                },
                new SupplierModel
                {
                    ID = Guid.NewGuid(),
                    Name = "Amazon",
                    Delivery_Period_In_Days = 14,
                    Price_Per_Delivery = 200.0f
                },
                new SupplierModel
                {
                    ID = Guid.NewGuid(),
                    Name = "Hermes",
                    Delivery_Period_In_Days = 21,
                    Price_Per_Delivery = 300.0f
                }
             );
        }
        private static void InitializeSellers(desktopAppDbContext _db)
        {
            _db.Sellers.AddRange(
                new SellerModel
                {
                    ID = Guid.NewGuid(),
                    Adress_ID = Guid.NewGuid(),
                    Name = "Amazon",
                    Email = "seller1@example.com"
                },
                new SellerModel
                {
                    ID = Guid.NewGuid(),
                    Adress_ID = Guid.NewGuid(),
                    Name = "Mediamarkt",
                    Email = "seller2@example.com"
                },
                new SellerModel
                {
                    ID = Guid.NewGuid(),
                    Adress_ID = Guid.NewGuid(),
                    Name = "Siemens",
                    Email = "seller3@example.com"
                }
            );
        }
        private static void InitializeAddresses(desktopAppDbContext _db)
        {
            List<SellerModel> seller = _db.Sellers.ToList();
            _db.Addresses.AddRange(
                new AddressModel
                {
                    ID = seller[0].Adress_ID,
                    Number = 123,
                    Road = "Main Street",
                    Postalcode = "12345",
                    Country = "Usebkistan"
                },
                new AddressModel
                {
                    ID = seller[1].Adress_ID,
                    Number = 456,
                    Road = "Second Avenue",
                    Postalcode = "67890",
                    Country = "Kirgestan"
                },
                new AddressModel
                {
                    ID = seller[2].Adress_ID,
                    Number = 789,
                    Road = "Third Boulevard",
                    Postalcode = "11223",
                    Country = "Kasachstan"
                }
            );
        }
        private static void InitializeDepartments(desktopAppDbContext _db)
        {
            _db.Departments.AddRange(
                    new DepartmentModel { ID = Guid.Parse("F6AD2804-8615-4178-A4F0-131215E9E2AC"), Name = "Human Ressources", Payment_Adress = "Address 1" },
                    new DepartmentModel { ID = Guid.Parse("C56ECB55-61A9-4E3A-977E-FE8D0ACF78D7"), Name = "Information Technology", Payment_Adress = "Address 2" },
                    new DepartmentModel { ID = Guid.Parse("25081B3E-903A-4A42-8B57-D7DB5740C806"), Name = "Software Development", Payment_Adress = "Address 3" },
                    new DepartmentModel { ID = Guid.Parse("6D6C3056-864A-4016-925C-A665BF597A4A"), Name = "Production", Payment_Adress = "Address 4" },
                    new DepartmentModel { ID = Guid.Parse("985540AB-A29F-4631-949E-E8A9F1FB2D57"), Name = "Logistics", Payment_Adress = "Address 5" },
                    new DepartmentModel { ID = Guid.Parse("D70596C6-888C-4567-8891-C755E87A5CED"), Name = "Facility Management", Payment_Adress = "Address 6" },
                    new DepartmentModel { ID = Guid.Parse("C3AA1D0D-B09A-498B-94BD-67587B5AD453"), Name = "Management", Payment_Adress = "Address 7" },
                    new DepartmentModel { ID = Guid.Parse("67C8F62A-F16D-4F6A-9624-17A4EC83E7E8"), Name = "Research and Development", Payment_Adress = "Address 8" },
                    new DepartmentModel { ID = Guid.Parse("65CD0617-A17A-4CF0-9576-06660C2F9E66"), Name = "Finance", Payment_Adress = "Address 9" },
                    new DepartmentModel { ID = Guid.Parse("0DE7ED39-9CA3-414D-A933-C8DBDCE33E92"), Name = "Sales", Payment_Adress = "Address 10" }
            );
        }
        private static void InitializeUsers(desktopAppDbContext _db)
        {
            _db.Users.AddRange(
                new UserModel { ID = Guid.NewGuid(), Username = "nkoch", Password = "1234", Firstname = "Nicolas", Lastname = "Koch", Department_ID = Guid.Parse("F6AD2804-8615-4178-A4F0-131215E9E2AC") },
                new UserModel { ID = Guid.NewGuid(), Username = "User2", Password = "Password2", Firstname = "Firstname2", Lastname = "Lastname2", Department_ID = Guid.Parse("C56ECB55-61A9-4E3A-977E-FE8D0ACF78D7") },
                new UserModel { ID = Guid.NewGuid(), Username = "User3", Password = "Password3", Firstname = "Firstname3", Lastname = "Lastname3", Department_ID = Guid.Parse("25081B3E-903A-4A42-8B57-D7DB5740C806") },
                new UserModel { ID = Guid.NewGuid(), Username = "User4", Password = "Password4", Firstname = "Firstname4", Lastname = "Lastname4", Department_ID = Guid.Parse("6D6C3056-864A-4016-925C-A665BF597A4A") },
                new UserModel { ID = Guid.NewGuid(), Username = "User5", Password = "Password5", Firstname = "Firstname5", Lastname = "Lastname5", Department_ID = Guid.Parse("985540AB-A29F-4631-949E-E8A9F1FB2D57") },
                new UserModel { ID = Guid.NewGuid(), Username = "User6", Password = "Password6", Firstname = "Firstname6", Lastname = "Lastname6", Department_ID = Guid.Parse("D70596C6-888C-4567-8891-C755E87A5CED") },
                new UserModel { ID = Guid.NewGuid(), Username = "User7", Password = "Password7", Firstname = "Firstname7", Lastname = "Lastname7", Department_ID = Guid.Parse("C3AA1D0D-B09A-498B-94BD-67587B5AD453") },
                new UserModel { ID = Guid.NewGuid(), Username = "User8", Password = "Password8", Firstname = "Firstname8", Lastname = "Lastname8", Department_ID = Guid.Parse("67C8F62A-F16D-4F6A-9624-17A4EC83E7E8") },
                new UserModel { ID = Guid.NewGuid(), Username = "User9", Password = "Password9", Firstname = "Firstname9", Lastname = "Lastname9", Department_ID = Guid.Parse("65CD0617-A17A-4CF0-9576-06660C2F9E66") },
                new UserModel { ID = Guid.NewGuid(), Username = "User10", Password = "Password10", Firstname = "Firstname10", Lastname = "Lastname10", Department_ID = Guid.Parse("D70596C6-888C-4567-8891-C755E87A5CED") },
                new UserModel { ID = Guid.NewGuid(), Username = "User11", Password = "Password11", Firstname = "Firstname11", Lastname = "Lastname11", Department_ID = Guid.Parse("F6AD2804-8615-4178-A4F0-131215E9E2AC") },
                new UserModel { ID = Guid.NewGuid(), Username = "User12", Password = "Password12", Firstname = "Firstname12", Lastname = "Lastname12", Department_ID = Guid.Parse("C56ECB55-61A9-4E3A-977E-FE8D0ACF78D7") },
                new UserModel { ID = Guid.NewGuid(), Username = "User13", Password = "Password13", Firstname = "Firstname13", Lastname = "Lastname13", Department_ID = Guid.Parse("25081B3E-903A-4A42-8B57-D7DB5740C806") },
                new UserModel { ID = Guid.NewGuid(), Username = "User14", Password = "Password14", Firstname = "Firstname14", Lastname = "Lastname14", Department_ID = Guid.Parse("6D6C3056-864A-4016-925C-A665BF597A4A") },
                new UserModel { ID = Guid.NewGuid(), Username = "User15", Password = "Password15", Firstname = "Firstname15", Lastname = "Lastname15", Department_ID = Guid.Parse("985540AB-A29F-4631-949E-E8A9F1FB2D57") },
                new UserModel { ID = Guid.NewGuid(), Username = "User16", Password = "Password16", Firstname = "Firstname16", Lastname = "Lastname16", Department_ID = Guid.Parse("D70596C6-888C-4567-8891-C755E87A5CED") },
                new UserModel { ID = Guid.NewGuid(), Username = "User17", Password = "Password17", Firstname = "Firstname17", Lastname = "Lastname17", Department_ID = Guid.Parse("C3AA1D0D-B09A-498B-94BD-67587B5AD453") },
                new UserModel { ID = Guid.NewGuid(), Username = "User18", Password = "Password18", Firstname = "Firstname18", Lastname = "Lastname18", Department_ID = Guid.Parse("67C8F62A-F16D-4F6A-9624-17A4EC83E7E8") },
                new UserModel { ID = Guid.NewGuid(), Username = "User19", Password = "Password19", Firstname = "Firstname19", Lastname = "Lastname19", Department_ID = Guid.Parse("65CD0617-A17A-4CF0-9576-06660C2F9E66") },
                new UserModel { ID = Guid.NewGuid(), Username = "User20", Password = "Password20", Firstname = "Firstname20", Lastname = "Lastname20", Department_ID = Guid.Parse("0DE7ED39-9CA3-414D-A933-C8DBDCE33E92") }
            );
        }


        private static void InitializeProducts(desktopAppDbContext _db)
        {
            List<string> products = new List<string> { "Computer", "Printer", "Telephone", "Fax machine", "Scanner", "Copier", "Monitor", "Keyboard", "Mouse", "Laptop", "Projector", "Power supply", "Iron for shirts", "Floor lamp", "Desk lamp", "Paper shredder", "Radio alarm clock", "USB hub", "Webcam", "Headset", "Speakers", "Mobile phone charger", "Tablet", "Smartboard", "Remote control", "Batteries", "Power cable", "Magnetic whiteboard", "Stapler", "Staple remover", "Letter scale", "Space heater", "Humidifier", "Iron for documents", "Paper shredder", "HDMI cable", "VGA cable", "DVI cable", "DisplayPort cable", "Ethernet cable", "USB cable", "Replacement ink cartridges", "Replacement toner cartridges", "Office chair with massage function", "Footrest", "Laptop stand", "Desk fan", "Water dispenser", "Coffee machine" };

            List<SellerModel> seller = _db.Sellers.ToList();

            //GetImages(products);

            

            for (int i = 0; i < products.Count; i++)
            {
                _db.Products.Add(
                    new ProductModel
                    {
                        ID = Guid.NewGuid(),
                        Seller_ID = seller[i % 3].ID,
                        Name = products[i],
                        PiecesAvailable = 50,
                        Price = 35
                    }
                );
            }

        }

        //private async static void GetImages(List<string> products)
        //{
        //    HttpClient client = new HttpClient();
        //    for (int i = 0; i < 50; i++)
        //    {
        //        string url = $"https://source.unsplash.com/random?product&sig={products[i]}";
        //        HttpResponseMessage response = await client.GetAsync(url);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
        //            await File.WriteAllBytesAsync($"Images/image{i}.jpg", imageBytes);
        //            // Save imageBytes to a file or use as needed
        //        }
        //    }
        //}

        private static void InitializeProductSerialNumber(desktopAppDbContext _db)
        {
            Random random = new Random();
            int randomNumber;
            foreach (var product in _db.Products)
            {
                for (int i = 0; i < 10; i++)
                {
                    randomNumber = random.Next(100000000, 1000000000);
                    _db.Add(new ProductSerialNumberModel { Product_ID = product.ID, Serial_Number = randomNumber, Sold = false });
                }
            }

        }



    }
}
