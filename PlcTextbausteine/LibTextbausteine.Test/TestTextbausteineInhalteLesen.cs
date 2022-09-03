using Xunit;

namespace LibTextbausteine.Test;

public class TestTextbausteineInhalteLesen
{
    [Theory]
    [InlineData("-", 0, "zip10//json.zip")]
    [InlineData("Siemens - Linearachse - Hardware", 1, "zip10//json.zip")]
    [InlineData("Siemens - Linearachse - Hardware", 1, "zip11//json.zip")]

    public void TestsBezeichnungLesen(string bez, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(bez, textBaustein.GetBezeichnung(id));
    }

    [Theory]
    [InlineData("-", 0, "zip10//json.zip")]
    [InlineData("S7-1200 - Linearachse", 1, "zip10//json.zip")]
    [InlineData("S7-1200 - Linearachse", 1, "zip11//json.zip")]

    public void TestsUeberschriftH1Lesen(string bez, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(bez, textBaustein.GetUeberschriftH1(id));
    }

    [Theory]
    [InlineData("-", 0, "zip10//json.zip")]
    [InlineData("Hardware", 1, "zip10//json.zip")]
    [InlineData("Hardware", 1, "zip11//json.zip")]

    public void TestsUnterUeberschriftH2Lesen(string bez, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(bez, textBaustein.GetUnterUeberschriftH2(id));
    }

    [Theory]
    [InlineData("<h1 class=\"li\">Hardware</h1>", 1, "zip10//json.zip")]
    [InlineData("<h1 class=\"li\">Hardware</h1>", 1, "zip11//json.zip")]

    public void TestsInhaltLesen(string bez, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(bez, textBaustein.GetInhalt(id)[..28]);
    }
}