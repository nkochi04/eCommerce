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
            List<string> products = ["Computer", "Printer", "Telephone", "Fax machine", "Scanner", "Copier", "Monitor", "Keyboard", "Mouse", "Laptop", "Projector", "Power supply", "Iron for shirts", "Floor lamp", "Desk lamp", "Paper shredder", "Radio alarm clock", "USB hub", "Webcam", "Headset", "Speakers", "Mobile phone charger", "Tablet", "Smartboard", "Remote control", "Batteries", "Power cable", "Magnetic whiteboard", "Stapler", "Staple remover", "Letter scale", "Space heater", "Humidifier", "Iron for documents", "HDMI cable", "VGA cable", "DVI cable", "DisplayPort cable", "Ethernet cable", "USB cable", "Replacement ink cartridges", "Replacement toner cartridges", "Office chair with massage function", "Footrest", "Laptop stand", "Desk fan", "Water dispenser", "Coffee machine"];

            List<SellerModel> seller = [.. _db.Sellers];

            for (int i = 0; i < products.Count; i++)
            {
                _db.Products.Add(
                    new ProductModel
                    {
                        ID = Guid.NewGuid(),
                        Seller_ID = seller[i % 3].ID,
                        Name = products[i],
                        PiecesAvailable = 50,
                        Price = 35,
                        ImageData = File.ReadAllBytes($"Images/{products[i].Replace(" ", string.Empty).ToLower()}.jpg")
                    }
                );
            }
        }

        private static void InitializeProductSerialNumber(desktopAppDbContext _db)
        {
            Random random = new();
            int randomNumber;
            foreach (var product in _db.Products)
            {
                for (int i = 0; i < 10; i++)
                {
                    randomNumber = random.Next(100000000, 1000000000);
                    _db.Add(new PieceModel { Product_ID = product.ID, Serial_Number = randomNumber, Sold = false });
                }
            }
        }
    }
}
