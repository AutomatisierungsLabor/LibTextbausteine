using Xunit;

namespace LibTextbausteine.Test;

public class TestTextbausteineLesen
{
    [Theory]
    [InlineData(null, 0, "zip10//json.zip")]
 //   [InlineData("Siemens - Linearachse - Hardware", 1, "zip10//json.zip")]
  //  [InlineData("Siemens - Linearachse - Hardware", 1, "zip11//json.zip")]

    public void TestsTextbausteineLesen(Textbausteine tb, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);
       // Assert.Equal(tb, textBaustein.GetTextbaustein(id));
    }
}