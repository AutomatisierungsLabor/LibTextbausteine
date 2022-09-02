using Xunit;

namespace LibTextbausteine.Test;

public class TestJsonHtml
{
    [Theory]
    [InlineData(1249, "zip11/json.zip", "json1//inhalt.json", 0)]
    [InlineData(1249, "zip11/json.zip", "json2//inhalt.json", 0)]
    [InlineData(4517, "zip11/json.zip", "json2//inhalt.json", 1)]
    [InlineData(1997, "zip11/json.zip", "json2//inhalt.json", 2)]

    public void TestsInhalt(int laenge, string jsonZip, string pfadJson, int id)
    {
        var jsonTextbausteine = new Textbausteine(jsonZip);
        var jsonInhalt = new LibJson.ConfigJson(pfadJson);
        var a = jsonInhalt.GetTextbaustein(id);

        var html = jsonTextbausteine.GetEinHtmlTextbaustein(a);

        Assert.Equal(laenge, html.Length);
    }


    [Theory]
    [InlineData(1249, "zip11/json.zip", "json1//inhalt.json")]
    [InlineData(7781, "zip11/json.zip", "json2//inhalt.json")]

    public void TestsKomplettenInhalt(int laenge, string jsonZip, string pfadJson)
    {

        var jsonTextbausteine = new Textbausteine(jsonZip);
        var jsonInhalt = new LibJson.ConfigJson(pfadJson);
        var a = jsonInhalt.GetAlleTextbaustein();

        var html = jsonTextbausteine.GetAlleHtmlTextbaustein(a);

        Assert.Equal(laenge, html.Length);
    }
}