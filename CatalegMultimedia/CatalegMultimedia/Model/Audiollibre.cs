using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntax;

public class Audiollibre : So
{
    // ── Propietats automàtiques ──────────────────────────────────────────────

    // Camps específics d'Audiollibre
    public string Narradora { get; set; }
    public string Idioma { get; set; }
    public int NumCapitols { get; set; }

    // ── Constructors ─────────────────────────────────────────────────────────

    /// <summary>Constructor buit.</summary>
    public Audiollibre()
        :base("","","",0,null,"","",0,TimeSpan.Zero,false)
    {
        Narradora = string.Empty;
        Idioma = string.Empty;
        NumCapitols = 0;
    }

    /// <summary>Constructor amb tots els paràmetres i valors per defecte.</summary>
    public Audiollibre(
            string id = "",
        string titol = "",
        string autor = "",
        int anyCreacio = 0,
        List<string> etiquetes = null,
        string rutaFitxer = "",
        string genere = "",
        Bitrate bitrateKbps = Bitrate.Kbps128,
        TimeSpan durada = default,
        bool esStereo = false,
        string narradora = "",
        string idioma = "",
        int numCapitols = 0)
        : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere, bitrateKbps, durada, esStereo)
    {
        Narradora = narradora;
        Idioma = idioma;
        NumCapitols = numCapitols;
    }

    /// <summary>Constructor des d'una línia CSV.</summary>
    public Audiollibre(string liniaCSV)
        : base("", "", "", 0, null, "", "", 0, TimeSpan.Zero, false)

    {
        // Columnes CSV:
        // Id;Titol;Autor;AnyCreacio;Etiquetes;RutaFitxer;Genere;BitrateKbps;EsStereo;DuradaSegons;Narrador;Idioma;Capitols
        string[] camps = liniaCSV.Split(';');

        Id = camps[0].Trim();
        Titol = camps[1].Trim();
        Autor = camps[2].Trim();
        AnyCreacio = int.Parse(camps[3].Trim());
        Etiquetes = camps[4].Trim().Length > 0 ? new List<string>(camps[4].Trim().Split('|')) : new List<string>();
        RutaFitxer = camps[5].Trim();
        Genere = camps[6].Trim();
        BitrateKbps = Enum.Parse<Bitrate>(camps[7].Trim());
        EsStereo = bool.Parse(camps[8].Trim());
        double segons = double.Parse(camps[9].Trim().Replace(",", "."));
        Durada = TimeSpan.FromSeconds(segons);
        Narradora = camps[10].Trim();
        NumCapitols = int.Parse(camps[12].Trim());
    }

    // ── Mètodes ──────────────────────────────────────────────────────────────

    public override string ToString()
        => $"[Audiollibre] {Titol} ({AnyCreacio}) - {Autor}";

    public override bool Equals(object? obj)
        => obj is Audiollibre altre && Id == altre.Id;

}
