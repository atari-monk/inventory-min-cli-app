using Inventory.Min.Data;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                new string[] {"item", "ins", "insert"} 
            }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem((item) => item.Name = "update") 
                , new string[] {"item", "upd", "itemid", "-n", "update"} 
            }
            , new object[] 
            {
                1
                , GetItem((item) => item.Name = "--update") 
                , new string[] {"item", "upd", "itemid", "--name", "--update"} 
            }
            , new object[] 
            {
                2
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "descUpd") 
                , new string[] {"item", "upd", "itemid", "-d", "descUpd"} 
            }
            , new object[] 
            {
                3
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd") 
                , new string[] {"item", "upd", "itemid", "--desc", "--descUpd"} 
            }
            , new object[] 
            {
                4
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 10
                    )
                , new string[] {"item", "upd", "itemid", "-q", "10"} 
            }
            , new object[] 
            {
                5
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    )
                , new string[] {"item", "upd", "itemid", "--initialCount", "20"} 
            }
            , new object[] 
            {
                6
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 40
                    )
                , new string[] {"item", "upd", "itemid", "--currentCount", "40"} 
            }
            , new object[] 
            {
                7
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    )
                , new string[] {"item", "upd", "itemid", "--currentCount", "33"} 
            }
            , new object[] 
            {
                8
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 1)
                , new string[] {"item", "upd", "itemid", "-c", "1"} 
            }
            , new object[] 
            {
                9
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2)
                , new string[] {"item", "upd", "itemid", "--categoryId", "2"} 
            }
            , new object[] 
            {
                10
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 17, 16, 0))
                , new string[] {"item", "upd", "itemid", "-p", "18.08.2022 17:16"} 
            }
            , new object[] 
            {
                11
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0))
                , new string[] {"item", "upd", "itemid", "--purchaseDate", "18.08.2022 18:00"} 
            }
            , new object[] 
            {
                12
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 2)
                , new string[] {"item", "upd", "itemid", "-u", "2"} 
            }
            , new object[] 
            {
                13
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3)
                , new string[] {"item", "upd", "itemid", "--currencyId", "3"} 
            }
            , new object[] 
            {
                14
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 33.3m)
                , new string[] {"item", "upd", "itemid", "-r", "33.3"} 
            }
            , new object[] 
            {
                15
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m)
                , new string[] {"item", "upd", "itemid", "--purchasePrice", "99.6"} 
            }
            , new object[] 
            {
                16
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 15.7m)
                , new string[] {"item", "upd", "itemid", "-s", "15.7"} 
            }
            , new object[] 
            {
                17
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m)
                , new string[] {"item", "upd", "itemid", "--sellPrice", "78.1"} 
            }
            , new object[] 
            {
                18
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png")
                , new string[] {"item", "upd", "itemid", "-i", @"C:\kmazanek.gmail.com\Image\Inventory\test.png"} 
            }
            , new object[] 
            {
                19
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png")
                , new string[] {"item", "upd", "itemid", "--imagePath", @"C:\kmazanek.gmail.com\Image\Inventory\test.png"} 
            }
            , new object[] 
            {
                20
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 2)
                , new string[] {"item", "upd", "itemid", "-l", "2"} 
            }
            , new object[] 
            {
                21
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1)
                , new string[] {"item", "upd", "itemid", "--lengthUnitId", "1"} 
            }
            , new object[] 
            {
                22
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 66.6)
                , new string[] {"item", "upd", "itemid", "-e", "66.6"} 
            }
            , new object[] 
            {
                23
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4)
                , new string[] {"item", "upd", "itemid", "--length", "23.4"} 
            }
            , new object[] 
            {
                24
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 78.3)
                , new string[] {"item", "upd", "itemid", "-g", "78.3"} 
            }
            , new object[] 
            {
                25
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2)
                , new string[] {"item", "upd", "itemid", "--heigth", "45.2"} 
            }
            , new object[] 
            {
                26
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 13.6)
                , new string[] {"item", "upd", "itemid", "-t", "13.6"} 
            }
            , new object[] 
            {
                27
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3)
                , new string[] {"item", "upd", "itemid", "--depth", "17.3"} 
            }
            , new object[] 
            {
                28
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 167.3)
                , new string[] {"item", "upd", "itemid", "-a", "167.3"} 
            }
            , new object[] 
            {
                29
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2)
                , new string[] {"item", "upd", "itemid", "--diameter", "222.2"} 
            }
            , new object[] 
            {
                30
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 2)
                , new string[] {"item", "upd", "itemid", "-v", "2"} 
            }
            , new object[] 
            {
                31
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3)
                , new string[] {"item", "upd", "itemid", "--volumeUnitId", "3"} 
            }
            , new object[] 
            {
                32
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 31.7)
                , new string[] {"item", "upd", "itemid", "-o", "31.7"} 
            }
            , new object[] 
            {
                33
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3)
                , new string[] {"item", "upd", "itemid", "--volume", "41.3"} 
            }
            , new object[] 
            {
                34
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 222.9)
                , new string[] {"item", "upd", "itemid", "-m", "222.9"} 
            }
            , new object[] 
            {
                35
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2)
                , new string[] {"item", "upd", "itemid", "--mass", "453.2"} 
            }
            , new object[] 
            {
                36
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 4)
                , new string[] {"item", "upd", "itemid", "-x", "4"} 
            }
            , new object[] 
            {
                37
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3)
                , new string[] {"item", "upd", "itemid", "--massUnitId", "3"} 
            }
            , new object[] 
            {
                38
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 2)
                , new string[] {"item", "upd", "itemid", "-z", "2"} 
            }
            , new object[] 
            {
                39
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 1)
                , new string[] {"item", "upd", "itemid", "--tagId", "1"} 
            }
            , new object[] 
            {
                40
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 1
                    , (item) => item.StateId = 2)
                , new string[] {"item", "upd", "itemid", "-b", "2"} 
            }
            , new object[] 
            {
                41
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 1
                    , (item) => item.StateId = 3)
                , new string[] {"item", "upd", "itemid", "--stateId", "3"} 
            }
        };
    
    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] 
            {
                new string[] {"item", "ins", "insert2"} 
            }
        };

    public static IEnumerable<object[]> Update02 =>
        new List<object[]>
        {
            new object[]
            {
                0
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 1
                    , (item) => item.StateId = 3)
                , new string[] {"item", "upd", "itemid", "-f", "parentid"} 
            }
            , new object[]
            {
                1
                , GetItem((item) => item.Name = "--update"
                    , (item) => item.Description = "--descUpd"
                    , (item) => item.InitialCount = 20
                    , (item) => item.CurrentCount = 33
                    , (item) => item.CategoryId = 2
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)
                    , (item) => item.CurrencyId = 3
                    , (item) => item.PurchasePrice = 99.6m
                    , (item) => item.SellPrice = 78.1m
                    , (item) => item.ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png"
                    , (item) => item.LengthUnitId = 1
                    , (item) => item.Length = 23.4
                    , (item) => item.Heigth = 45.2
                    , (item) => item.Depth = 17.3
                    , (item) => item.Diameter = 222.2
                    , (item) => item.VolumeUnitId = 3
                    , (item) => item.Volume = 41.3
                    , (item) => item.Mass = 453.2
                    , (item) => item.MassUnitId = 3
                    , (item) => item.TagId = 1
                    , (item) => item.StateId = 3)
                , new string[] {"item", "upd", "itemid", "--parentId", "parentid"} 
            }
        };

    private static Item GetItem()
    {
        return new Item {
            Name = "insert"
            , CurrencyId = 1
            , LengthUnitId = 1
            , VolumeUnitId = 1
            , MassUnitId = 3 };
    }

    private static Item GetItem(Action<Item> action)
    {
        var item = GetItem();
        action(item);
        return item;
    }

    private static Item GetItem(params Action<Item>[] actions)
    {
        var item = GetItem();
        foreach (var action in actions)
        {
            action(item);
        }
        return item;
    }
}