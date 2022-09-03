using Contracts;
using Newtonsoft.Json;

namespace LibListeTextbausteine;


public class ListeTextbausteine
{
    public RootobjectListeTextbausteine Rootobject { get; set; }
    public bool JsonDateiOk { get; set; }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ListeTextbausteine(string pfad)
    {
        Rootobject = new RootobjectListeTextbausteine();

        if (File.Exists(pfad))
        {
            try
            {
                Rootobject = JsonConvert.DeserializeObject<RootobjectListeTextbausteine>(File.ReadAllText(pfad));
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
    public int AnzahlEintraege() => Rootobject.ListeTextbausteineEintrag.Length;
    public ListeTextbausteinEintrag GetTextbaustein(int id) => id <= AnzahlEintraege() ? Rootobject.ListeTextbausteineEintrag[id] : new ListeTextbausteinEintrag();
    public int GetVorbereitungId(int id) => id <= AnzahlEintraege() ? Rootobject.ListeTextbausteineEintrag[id].VorbereitungId : 0;
    public string GetTest(int id) => id <= AnzahlEintraege() ? Rootobject.ListeTextbausteineEintrag[id].Test : "-";
    public string GetKommentar(int id) => id <= AnzahlEintraege() ? Rootobject.ListeTextbausteineEintrag[id].Kommentar : "-";

    public ListeTextbausteinEintrag[] GetAlleTextbaustein() => Rootobject.ListeTextbausteineEintrag;
}