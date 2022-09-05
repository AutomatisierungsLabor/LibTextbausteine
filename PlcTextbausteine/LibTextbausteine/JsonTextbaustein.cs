namespace LibTextbausteine;

public class RootAlleTextbausteine
{
    public EinLehrstoffTextbaustein[] AlleTextbausteine { get; set; }
}

public class EinLehrstoffTextbaustein
{
    public int Id { get; set; }
    public string Bezeichnung { get; set; }
    public string UeberschriftH1 { get; set; }
    public string UnterUeberschriftH2 { get; set; }
    public string Inhalt { get; set; }
    public string Test { get; set; }
}