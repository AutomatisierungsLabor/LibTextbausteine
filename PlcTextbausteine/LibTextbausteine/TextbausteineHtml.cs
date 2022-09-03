using System.Text;

namespace LibTextbausteine;

public partial class Textbausteine
{
    public string GetEinHtmlTextbaustein(Contracts.ListeTextbausteinEintrag einTextbausteineEintrag)
    {
        var html = new StringBuilder();

        switch (einTextbausteineEintrag.WasAnzeigen)
        {
            case Contracts.TextbausteinAnzeigen.NurInhalt:
                html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
                break;

            case Contracts.TextbausteinAnzeigen.H1Inhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
                break;

            case Contracts.TextbausteinAnzeigen.H1H2Inhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
                break;

            case Contracts.TextbausteinAnzeigen.H2Inhalt:
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
                break;

            case Contracts.TextbausteinAnzeigen.H1H2TestInhalt:
                html.Append("<H1>" + einTextbausteineEintrag.PrefixH1 + GetUeberschriftH1(einTextbausteineEintrag.BausteinId) + "</H1>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetUnterUeberschriftH2(einTextbausteineEintrag.BausteinId) + "</H2>");
                html.Append("<H2>" + einTextbausteineEintrag.PrefixH2 + GetTest(einTextbausteineEintrag.BausteinId) + "</H2>");
                html.Append(GetInhalt(einTextbausteineEintrag.BausteinId));
                break;
            default:
                throw new NotImplementedException(nameof(einTextbausteineEintrag.WasAnzeigen));
        }

        return html.ToString();
    }
    public string GetAlleHtmlTextbaustein(Contracts.ListeTextbausteinEintrag[] alletextbausteinEintraege)
    {
        var html = new StringBuilder();

        foreach (var einTextbausteineEintrag in alletextbausteinEintraege) html.Append(GetEinHtmlTextbaustein(einTextbausteineEintrag));

        return html.ToString();
    }
}