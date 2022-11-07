using d = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertForeignKeysData
{
    public static IEnumerable<object[]> InsertForeignKeys =>
        new List<object[]>
        {
            new object[]
            {
                0
                , d.GetItem((item) => item.CategoryId = 1)
                , d.GetInsCmd("-c", "1")
            }
            ,
            new object[]
            {
                1
                , d.GetItem((item) => item.CurrencyId = 1)
                , d.GetInsCmd("--currencyId", "1")
            }
            ,
            new object[]
            {
                2
                , d.GetItem((item) => item.LengthUnitId = 1)
                , d.GetInsCmd("--lengthUnitId", "1")
            }
            ,
            new object[]
            {
                3
                , d.GetItem((item) => item.VolumeUnitId = 4)
                , d.GetInsCmd("--volumeUnitId", "4")
            }
            ,
            new object[]
            {
                4
                , d.GetItem((item) => item.TagId = 1)
                , d.GetInsCmd("-z", "1")
            }
            ,
            new object[]
            {
                5
                , d.GetItem((item) => item.StateId = 1)
                , d.GetInsCmd("-g", "1")
            }
            ,
            new object[]
            {
                6
                , d.GetItem((item) => item.MassUnitId = 5)
                , d.GetInsCmd("-x", "5")
            }
        };
}