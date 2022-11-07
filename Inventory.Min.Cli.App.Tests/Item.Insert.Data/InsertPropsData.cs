using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertPropsData
{
    public static IEnumerable<object[]> InsertProps =>
        new List<object[]>
        {
            new object[]
            {
                0
                , d.GetItem()
                , d.GetInsCmd()
            }
            ,
            new object[]
            {
                1
                , d.GetItem((item) => item.Description = d.Description)
                , d.GetInsCmd("-d", d.Description)
            }
            ,
            new object[]
            {
                2
                , d.GetItem((item) => item.PurchaseDate = new DateTime(2022, 7, 30))
                , d.GetInsCmd("-p", "30.07.2022")
            }
            ,
            new object[]
            {
                3
                , d.GetItem((item) => item.PurchasePrice = 10)
                , d.GetInsCmd("-r", "10")
            }
            ,
            new object[]
            {
                4
                , d.GetItem((item) => item.SellPrice = 5)
                , d.GetInsCmd("-s", "5")
            }
            ,
            new object[]
            {
                5
                , d.GetItem((item) => item.ImagePath =
                    @"C:\atari-monk\Image\Inventory")
                , d.GetInsCmd("-i", @"C:\atari-monk\Image\Inventory")
            }
            ,
            new object[]
            {
                6
                , d.GetItem((item) => item.Length = 99)
                , d.GetInsCmd("-l", "99")
            }
            ,
            new object[]
            {
                7
                , d.GetItem((item) => item.Heigth = 56)
                , d.GetInsCmd("-e", "56")
            }
            ,
            new object[]
            {
                8
                , d.GetItem((item) => item.Depth = 44)
                , d.GetInsCmd("-t", "44")
            }
            ,
            new object[]
            {
                9
                , d.GetItem((item) => item.Diameter = 66)
                , d.GetInsCmd("-a", "66")
            }
            ,
            new object[]
            {
                10
                , d.GetItem((item) => item.Volume = 116)
                , d.GetInsCmd("-v", "116")
            }
            ,
            new object[]
            {
                11
                , d.GetItem((item) => item.InitialCount = 66)
                , d.GetInsCmd("-q", "66")
            }
            ,
             new object[]
            {
                12
                , d.GetItem((item) => item.CurrentCount = 62)
                , d.GetInsCmd("--currentCount", "62")
            }
            ,
            new object[]
            {
                13
                , d.GetItem((item) => item.Mass = 400)
                , d.GetInsCmd("-m", "400")
            }
        };
}
