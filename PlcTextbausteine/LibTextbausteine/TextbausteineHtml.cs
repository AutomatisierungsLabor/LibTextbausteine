using System.Text;

namespace LibTextbausteine;

public partial class Textbausteine
{
    public string GetEinHtmlTextbaustein(ListeTextbausteinEintrag einTextbausteineEintrag)
    {
        var html = new StringBuilder();

        switch (einTextbausteineEintrag.WasAnzeigen)
        {
            case TextbausteinAnzeigen.NurInhalt:
                break;

            case TextbausteinAnzeigen.H1Inhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                break;

            case TextbausteinAnzeigen.H1H2Inhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                break;

            case TextbausteinAnzeigen.H2Inhalt:
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                break;

            case TextbausteinAnzeigen.H1H2TestInhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetTest(einTextbausteineEintrag.BausteinId) + "</H2>");
                break;
            default:
                throw new NotImplementedException(nameof(einTextbausteineEintrag.WasAnzeigen));
        }

        html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
        return html.ToString();
    }
    public string GetAlleHtmlTextbaustein(ListeTextbausteinEintrag[] alletextbausteinEintraege)
    {
        var html = new StringBuilder();
        foreach (var einTextbausteineEintrag in alletextbausteinEintraege) html.Append(GetEinHtmlTextbaustein(einTextbausteineEintrag));
        return html.ToString();
    }
}