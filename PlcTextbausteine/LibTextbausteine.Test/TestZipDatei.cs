using Xunit;

namespace LibTextbausteine.Test;

public class TestZipDateiOffnen
{
    [Theory]
    [InlineData(false, "zip1//json.zip")]
    [InlineData(true, "zip10//json.zip")]
    [InlineData(true, "zip11//json.zip")]
    
    public void TestsKonstruktorOk(bool ok, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
        Assert.Equal(ok, textBaustein.BausteinOk());
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