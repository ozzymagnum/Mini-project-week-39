

// Create assets of different categories
using System.ComponentModel.DataAnnotations;
using System.Drawing;

Computer computer1 = new Computer("Computer", "HP", "EliteBook", "France", Convert.ToDateTime("2020-09-10"), 1000, 86.29);
Computer computer2 = new Computer("Computer", "MAC", "AirBook", "France", Convert.ToDateTime("2015-11-10"), 1000, 86.29);
Computer computer3 = new Computer("Computer", "ASUS", "XS", "Spain", Convert.ToDateTime("2018-12-10"), 1423, 122.80);
Computer computer4 = new Computer("Computer", "HP", "A34", "Denmark", Convert.ToDateTime("2023-09-15"), 723, 465.19);
Phone phone1 = new Phone("Phone", "IPhone", "XLL", "Sweden", Convert.ToDateTime("2023-8-10"), 100, 100);
Phone phone2 = new Phone("Phone", "Android", "SL", "USA", Convert.ToDateTime("2022-4-10"), 999, 90.62);

// Create a list of assets
List<Asset> assets = new List<Asset>
        {
            computer1,
            computer2,
            computer3,
            computer4,
            phone1,
            phone2
        };

        // Sort the assets by category (computers first, phones second) and then by purchase date
        var sortedAssets = assets
        .OrderBy(asset => asset is Computer ? 0 : 1) // Sort by categor)
         .ThenBy(asset => asset.Office)               // Sort by office
        .ThenBy(asset => asset.PurchaseDate)          // Sort by purchase date
        .ToList();



        //Days between puchase date and today to choose color
        int daysWarning = 990; //Approx 33 months - yellow  
        int daysAlarm = 1080;  //Approx 36 months - red

Console.WriteLine("Category".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "PurchaseDate".PadRight(15) + "Price in SEK".PadRight(15) + "Local price today");
Console.WriteLine("___________________________________________________________________________________________________________");

foreach (Asset asset in sortedAssets)
        {
            TimeSpan diff = DateTime.Now - asset.PurchaseDate;//Calculate time span between today and purchase date
            DecideForegroundColor(daysWarning, daysAlarm, diff);//Decide right color according to date
            Console.WriteLine(asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(15) + asset.Price.ToString().PadRight(15) + asset.Currency);
        }

        static void DecideForegroundColor(int daysWarning, int daysAlarm, TimeSpan diff)
        {
            if (diff.Days > daysAlarm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (diff.Days > daysWarning && diff.Days < daysAlarm)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }



class Asset
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Office { get; set; }
    public DateTime PurchaseDate { get; set; }
    public double Price { get; set; }

    public double Currency { get; set; }

    public Asset(string type, string brand, string model, string office, DateTime purchaseDate, double price, double currency)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
        Currency = currency;
    }
}

class Computer : Asset
{
    public Computer(string type, string brand, string model, string office, DateTime purchaseDate, double price, double currency)
        : base(type, brand, model, office, purchaseDate, price, currency)
    {
    }
}

class Phone : Asset
{
    public Phone(string type, string brand, string model, string office, DateTime purchaseDate, double price, double currency)
        : base(type, brand, model, office, purchaseDate, price, currency)
    {
    }
}


   

