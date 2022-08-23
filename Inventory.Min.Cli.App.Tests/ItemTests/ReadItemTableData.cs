using System.Globalization;
using Inventory.Min.BetterTable;
using Inventory.Min.Data;
using ModelHelper;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class ReadItemTableData
    : ReadMyItemTableData
{
    private const int Quantity = 1;
    //private const int CategoryId = 1;
    private const string PurchaseDate = "22.08.2022";
    private const decimal PurchasePrice = 45.56m;
    private const decimal SellPrice = 13.32m;
    //private const string ImagePath = @"C:\kmazanek.gmail.com\Image\Inventory\test.png";
    //private const int LengthUnitId = 1;
    private const double Length = 65.1;
    private const double Heigth = 34.6;
    private const double Depth = 12.3;
    private const double Diameter =5.6;
    //private const int VolumeUnitId = 1;
    private const double Volume = 33.4;
    private const double Mass = 2.7;
    //private const int MassUnitId = 1;
    //private const int TagId = 1;
    //private const int StateId = 1;

    // public new static IEnumerable<object[]> Insert01 =>
    //     new List<object[]>
    //     {
    //         new object[]
    //         {
    //             0
    //             , GetItem((item) => item.Description = "test self ref") 
    //             , GetInsCmd("-d", "test self ref")
    //         }
    //     };

    public new static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetItem(
                    (item) => item.Description = Description
                    , (item) => item.Quantity = Quantity
                    //, (item) => item.CategoryId = CategoryId
                    , (item) => item.PurchaseDate = new DateTime(2022, 8, 22)
                    , (item) => item.PurchasePrice = PurchasePrice
                    , (item) => item.SellPrice = SellPrice
                    //, (item) => item.ImagePath = ImagePath
                    //, (item) => item.LengthUnitId = LengthUnitId
                    , (item) => item.Length = Length
                    , (item) => item.Heigth = Heigth
                    , (item) => item.Depth = Depth
                    , (item) => item.Diameter = Diameter
                    //, (item) => item.VolumeUnitId = VolumeUnitId
                    , (item) => item.Volume = Volume
                    , (item) => item.Mass = Mass
                    //, (item) => item.MassUnitId = MassUnitId
                    //, (item) => item.TagId = TagId
                    //, (item) => item.StateId = StateId
                ) 
                , GetInsCmd("-d", Description, "-q", Quantity.ToString()
                    //, "-c", CategoryId.ToString()
                    , "-p", PurchaseDate
                    , "-u", PurchasePrice.ToString(), "-s", SellPrice.ToString()
                    //, "-i", ImagePath
                    //, "--lengthUnitId", LengthUnitId.ToString()
                    , "-l", Length.ToString(), "-e", Heigth.ToString()
                    , "--depth", Depth.ToString(), "--diameter", Diameter.ToString()
                    //"--volumeUnitId", VolumeUnitId.ToString()
                    , "--volume", Volume.ToString(), "--mass", Mass.ToString()
                    //, "--massUnitId", MassUnitId.ToString()
                    //, "-t", TagId.ToString()
                    //, "-a", StateId.ToString()
                    //, "-r", "parentid"
                    )
            }
        };

    public new static IEnumerable<object[]> Read01 =>
        new List<object[]>
        {
            new object[] 
            {
                0
                , GetReadCmd("-t", nameof(ItemTable))
                ,    "┌{idcol}┬──────────────────┬──────────────────────────┬──────────┬──────────────┬───────────────┬───────────┬────────┬────────┬───────┬──────────┬────────┬──────┐\r\n"
                +   $"│ \u001b[38;2;255;255;255m {nameof(Item.Id)} \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m      {nameof(Item.Name)}      \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m       {nameof(Item.Description)}      [0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Quantity)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.CategoryId)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.PurchaseDate)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.PurchasePrice)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.SellPrice)}[0m │"
                //+   $" [38;2;255;255;255m                   {nameof(Item.ImagePath)}                  [0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.LengthUnitId)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Length)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Heigth)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Depth)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Diameter)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.VolumeUnitId)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Volume)}[0m │"
                +   $" [38;2;255;255;255m{nameof(Item.Mass)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.MassUnitId)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.TagId)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.StateId)}[0m │"
                //+   $" [38;2;255;255;255m{nameof(Item.ParentId)}[0m │"
                +    "\r\n"
                +    "├{idcol}┼──────────────────┼──────────────────────────┼──────────┼──────────────┼───────────────┼───────────┼────────┼────────┼───────┼──────────┼────────┼──────┤\r\n"
                +   $"│ \u001b[38;2;255;255;255m{{id}}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{Description}[0m │"
                +   $" [38;2;255;255;255m    {Quantity}   [0m │"
                //+   $" [38;2;255;255;255m     {CategoryId}    [0m │"
                +   $" [38;2;255;255;255m {PurchaseDate} [0m │"
                +   $" [38;2;255;255;255m   {GetPrice(PurchasePrice)}  [0m │"
                +   $" [38;2;255;255;255m {GetPrice(SellPrice)}[0m │"
                //+   $" [38;2;255;255;255m{ImagePath}[0m │"
                //+   $" [38;2;255;255;255m      {LengthUnitId}     [0m │"
                +   $" [38;2;255;255;255m {Length} [0m │"
                +   $" [38;2;255;255;255m {Heigth} [0m │"
                +   $" [38;2;255;255;255m {Depth}[0m │"
                +   $" [38;2;255;255;255m   {Diameter}  [0m │"
                //+   $" [38;2;255;255;255m      {VolumeUnitId}     [0m │"
                +   $" [38;2;255;255;255m {Volume} [0m │"
                +   $" [38;2;255;255;255m {Mass}[0m │"
                //+   $" [38;2;255;255;255m     {MassUnitId}    [0m │"
                //+   $" [38;2;255;255;255m  {TagId}  [0m │"
                //+   $" [38;2;255;255;255m   {StateId}   [0m │"
                //+   $" [38;2;255;255;255m   {{parentid}}   [0m │"
                +    "\r\n"
                +    "└{idcol}┴──────────────────┴──────────────────────────┴──────────┴──────────────┴───────────────┴───────────┴────────┴────────┴───────┴──────────┴────────┴──────┘\r\n"
            }
        };

    private static object GetPrice(decimal purchasePrice)
    {
        return purchasePrice.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture));
    }
}