using Inventory.Min.Data;
using u = Inventory.Min.Cli.App.Tests.ItemTests.Util;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateData
{
    private const string ImgRoot = @"C:\kmazanek.gmail.com\Image\Inventory";
    private const string Img1 = @"\img1.png";
    private const string Img2 = @"\img2.png";

    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { 0, u.GetInsCmd() }
        };

    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
              new object[] { 0, nameof(Item.Name), u.GetItem((item) => item.Name = u.NameUpd), u.GetUpdCmd("-n", u.NameUpd) }
            , new object[] { 1, nameof(Item.Name), u.GetItem((item) => item.Name = u.Name) , u.GetUpdCmd("--name", u.Name) }
            , new object[] { 2, nameof(Item.Description), u.GetItem((item) => item.Description = u.Description), u.GetUpdCmd("-d", u.Description) }
            , new object[] { 3, nameof(Item.Description), u.GetItem((item) => item.Description = u.DescriptionUpd), u.GetUpdCmd("--desc", u.DescriptionUpd) } 
            , new object[] { 4, nameof(Item.InitialCount), u.GetItem((item) => item.InitialCount = 10), u.GetUpdCmd("-q", "10") }
            , new object[] { 5, nameof(Item.InitialCount), u.GetItem((item) => item.InitialCount = 20), u.GetUpdCmd("--initialCount", "20") }
            , new object[] { 6, nameof(Item.CurrentCount), u.GetItem((item) => item.CurrentCount = 40), u.GetUpdCmd("--currentCount", "40") }
            , new object[] { 7, nameof(Item.CurrentCount), u.GetItem((item) => item.CurrentCount = 33), u.GetUpdCmd("--currentCount", "33") }
            , new object[] { 8, nameof(Item.PurchaseDate), u.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 17, 16, 0)), u.GetUpdCmd("-p", "18.08.2022 17:16") }
            , new object[] { 9, nameof(Item.PurchaseDate), u.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)), u.GetUpdCmd("-p", "18.08.2022 18:00") }
            , new object[] { 10, nameof(Item.PurchasePrice), u.GetItem((item) => item.PurchasePrice = 33.3m), u.GetUpdCmd("-r", "33.3") }
            , new object[] { 11, nameof(Item.PurchasePrice), u.GetItem((item) => item.PurchasePrice = 99.6m), u.GetUpdCmd("--purchasePrice", "99.6") }
            , new object[] { 12, nameof(Item.SellPrice), u.GetItem((item) => item.SellPrice = 15.7m), u.GetUpdCmd("-s", "15.7") }
            , new object[] { 13, nameof(Item.SellPrice), u.GetItem((item) => item.SellPrice = 78.1m), u.GetUpdCmd("--sellPrice", "78.1") }
            , new object[] { 14, nameof(Item.ImagePath), u.GetItem((item) => item.ImagePath = ImgRoot + Img1), u.GetUpdCmd("-i", ImgRoot + Img1) }
            , new object[] { 15, nameof(Item.ImagePath), u.GetItem((item) => item.ImagePath = ImgRoot + Img2), u.GetUpdCmd("--imagePath", ImgRoot + Img2) }
            , new object[] { 16, nameof(Item.Length), u.GetItem((item) => item.Length = 66.6), u.GetUpdCmd("-e", "66.6") }
            , new object[] { 17, nameof(Item.Length), u.GetItem((item) => item.Length = 23.4), u.GetUpdCmd("--length", "23.4") }
            , new object[] { 18, nameof(Item.Heigth), u.GetItem((item) => item.Heigth = 78.3), u.GetUpdCmd("-g", "78.3") }
            , new object[] { 19, nameof(Item.Heigth), u.GetItem((item) => item.Heigth = 45.2), u.GetUpdCmd("--heigth", "45.2") }
            , new object[] { 20, nameof(Item.Depth), u.GetItem((item) => item.Depth = 13.6), u.GetUpdCmd("-t", "13.6") }
            , new object[] { 21, nameof(Item.Depth), u.GetItem((item) => item.Depth = 17.3), u.GetUpdCmd("--depth", "17.3") }
            , new object[] { 22, nameof(Item.Diameter), u.GetItem((item) => item.Diameter = 167.3), u.GetUpdCmd("-a", "167.3") }
            , new object[] { 23, nameof(Item.Diameter), u.GetItem((item) => item.Diameter = 222.2), u.GetUpdCmd("--diameter", "222.2") }
            , new object[] { 24, nameof(Item.Volume), u.GetItem((item) => item.Volume = 31.7), u.GetUpdCmd("-o", "31.7") }
            , new object[] { 25, nameof(Item.Volume), u.GetItem((item) => item.Volume = 41.3), u.GetUpdCmd("--volume", "41.3") }
            , new object[] { 26, nameof(Item.Mass), u.GetItem((item) => item.Mass = 222.9), u.GetUpdCmd("-m", "222.9") }
            , new object[] { 27, nameof(Item.Mass), u.GetItem((item) => item.Mass = 453.2), u.GetUpdCmd("--mass", "453.2") }
            , new object[] { 28, nameof(Item.CategoryId), u.GetItem((item) => item.CategoryId = 1), u.GetUpdCmd("-c", "1") }
            , new object[] { 29, nameof(Item.CategoryId), u.GetItem((item) => item.CategoryId = 2), u.GetUpdCmd("--categoryId", "2") }
            , new object[] { 30, nameof(Item.CurrencyId), u.GetItem((item) => item.CurrencyId = 1), u.GetUpdCmd("-u", "1") }
            , new object[] { 31, nameof(Item.CurrencyId), u.GetItem((item) => item.CurrencyId = 2), u.GetUpdCmd("--currencyId", "2") }
            , new object[] { 32, nameof(Item.LengthUnitId), u.GetItem((item) => item.LengthUnitId = 1), u.GetUpdCmd("-l", "1") }
            , new object[] { 33, nameof(Item.LengthUnitId), u.GetItem((item) => item.LengthUnitId = 2), u.GetUpdCmd("--lengthUnitId", "2") }
            , new object[] { 34, nameof(Item.VolumeUnitId), u.GetItem((item) => item.VolumeUnitId = 1), u.GetUpdCmd("-v", "1") }
            , new object[] { 35, nameof(Item.VolumeUnitId), u.GetItem((item) => item.VolumeUnitId = 2), u.GetUpdCmd("--volumeUnitId", "2") }
            , new object[] { 36, nameof(Item.MassUnitId), u.GetItem((item) => item.MassUnitId = 1), u.GetUpdCmd("-x", "1") }
            , new object[] { 37, nameof(Item.MassUnitId), u.GetItem((item) => item.MassUnitId = 2), u.GetUpdCmd("--massUnitId", "2") }
            , new object[] { 38, nameof(Item.TagId), u.GetItem((item) => item.TagId = 1), u.GetUpdCmd("-z", "1") }
            , new object[] { 39, nameof(Item.TagId), u.GetItem((item) => item.TagId = 2), u.GetUpdCmd("--tagId", "2") }
            , new object[] { 40, nameof(Item.StateId), u.GetItem((item) => item.StateId = 1), u.GetUpdCmd("-b", "1") }
            , new object[] { 41, nameof(Item.StateId), u.GetItem((item) => item.StateId = 2), u.GetUpdCmd("--stateId", "2") }
        };
}