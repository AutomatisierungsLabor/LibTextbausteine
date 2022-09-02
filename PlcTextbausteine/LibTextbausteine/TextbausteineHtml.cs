using System.Text;
using LibJson;

namespace LibTextbausteine;

public partial class Textbausteine
{
    public string GetEinHtmlTextbaustein(LibJson.Textbausteine textbausteine)
    {
        var html = new StringBuilder();

        switch (textbausteine.WasAnzeigen)
        {
            case TextbausteineAnzeigen.NurInhalt:
                html.Append(GetInhalt(textbausteine.BausteinId));
                break;

            case TextbausteineAnzeigen.H1Inhalt:
                html.Append("<H1>" + textbausteine.PrefixH1 + GetUeberschriftH1(textbausteine.BausteinId) + "</H1>");
                html.Append(GetInhalt(textbausteine.BausteinId));
                break;

            case TextbausteineAnzeigen.H1H2Inhalt:
                html.Append("<H1>" + textbausteine.PrefixH1 + GetUeberschriftH1(textbausteine.BausteinId) + "</H1>");
                html.Append("<H2>" + textbausteine.PrefixH2 + GetUnterUeberschriftH2(textbausteine.BausteinId) + "</H2>");
                html.Append(GetInhalt(textbausteine.BausteinId));
                break;

            case TextbausteineAnzeigen.H2Inhalt:
                html.Append("<H2>" + textbausteine.PrefixH2 + GetUnterUeberschriftH2(textbausteine.BausteinId) + "</H2>");
                html.Append(GetInhalt(textbausteine.BausteinId));
                break;

            case TextbausteineAnzeigen.H1H2TestInhalt:
                html.Append("<H1>" + textbausteine.PrefixH1 + GetUeberschriftH1(textbausteine.BausteinId) + "</H1>");
                html.Append("<H2>" + textbausteine.PrefixH2 + GetUnterUeberschriftH2(textbausteine.BausteinId) + "</H2>");
                html.Append("<H2>" + textbausteine.PrefixH2 + GetTest(textbausteine.BausteinId) + "</H2>");
                html.Append(GetInhalt(textbausteine.BausteinId));
                break;
            default:
                throw new NotImplementedException(nameof(textbausteine.WasAnzeigen));
        }

        return html.ToString();
    }
    public string GetAlleHtmlTextbaustein(LibJson.Textbausteine[] alletextbausteine)
    {
        var html = new StringBuilder();
        
        foreach (var textbaustein in alletextbausteine) html.Append(GetEinHtmlTextbaustein(textbaustein));
      

        return html.ToString();
    }
}