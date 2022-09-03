using LibListeTextbausteine;
using Xunit;

namespace LibTextbausteine.Test;

public class TestListeTextbausteinHtml
{
    [Theory]
    [InlineData(1249, "zip11/json.zip", "json1//inhalt.json", 0)]
    [InlineData(1249, "zip11/json.zip", "json2//inhalt.json", 0)]
    [InlineData(4517, "zip11/json.zip", "json2//inhalt.json", 1)]
    [InlineData(1997, "zip11/json.zip", "json2//inhalt.json", 2)]

    public void TestsInhalt(int laenge, string jsonZip, string pfadJson, int id)
    {
        var alleTextbausteine = new Textbausteine(jsonZip);
        var listeTextbausteine = new ListeTextbausteine(pfadJson);
        var a = listeTextbausteine.GetTextbaustein(id);

        var html = alleTextbausteine.GetEinHtmlTextbaustein(a);

        Assert.Equal(laenge, html.Length);
    }


    [Theory]
    [InlineData(1249, "zip11/json.zip", "json1//inhalt.json")]
    [InlineData(7781, "zip11/json.zip", "json2//inhalt.json")]

    public void TestsKomplettenInhalt(int laenge, string jsonZip, string pfadJson)
    {

        var alleTextbausteine = new Textbausteine(jsonZip);
        var listeTextbausteine = new ListeTextbausteine(pfadJson);
        var a = listeTextbausteine.GetAlleTextbaustein();

        var html = alleTextbausteine.GetAlleHtmlTextbaustein(a);

        Assert.Equal(laenge, html.Length);
    }
}