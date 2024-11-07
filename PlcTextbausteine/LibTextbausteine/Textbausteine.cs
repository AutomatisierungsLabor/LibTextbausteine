using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;

namespace LibTextbausteine;

public enum StatusZipDatei
{
    Unbekannt = 0,
    FalscheAnzahlDateien,
    FalscherDateiname,
    JsonDateiOk,
    JsonDateiLeer,
    JsonEintraegeFalsch
}

public partial class Textbausteine
{
    private readonly EinLehrstoffTextbaustein[]? _alletextbausteines;
    private readonly StatusZipDatei? _statusZipDatei;

    public Textbausteine(string? jsonZip)
    {
        if (jsonZip is null) { return; }

        var memoryStream = new MemoryStream();

        _statusZipDatei = StatusZipDatei.Unbekannt;
        try
        {
            var zipArchive = ZipFile.OpenRead(jsonZip);

            ZipFile.OpenRead(jsonZip);


            if (zipArchive.Entries.Count != 1)
            {
                _statusZipDatei = StatusZipDatei.FalscheAnzahlDateien;
                return;
            }

            var zipEntry = zipArchive.Entries[0];
            if (zipEntry.FullName != "json")
            {
                _statusZipDatei = StatusZipDatei.FalscherDateiname;
                return;
            }

            var unzippedMemoryStream = zipEntry.Open();
            unzippedMemoryStream.CopyTo(memoryStream);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        memoryStream.Seek(0, SeekOrigin.Begin);
        var streamReader = new StreamReader(memoryStream);
        var jsonString = streamReader.ReadToEnd();
        var temp = new RootAlleTextbausteine();

        try
        {
            temp = JsonConvert.DeserializeObject<RootAlleTextbausteine>(jsonString);
            _statusZipDatei = StatusZipDatei.JsonDateiOk;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        if (temp?.AlleTextbausteine == null)
        {
            _statusZipDatei = StatusZipDatei.JsonDateiLeer;
            return;
        }

        _alletextbausteines = temp.AlleTextbausteine;

        var id = 0;

        foreach (var textbaustein in _alletextbausteines)
        {
            if (id + 1 != textbaustein.Id) _statusZipDatei = StatusZipDatei.JsonEintraegeFalsch;
            id++;
        }
    }

    public StatusZipDatei? GetStatusZipDatei() => _statusZipDatei;
    public int GetAnzahlTextbausteine() => _alletextbausteines!.Length;
    public bool IsIdVorhanden(int id)
    {
        if (id == 0) return false;
        return id <= _alletextbausteines!.Length;
    }
    public string? GetBezeichnung(int id) => IsIdVorhanden(id) ? _alletextbausteines?[id - 1].Bezeichnung : "-";
    public string? GetUeberschriftH1(int id) => IsIdVorhanden(id) ? _alletextbausteines?[id - 1].UeberschriftH1 : "-";
    public string? GetUnterUeberschriftH2(int id) => IsIdVorhanden(id) ? _alletextbausteines?[id - 1].UnterUeberschriftH2 : "-";
    public string GetInhalt(int id) => IsIdVorhanden(id) ? Encoding.UTF8.GetString(Convert.FromBase64String(_alletextbausteines?[id - 1].Inhalt!)) : "-";
    private string? GetTest(int id) => IsIdVorhanden(id) ? _alletextbausteines?[id - 1].Test : "-";
}