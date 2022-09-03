using Xunit;

namespace LibTextbausteine.Test;

public class TestTextbausteineIdLesen
{
    [Theory]
    [InlineData(false, 0, "zip10//json.zip")]
    [InlineData(true, 1, "zip10//json.zip")]
    [InlineData(false, 10, "zip10//json.zip")]
    [InlineData(true, 10, "zip11//json.zip")]

    public void TestsIdLesen(bool ok, int id, string pfad)
    {
        var textBaustein = new Textbausteine(pfad);

        Assert.Equal(ok, textBaustein.IsIdVorhanden(id));
    }
}