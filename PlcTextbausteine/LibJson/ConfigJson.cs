using Newtonsoft.Json;

namespace LibJson;

public enum TextbausteineAnzeigen
{
    NurInhalt = 0,
    H1Inhalt = 1,
    H1H2Inhalt = 2,
    H2Inhalt = 3,
    H1H2TestInhalt = 4
}

public class Rootobject
{
    public Textbausteine[] Textbausteine { get; set; }
}

public class Textbausteine
{
    public int BausteinId { get; set; }
    public string PrefixH1 { get; set; }
    public string PrefixH2 { get; set; }
    public int VorbereitungId { get; set; }
    public string Test { get; set; }
    public string Kommentar { get; set; }
    public TextbausteineAnzeigen WasAnzeigen { get; set; }
}


public class ConfigJson
{
    public Rootobject Rootobject { get; set; }
    public bool JsonDateiOk { get; set; }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ConfigJson(string pfad)
    {
        Rootobject = new Rootobject();

        if (File.Exists(pfad))
        {
            try
            {
                Rootobject = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(pfad));
                JsonDateiOk = true;
            }
            catch (Exception e)
            {
                Log.Debug(e);
            }
        }
        else Log.Debug("json Datei fehlt:" + pfad);
    }

    public bool InhaltOk() => JsonDateiOk;
    public int AnzahlEintraege() => Rootobject.Textbausteine.Length;
    public Textbausteine GetTextbaustein(int id) => id <= AnzahlEintraege() ? Rootobject.Textbausteine[id] : new Textbausteine();
    public int GetVorbereitungId(int id) => id <= AnzahlEintraege() ? Rootobject.Textbausteine[id].VorbereitungId : 0;
    public string GetTest(int id) => id <= AnzahlEintraege() ? Rootobject.Textbausteine[id].Test : "-";
    public string GetKommentar(int id) => id <= AnzahlEintraege() ? Rootobject.Textbausteine[id].Kommentar : "-";

    public Textbausteine[] GetAlleTextbaustein() => Rootobject.Textbausteine;
}