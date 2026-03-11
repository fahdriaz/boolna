using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntax;

public class Canco : So
{
    public string Album { get; set; }
    public int NumeroPista { get; set; }

    // --- Constructors ----------------------------------

    /// <summary>Constructor buit.</summary>
    public Canco()
        :base("","","",0,null,"","",0,TimeSpan.Zero,false)
    {
        Album = "";
        NumeroPista = 0;
    }

    /// <summary>Constructor amb tots els paràmetres i valors per defecte.</summary>
    public Canco(
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
        string album = "",
        int numeroPista = 0)
        : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere, bitrateKbps, durada, esStereo)
    {
        Album = album;
        NumeroPista = numeroPista;
    }

    /// <summary>Constructor des d'una línia CSV.</summary>
    public Canco(string liniaCSV)
        :base("", "", "", 0, null, "", "", 0, TimeSpan.Zero, false)
    {
        // Exemple columnes CSV:
        // Id;Titol;Autor;AnyCreacio;Etiquetes;RutaFitxer;Genere;BitrateKbps;EsStereo;DuradaSegons;Album;NumeroPista
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
        Album = camps[10].Trim();
        NumeroPista = int.Parse(camps[11].Trim());
    }

    // --- Mètodes -----------------------

    public override string ToString()
        => $"[Canço] {Titol} ({AnyCreacio}) - {Autor}";

    public override bool Equals(object? obj)
        => obj is Canco altra && Id == altra.Id;

}
