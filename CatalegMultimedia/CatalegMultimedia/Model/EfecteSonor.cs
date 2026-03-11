using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntax;

public class EfecteSonor : So
{
    // ── Propietats automàtiques ──────────────────────────────────────────────
    // Camps específics d'EfecteSonor
    public string Categoria { get; set; }
    public bool EsLoop { get; set; }

    // ── Constructors ─────────────────────────────────────────────────────────

    /// <summary>Constructor buit.</summary>
    public EfecteSonor()
        : base("", "", "", 0, null, "", "", Bitrate.Kbps128, TimeSpan.Zero, false)
    {
        Categoria = "";
        EsLoop = false;
    }

    /// <summary>Constructor amb tots els paràmetres i valors per defecte.</summary>
    public EfecteSonor(
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
        string categoria = "",
        bool esLoop = false)
        : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere, bitrateKbps, durada, esStereo)
    {
        Categoria = categoria;
        EsLoop = esLoop;
    }

    /// <summary>Constructor des d'una línia CSV.</summary>
    public EfecteSonor(string liniaCSV)
        : base("", "", "", 0, null, "", "", Bitrate.Kbps128, TimeSpan.Zero, false)
    {
        string[] camps = liniaCSV.Split(';');

        Id = camps[0].Trim();
        Titol = camps[1].Trim();
        Autor = camps[2].Trim();
        AnyCreacio = int.Parse(camps[3].Trim());
        Etiquetes = camps[4].Trim().Length > 0
            ? new List<string>(camps[4].Trim().Split('|'))
            : new List<string>();
        RutaFitxer = camps[5].Trim();
        Genere = camps[6].Trim();
        BitrateKbps = Enum.Parse<Bitrate>(camps[7].Trim());
        EsStereo = bool.Parse(camps[8].Trim());
        double segons = double.Parse(camps[9].Trim().Replace(",", "."));
        Durada = TimeSpan.FromSeconds(segons);

        // Categoria i EsLoop no estan al CSV
        Categoria = "";
        EsLoop = false;
    }

    // ── Mètodes ──────────────────────────────────────────────────────────────

    public override string ToString()
        => $"[EfecteSonor] {Titol} ({AnyCreacio}) - {Autor}";

    public override bool Equals(object? obj)
        => obj is EfecteSonor altre && Id == altre.Id;

}
