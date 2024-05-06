using DesktopAppAPI.Models;
using Microsoft.EntityFrameworkCore;

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

            //init departments
            if (!_db.Departments.Any())
            {
                InitializeDepartments(_db);
                _db.SaveChanges();
            }

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
                    Price_Per_Delivery = 100.00f
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
                    Email = "amazon@example.com"
                },
                new SellerModel
                {
                    ID = Guid.NewGuid(),
                    Adress_ID = Guid.NewGuid(),
                    Name = "Mediamarkt",
                    Email = "mediamarkt@example.com"
                },
                new SellerModel
                {
                    ID = Guid.NewGuid(),
                    Adress_ID = Guid.NewGuid(),
                    Name = "Siemens",
                    Email = "siemens@example.com"
                }
            );
        }

        private static void InitializeAddresses(desktopAppDbContext _db)
        {
            List<SellerModel> seller = [.. _db.Sellers];
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
            Random random = new();
            List<string> names = ["Human Ressources", "Information Technology", "Software Development", "Production", "Logistics", "Facility Management", "Management", "Research and Development", "Finance", "Sales"];
            foreach (var name in names)
            {
                _db.Departments.Add(new DepartmentModel { ID = Guid.NewGuid(), Name = name, Payment_Adress = random.Next(1000, 10000).ToString() });
            }
        }

        private static void InitializeUsers(desktopAppDbContext _db)
        {
            int i = 1;
            foreach (var department in _db.Departments)
            {
                _db.Users.Add(new UserModel { ID = Guid.NewGuid(), Username = $"admin{i}", Password = "admin", Firstname = "admin", Lastname = "admin", Department_ID = department.ID });
                i++;
            }
            _db.Users.Add(new UserModel { ID = Guid.NewGuid(), Username = $"nkochi", Password = "admin", Firstname = "admin", Lastname = "admin", Department_ID = _db.Departments.Where(x => x.Name == "Management").SingleOrDefault().ID });
        }


        private static void InitializeProducts(desktopAppDbContext _db)
        {
            Dictionary<string, float> productPrices = new() { { "Computer", 1200.49f }, { "Printer", 149.99f }, { "Telephone", 79.99f }, { "Fax machine", 199.99f }, { "Scanner", 84.99f }, { "Copier", 299.99f }, { "Monitor", 249.99f }, { "Keyboard", 49.99f }, { "Mouse", 19.99f }, { "Laptop", 1499.99f }, { "Projector", 799.99f }, { "Power supply", 59.99f }, { "Iron for shirts", 34.99f }, { "Floor lamp", 44.99f }, { "Desk lamp", 29.99f }, { "Paper shredder", 64.99f }, { "Radio alarm clock", 24.99f }, { "USB hub", 14.99f }, { "Webcam", 69.99f }, { "Headset", 49.99f }, { "Speakers", 74.99f }, { "Mobile phone charger", 14.99f }, { "Tablet", 299.99f }, { "Smartboard", 1499.99f }, { "Remote control", 19.99f }, { "Batteries", 9.99f }, { "Power cable", 9.99f }, { "Magnetic whiteboard", 149.99f }, { "Stapler", 9.99f }, { "Staple remover", 4.99f }, { "Letter scale", 24.99f }, { "Space heater", 59.99f }, { "Humidifier", 39.99f }, { "Iron for documents", 34.99f }, { "HDMI cable", 14.99f }, { "VGA cable", 14.99f }, { "DVI cable", 14.99f }, { "DisplayPort cable", 19.99f }, { "Ethernet cable", 9.99f }, { "USB cable", 4.99f }, { "Replacement ink cartridges", 29.99f }, { "Replacement toner cartridges", 59.99f }, { "Office chair with massage function", 499.99f }, { "Footrest", 29.99f }, { "Laptop stand", 24.99f }, { "Desk fan", 29.99f }, { "Water dispenser", 99.99f }, { "Coffee machine", 149.99f } };

            List<SellerModel> seller = [.. _db.Sellers];

            Random random = new();

            foreach (var product in productPrices)
            {
                _db.Products.Add(
                    new ProductModel
                    {
                        ID = Guid.NewGuid(),
                        Seller_ID = seller[random.Next(0, 2)].ID,
                        Name = product.Key, // product name
                        PiecesAvailable = 10,
                        Price = product.Value, // product price
                        ImageData = File.ReadAllBytes($"Images/{product.Key.Replace(" ", string.Empty).ToLower()}.jpg")
                    }
                );
            }
        }

        private static void InitializeProductSerialNumber(desktopAppDbContext _db)
        {
            Random random = new();
            foreach (var product in _db.Products)
            {
                for (int i = 0; i < 10; i++)
                {
                    var randomNumber = random.Next(100000000, 1000000000);
                    _db.Add(new PieceModel { Product_ID = product.ID, Serial_Number = randomNumber, Sold = false });
                }
            }
        }
    }
}
