using Xunit;

namespace LibTextbausteine.Test;

public class TestTextbausteineImage
{
    [Theory]
    [InlineData(4517, "zip13/json.zip", "json2//inhalt.json", 2)]

    public void TestsInhalt(int laenge, string jsonZip, string pfadJson, int id)
    {
        var alleTextbausteine = new Textbausteine(jsonZip);
        var listeTextbausteine = new ListeTextbausteine(pfadJson);
        var a = listeTextbausteine.GetTextbaustein(id);

        var html = alleTextbausteine.GetEinHtmlTextbaustein(a);

        Assert.Equal(laenge, html.Length);
    }
}