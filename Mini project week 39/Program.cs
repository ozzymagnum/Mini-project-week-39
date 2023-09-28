
    
        // Create assets of different categories
        Computer computer1 = new Computer("Computer", "HP", "EliteBook", "France", Convert.ToDateTime("2022-10-10"), 1000);
        Computer computer2 = new Computer("Phone", "Samsung", "XL", "France", Convert.ToDateTime("2022-11-10"), 1000);
        Phone phone1 = new Phone("Phone", "IPhone", "XLL", "Sweden", Convert.ToDateTime("2023-10-10"), 100);

        // Create a list of assets
        List<Asset> assets = new List<Asset>
        {
            computer1,
            computer2,
            phone1
        };

        // Sort the assets by category (computers first, phones second) and then by purchase date
        var sortedAssets = assets
        .OrderBy(asset => asset is Computer ? 0 : 1) // Sort by category
        .ThenBy(asset => asset.PurchaseDate)          // Sort by purchase date
        .ToList();


        // Display assets with category names in line
        Console.WriteLine("Category".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "PurchaseDate".PadRight(15) + "Price");
        Console.WriteLine("___________________________________________________________________________________");

        foreach (Asset asset in sortedAssets)
        {
        string color = ""; // Initialize color as an empty string
        DateTime currentDate = DateTime.Now;
        DateTime threeYearsFromPurchase = asset.PurchaseDate.AddYears(3);

         // Check if the purchase date is less than 3 months away from 3 years
         if (threeYearsFromPurchase.AddMonths(-3) <= currentDate)
        {
        color = "RED";
        }

        Console.WriteLine($"{asset.Type.PadRight(15)}{asset.Brand.PadRight(15)}{asset.Model.PadRight(15)}{asset.Office.PadRight(15)}{asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15)}{asset.Price}{color}");
        }

        Console.ReadLine(); // Wait for user input before exiting




class Asset
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Office { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double Price { get; set; }

    public Asset(string type, string brand, string model, string office, DateTime purchaseDate, double price)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
    }
}

class Computer : Asset
{
    public Computer(string type, string brand, string model, string office, DateTime purchaseDate, double price)
        : base(type, brand, model, office, purchaseDate, price)
    {
    }
}

class Phone : Asset
{
    public Phone(string type, string brand, string model, string office, DateTime purchaseDate, double price)
        : base(type, brand, model, office, purchaseDate, price)
    {
    }
}


   

