using LibListeTextbausteine;
using Xunit;

namespace LibTextbausteine.Test;

public class TestListeTextbausteineDatei
{
    [Theory]
    [InlineData(true, "json1//inhalt.json")]
    [InlineData(true, "json2//inhalt.json")]

    public void TestsKonstruktorOk(bool ok, string pfad)
    {
        var json = new ListeTextbausteine(pfad);
        Assert.Equal(ok, json.InhaltOk());
    }


    [Theory]
    [InlineData(1, "json1//inhalt.json")]
    [InlineData(4, "json2//inhalt.json")]

    public void TestsAnzahlEintraege(int anzahl, string pfad)
    {
        var json = new ListeTextbausteine(pfad);
        Assert.Equal(anzahl, json.AnzahlEintraege());
    }
}