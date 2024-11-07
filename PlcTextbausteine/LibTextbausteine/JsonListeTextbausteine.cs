// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace LibTextbausteine;

public enum TextbausteinAnzeigen
{
    NurInhalt = 0,
    H1Inhalt = 1,
    H1H2Inhalt = 2,
    H2Inhalt = 3,
    H1H2TestInhalt = 4
}

public class RootobjectListeTextbausteine
{
    public ListeTextbausteinEintrag[]? ListeTextbausteineEintrag { get; set; }
}

public class ListeTextbausteinEintrag
{
    public int BausteinId { get; set; }
    public string? PrefixH1 { get; set; }
    public string? PrefixH2 { get; set; }
    public int VorbereitungId { get; set; }
    public string? Test { get; set; }
    public string? Kommentar { get; set; }
    public TextbausteinAnzeigen WasAnzeigen { get; set; }
}