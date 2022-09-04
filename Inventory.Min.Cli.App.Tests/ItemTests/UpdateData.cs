using Inventory.Min.Data;
using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateData
{
    private const string ImgRoot = @"C:\kmazanek.gmail.com\Image\Inventory";
    private const string Img1 = @"\img1.png";
    private const string Img2 = @"\img2.png";

    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { 0, d.GetInsCmd() }
        };

    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
              new object[] { 0, nameof(Item.Name), d.GetItem((item) => item.Name = d.NameUpd), d.GetUpdCmd("-n", d.NameUpd) }
            , new object[] { 1, nameof(Item.Name), d.GetItem((item) => item.Name = d.Name) , d.GetUpdCmd("--name", d.Name) }
            , new object[] { 2, nameof(Item.Description), d.GetItem((item) => item.Description = d.Description), d.GetUpdCmd("-d", d.Description) }
            , new object[] { 3, nameof(Item.Description), d.GetItem((item) => item.Description = d.DescriptionUpd), d.GetUpdCmd("--desc", d.DescriptionUpd) } 
            , new object[] { 4, nameof(Item.InitialCount), d.GetItem((item) => item.InitialCount = 10), d.GetUpdCmd("-q", "10") }
            , new object[] { 5, nameof(Item.InitialCount), d.GetItem((item) => item.InitialCount = 20), d.GetUpdCmd("--initialCount", "20") }
            , new object[] { 6, nameof(Item.CurrentCount), d.GetItem((item) => item.CurrentCount = 40), d.GetUpdCmd("--currentCount", "40") }
            , new object[] { 7, nameof(Item.CurrentCount), d.GetItem((item) => item.CurrentCount = 33), d.GetUpdCmd("--currentCount", "33") }
            , new object[] { 8, nameof(Item.PurchaseDate), d.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 17, 16, 0)), d.GetUpdCmd("-p", "18.08.2022 17:16") }
            , new object[] { 9, nameof(Item.PurchaseDate), d.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)), d.GetUpdCmd("-p", "18.08.2022 18:00") }
            , new object[] { 10, nameof(Item.PurchasePrice), d.GetItem((item) => item.PurchasePrice = 33.3m), d.GetUpdCmd("-r", "33.3") }
            , new object[] { 11, nameof(Item.PurchasePrice), d.GetItem((item) => item.PurchasePrice = 99.6m), d.GetUpdCmd("--purchasePrice", "99.6") }
            , new object[] { 12, nameof(Item.SellPrice), d.GetItem((item) => item.SellPrice = 15.7m), d.GetUpdCmd("-s", "15.7") }
            , new object[] { 13, nameof(Item.SellPrice), d.GetItem((item) => item.SellPrice = 78.1m), d.GetUpdCmd("--sellPrice", "78.1") }
            , new object[] { 14, nameof(Item.ImagePath), d.GetItem((item) => item.ImagePath = ImgRoot + Img1), d.GetUpdCmd("-i", ImgRoot + Img1) }
            , new object[] { 15, nameof(Item.ImagePath), d.GetItem((item) => item.ImagePath = ImgRoot + Img2), d.GetUpdCmd("--imagePath", ImgRoot + Img2) }
            , new object[] { 16, nameof(Item.Length), d.GetItem((item) => item.Length = 66.6), d.GetUpdCmd("-l", "66.6") }
            , new object[] { 17, nameof(Item.Length), d.GetItem((item) => item.Length = 23.4), d.GetUpdCmd("--length", "23.4") }
            , new object[] { 18, nameof(Item.Heigth), d.GetItem((item) => item.Heigth = 78.3), d.GetUpdCmd("-e", "78.3") }
            , new object[] { 19, nameof(Item.Heigth), d.GetItem((item) => item.Heigth = 45.2), d.GetUpdCmd("--heigth", "45.2") }
            , new object[] { 20, nameof(Item.Depth), d.GetItem((item) => item.Depth = 13.6), d.GetUpdCmd("-t", "13.6") }
            , new object[] { 21, nameof(Item.Depth), d.GetItem((item) => item.Depth = 17.3), d.GetUpdCmd("--depth", "17.3") }
            , new object[] { 22, nameof(Item.Diameter), d.GetItem((item) => item.Diameter = 167.3), d.GetUpdCmd("-a", "167.3") }
            , new object[] { 23, nameof(Item.Diameter), d.GetItem((item) => item.Diameter = 222.2), d.GetUpdCmd("--diameter", "222.2") }
            , new object[] { 24, nameof(Item.Volume), d.GetItem((item) => item.Volume = 31.7), d.GetUpdCmd("-v", "31.7") }
            , new object[] { 25, nameof(Item.Volume), d.GetItem((item) => item.Volume = 41.3), d.GetUpdCmd("--volume", "41.3") }
            , new object[] { 26, nameof(Item.Mass), d.GetItem((item) => item.Mass = 222.9), d.GetUpdCmd("-m", "222.9") }
            , new object[] { 27, nameof(Item.Mass), d.GetItem((item) => item.Mass = 453.2), d.GetUpdCmd("--mass", "453.2") }
            , new object[] { 28, nameof(Item.CategoryId), d.GetItem((item) => item.CategoryId = 1), d.GetUpdCmd("-c", "1") }
            , new object[] { 29, nameof(Item.CategoryId), d.GetItem((item) => item.CategoryId = 2), d.GetUpdCmd("--categoryId", "2") }
            , new object[] { 30, nameof(Item.CurrencyId), d.GetItem((item) => item.CurrencyId = 1), d.GetUpdCmd("-u", "1") }
            , new object[] { 31, nameof(Item.CurrencyId), d.GetItem((item) => item.CurrencyId = 2), d.GetUpdCmd("--currencyId", "2") }
            , new object[] { 32, nameof(Item.LengthUnitId), d.GetItem((item) => item.LengthUnitId = 1), d.GetUpdCmd("--lengthUnitId", "1") }
            , new object[] { 33, nameof(Item.LengthUnitId), d.GetItem((item) => item.LengthUnitId = 2), d.GetUpdCmd("--lengthUnitId", "2") }
            , new object[] { 34, nameof(Item.VolumeUnitId), d.GetItem((item) => item.VolumeUnitId = 1), d.GetUpdCmd("--volumeUnitId", "1") }
            , new object[] { 35, nameof(Item.VolumeUnitId), d.GetItem((item) => item.VolumeUnitId = 2), d.GetUpdCmd("--volumeUnitId", "2") }
            , new object[] { 36, nameof(Item.MassUnitId), d.GetItem((item) => item.MassUnitId = 1), d.GetUpdCmd("-x", "1") }
            , new object[] { 37, nameof(Item.MassUnitId), d.GetItem((item) => item.MassUnitId = 2), d.GetUpdCmd("--massUnitId", "2") }
            , new object[] { 38, nameof(Item.TagId), d.GetItem((item) => item.TagId = 1), d.GetUpdCmd("-z", "1") }
            , new object[] { 39, nameof(Item.TagId), d.GetItem((item) => item.TagId = 2), d.GetUpdCmd("--tagId", "2") }
            , new object[] { 40, nameof(Item.StateId), d.GetItem((item) => item.StateId = 1), d.GetUpdCmd("-g", "1") }
            , new object[] { 41, nameof(Item.StateId), d.GetItem((item) => item.StateId = 2), d.GetUpdCmd("--stateId", "2") }
        };
}