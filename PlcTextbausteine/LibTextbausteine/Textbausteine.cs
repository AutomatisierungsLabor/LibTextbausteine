using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;

namespace LibTextbausteine;



public partial class Textbausteine
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly EinLehrstoffTextbaustein[] _alletextbausteines;
    private readonly bool _textBausteinOk;
    

    public Textbausteine(string jsonZip)
    {
        Log.Debug("zip Datei: " + jsonZip);

        var tempFile = Path.GetRandomFileName();

        try
        {
            var zip = ZipFile.OpenRead(jsonZip);
            var zipEntry = zip.Entries[0];
            if (zipEntry.FullName != "json") return;



            if (File.Exists(tempFile)) File.Delete(tempFile);

            zipEntry.ExtractToFile(tempFile);
        }
        catch (Exception e)
        {
            Log.Debug(e.ToString());
            Console.WriteLine(e);
            throw;
        }

        var temp = new RootAlleTextbausteine();

        try
        {
            temp = JsonConvert.DeserializeObject<RootAlleTextbausteine>(File.ReadAllText(tempFile));
        }
        catch (Exception e)
        {
            Log.Debug("Probleme in der json Datei" + tempFile);
            Console.WriteLine(e);
        }

        if (temp?.AlleTextbausteine == null) return;

        _alletextbausteines = temp.AlleTextbausteine;

        _textBausteinOk = true;
        var id = 0;

        foreach (var textbaustein in _alletextbausteines)
        {
            if (id + 1 != textbaustein.Id) _textBausteinOk = false;
            id++;
        }
    }
    public int GetAnzahlTextbausteine() => _alletextbausteines.Length;
    public bool BausteinOk() => _textBausteinOk;
    public bool IsIdVorhanden(int id)
    {
        if (id == 0) return false;
        return id <= _alletextbausteines.Length;
    }
    public string GetBezeichnung(int id) => IsIdVorhanden(id) ? _alletextbausteines[id - 1].Bezeichnung : "-";
    public string GetUeberschriftH1(int id) => IsIdVorhanden(id) ? _alletextbausteines[id - 1].UeberschriftH1 : "-";
    public string GetUnterUeberschriftH2(int id) => IsIdVorhanden(id) ? _alletextbausteines[id - 1].UnterUeberschriftH2 : "-";
    public string GetInhalt(int id) => IsIdVorhanden(id) ? Encoding.UTF8.GetString(Convert.FromBase64String(_alletextbausteines[id - 1].Inhalt)) : "-";
    private string GetTest(int id) => IsIdVorhanden(id) ? _alletextbausteines[id - 1].Test : "-";
}