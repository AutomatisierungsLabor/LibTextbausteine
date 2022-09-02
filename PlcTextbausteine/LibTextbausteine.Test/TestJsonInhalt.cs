using Xunit;

namespace LibTextbausteine.Test;

public class TestJsonInhalt
{
    [Theory]
    [InlineData(5, "json1//inhalt.json", 0)]
    [InlineData(20, "json2//inhalt.json", 1)]

    public void TestsInhalt(int textbausteinId, string pfad, int id)
    {
        var json = new LibJson.ConfigJson(pfad);
        var a = json.GetTextbaustein(id);
        Assert.Equal(textbausteinId, a.BausteinId);
    }

    [Theory]
    [InlineData("Html - Head", "json1//inhalt.json", 0)]
    [InlineData("Hardware", "json2//inhalt.json", 1)]

    public void TestsKommentar(string kommentar, string pfad, int id)
    {
        var json = new LibJson.ConfigJson(pfad);
        Assert.Equal(kommentar, json.GetKommentar(id));
    }
    
    [Theory]
    [InlineData("-", "json1//inhalt.json", 0)]
    [InlineData("-", "json2//inhalt.json", 1)]
    public void TestsTests(string tests, string pfad, int id)
    {
        var json = new LibJson.ConfigJson(pfad);
        Assert.Equal(tests, json.GetTest(id));
    }
    
    [Theory]
    [InlineData(0, "json1//inhalt.json", 0)]
    [InlineData(0, "json2//inhalt.json", 1)]
    public void TestsVorbereitungId(int vorbereitungId, string pfad, int id)
    {
        var json = new LibJson.ConfigJson(pfad);
        Assert.Equal(vorbereitungId, json.GetVorbereitungId(id));
    }
}