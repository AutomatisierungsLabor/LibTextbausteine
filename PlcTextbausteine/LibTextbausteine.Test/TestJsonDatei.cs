using Xunit;

namespace LibTextbausteine.Test;

public class TestZJsonDatei
{
    [Theory]
    [InlineData(true, "json1//inhalt.json")]
    [InlineData(true, "json2//inhalt.json")]

    public void TestsKonstruktorOk(bool ok, string pfad)
    {
        var json = new LibJson.ConfigJson(pfad);
        Assert.Equal(ok, json.InhaltOk());
    }


    [Theory]
    [InlineData(1, "json1//inhalt.json")]
    [InlineData(4, "json2//inhalt.json")]

    public void TestsAnzahlEintraege(int anzahl, string pfad)
    {
        var json = new LibJson.ConfigJson(pfad);
        Assert.Equal(anzahl, json.AnzahlEintraege());
    }
}