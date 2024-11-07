using Newtonsoft.Json;

namespace LibTextbausteine;

public class ListeTextbausteine
{
    private RootobjectListeTextbausteine? Rootobject { get; }
    private bool JsonDateiOk { get; }

    public ListeTextbausteine(string? pfad)
    {
        Rootobject = new RootobjectListeTextbausteine();
        
        if (pfad is null) { return; }
        if (Rootobject is null) { return; }

        if (File.Exists(pfad))
        {
            try
            {
                Rootobject = JsonConvert.DeserializeObject<RootobjectListeTextbausteine>(File.ReadAllText(pfad));
                JsonDateiOk = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else Console.WriteLine("json Datei fehlt:" + pfad);
    }

    public bool InhaltOk() => JsonDateiOk;
    public int AnzahlEintraege() => Rootobject!.ListeTextbausteineEintrag!.Length;

    public ListeTextbausteinEintrag GetTextbaustein(int id) => id <= AnzahlEintraege()
        ? Rootobject?.ListeTextbausteineEintrag?[id]!
        : new ListeTextbausteinEintrag();

    public int GetVorbereitungId(int id) =>
        id <= AnzahlEintraege() ? Rootobject!.ListeTextbausteineEintrag![id].VorbereitungId : 0;

    public string GetTest(int id) => id <= AnzahlEintraege() ? Rootobject!.ListeTextbausteineEintrag![id].Test! : "-";

    public string GetKommentar(int id) =>
        id <= AnzahlEintraege() ? Rootobject!.ListeTextbausteineEintrag![id].Kommentar! : "-";

    public ListeTextbausteinEintrag[] GetAlleTextbaustein() => Rootobject!.ListeTextbausteineEintrag!;
}