using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntax;

public class Partitura : Audio
{
    // ── Propietats automàtiques ──────────────────────────────────────────────


    // Camps específics de Partitura
    public string Instrument { get; set; }
    public string Tonalitat { get; set; }
    public int NumPagines { get; set; }
    public string Editorial { get; set; }


    // ── Constructors ─────────────────────────────────────────────────────────

    /// <summary>Constructor buit.</summary>
    public Partitura()
        :base("", "", "", 0, null, "", "")
    {
        Instrument = "";
        Tonalitat = "";
        NumPagines = 0;
        Editorial = "";
    }

    /// <summary>Constructor amb tots els paràmetres i valors per defecte.</summary>
    public Partitura(
        string id = "",
        string titol = "",
        string autor = "",
        int anyCreacio = 0,
        List<string> etiquetes = null,
        string rutaFitxer = "",
        string genere = "",
        string instrument = "",
        string tonalitat = "",
        int numPagines = 0,
        string editorial = "")
        : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere)
    {
        Instrument = instrument;
        Tonalitat = tonalitat;
        NumPagines = numPagines;
        Editorial = editorial;
    }

    /// <summary>Constructor des d'una línia CSV.</summary>
    public Partitura(string liniaCSV)
        : base("", "", "", 0, null, "", "")
    {
        // Columnes CSV:
        // Id;Titol;Autor;AnyCreacio;Etiquetes;RutaFitxer;Genere;InstrumentPrincipal;Tonalitat;NombrePagines;Editorial
        string[] camps = liniaCSV.Split(';'); // Split per separar els camps segons el delimitador ';'
        Id = camps[0].Trim(); // Trim per eliminar espais en blanc al principi i al final
        Titol = camps[1].Trim();
        Autor = camps[2].Trim();
        AnyCreacio = int.Parse(camps[3].Trim());
        Etiquetes = camps[4].Trim().Length > 0 ? new List<string>(camps[4].Trim().Split('|')) : new List<string>();
        RutaFitxer = camps[5].Trim();
        Genere = camps[6].Trim();
        Instrument = camps[7].Trim();
        Tonalitat = camps[8].Trim();             
        NumPagines = int.Parse(camps[9].Trim());   
        Editorial = camps[10].Trim();
    }

    // ── Mètodes ──────────────────────────────────────────────────────────────

    public override string ToString()
        => $"[Partitura] {Titol} ({AnyCreacio}) - {Autor}";

    public override bool Equals(object? obj)
        => obj is Partitura altra && Id == altra.Id;

}
