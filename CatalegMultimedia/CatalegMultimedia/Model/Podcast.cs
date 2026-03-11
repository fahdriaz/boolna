using SugarSyntex.Model;
using static SugarSyntax.TemaPodcast;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntax;

public class Podcast : So
{
    // ── Propietats automàtiques ──────────────────────────────────────────────
    public string Presentador { get; set; }
    public int NumeroEpisodi { get; set; }
    /// <summary>
    /// Propietat multivalor: pot combinar diversos temes.
    /// Exemple: Tema = TemaPodcast.Tecnologia | TemaPodcast.Futur
    /// </summary>
    public TemaPodcast Tema { get; set; }

    // ── Constructors ─────────────────────────────────────────────────────────

    /// <summary>Constructor buit.</summary>
    public Podcast()
        :base("","","",0,null,"","",0,TimeSpan.Zero,false)
    {
        Presentador = "";
        NumeroEpisodi = 0;
        Tema = 0;

    }

    /// <summary>Constructor amb tots els paràmetres i valors per defecte.</summary>
    public Podcast(
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
        string presentador = "",
        int numeroEpisodi = 0,
        TemaPodcast tema = TemaPodcast.Tecnologia)
        : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere, bitrateKbps, durada, esStereo)
    {
        Presentador = presentador;
        NumeroEpisodi = numeroEpisodi;
        Tema = tema;
    }

    /// <summary>Constructor des d'una línia CSV.</summary>
    public Podcast(string liniaCSV)
        : base("", "", "", 0, null, "", "", 0, TimeSpan.Zero, false)
    {
        // Columnes CSV:
        // Id;Titol;Autor;AnyCreacio;Etiquetes;RutaFitxer;Genere;BitrateKbps;EsStereo;DuradaSegons;Presentador;NumeroEpisodi;Tema
        string[] camps = liniaCSV.Split(';');

        Id = camps[0].Trim();
        Titol = camps[1].Trim();
        Autor = camps[2].Trim();
        AnyCreacio = int.Parse(camps[3].Trim());
        Etiquetes = new List<string>(camps[4].Trim().Split('|'));
        RutaFitxer = camps[5].Trim();
        Genere = camps[6].Trim();
        BitrateKbps = Enum.Parse<Bitrate>(camps[7].Trim());
        EsStereo = bool.Parse(camps[8].Trim());
        double segons = double.Parse(camps[9].Trim().Replace(",", "."));
        Durada = TimeSpan.FromSeconds(segons);
        Presentador = camps[10].Trim();
        NumeroEpisodi = int.Parse(camps[11].Trim());
        // El tema pot venir com "Tecnologia|Futur" al CSV - parseamos el primer
        /*Tema = TemaPodcast.Cultura;*///Enum.Parse<TemaPodcast>(camps[12].Trim().Split('|')[0].Trim());

        // Has de convertir un string que te diversos valors en un array de strigs que te els valors separats fent un split.
        // Ara has de convertir cada una de les enumeracions amb un parse!
        // Despres ho has de operar amb una O | 
        // falta cap en enumeracions
        // 1. Fem un Split('|') per obtenir un array amb cada valor de tema
        //    Exemple: "Societat|Creativitat|Futur" → ["Societat", "Creativitat", "Futur"]
        string[] temes = camps[12].Trim().Split('|');

        // 2. Parsegem cada valor de l'array a TemaPodcast i els combinem amb |
        Tema = 0;
        foreach (string t in temes)
        {
            if (t.Trim() != "")
                Tema = Tema | Enum.Parse<TemaPodcast>(t.Trim());
        }
    }

    // ── Mètodes ──────────────────────────────────────────────────────────────

    public override string ToString()
        => $"[Podcast] {Titol} ({AnyCreacio}) - {Autor}";

    public override bool Equals(object? obj)
        => obj is Podcast altre && Id == altre.Id;

}