using Xunit;

namespace LibTextbausteine.Test;

public class TestTextbausteineZipDateiOffnen
{
    [Theory]
    [InlineData(StatusZipDatei.JsonDateiOk, "zip10//json.zip")]
    [InlineData(StatusZipDatei.FalscherDateiname, "zip20//json.zip")]
    [InlineData(StatusZipDatei.FalscheAnzahlDateien, "zip21//json.zip")]

    public void TestsDateiStatus(StatusZipDatei status, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(status, textBaustein.GetStatusZipDatei());
    }


    [Theory]
    [InlineData(StatusZipDatei.JsonDateiLeer, "zip1//json.zip")]
    [InlineData(StatusZipDatei.JsonDateiOk, "zip10//json.zip")]
    [InlineData(StatusZipDatei.JsonDateiOk, "zip11//json.zip")]

    public void TestsKonstruktorStatus(StatusZipDatei status, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(status, textBaustein.GetStatusZipDatei());
    }


    [Theory]
    [InlineData(1, "zip10//json.zip")]
    [InlineData(79, "zip11//json.zip")]

    public void TestsKonstruktorAnzahlDatensaetzte(int anzahl, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(anzahl, textBaustein.GetAnzahlTextbausteine());
    }
}