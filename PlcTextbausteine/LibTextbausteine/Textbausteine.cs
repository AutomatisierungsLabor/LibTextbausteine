using Newtonsoft.Json;
using System.IO.Compression;

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
}
public class Textbausteine
{

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);




    private const string TempJsonFile = "TempTextbausteine.json";
    private readonly EinLehrstoffTextbaustein[] _alletextbausteines;
    private readonly bool _textBausteinOk;



    public Textbausteine(string jsonZip)
    {
        Log.Debug("zip Datei: " + jsonZip);

        try
        {
            var zip = ZipFile.OpenRead(jsonZip);
            var zipEntry = zip.Entries[0];
            if (zipEntry.FullName != "json") return;
            if (File.Exists(TempJsonFile)) File.Delete(TempJsonFile);

            zipEntry.ExtractToFile(TempJsonFile);
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
            temp = JsonConvert.DeserializeObject<RootAlleTextbausteine>(File.ReadAllText(TempJsonFile));
        }
        catch (Exception e)
        {
            Log.Debug("Probleme in der json Datei" + TempJsonFile);
            Console.WriteLine(e);
        }

        if (temp?.AlleTextbausteine == null) return;

        _alletextbausteines = temp.AlleTextbausteine;
        _textBausteinOk = true;
    }

    public EinLehrstoffTextbaustein GetTextbaustein(int id)
    {
        /*
            if (id == 0)
            {
                MessageBox.Show("Textbaustein mit ID=" + id);
                return null;
            }
            if (id > _alletextbausteines.Length)
            {
                MessageBox.Show("Textbaustein mit ID=" + id + " > Länge der Textliste: " + _alletextbausteines.Length);
                return null;
            }

            if (id == _alletextbausteines[id - 1].Id) return _alletextbausteines[id - 1];

            MessageBox.Show("Textbaustein mit falscher ID=" + id + " > Textliste[].id: " + _alletextbausteines[id - 1].Id);
     */
        return null;

    }

    public int GetAnzahlTextbausteine() => _alletextbausteines.Length;
    public bool BausteinOk() => _textBausteinOk;
}