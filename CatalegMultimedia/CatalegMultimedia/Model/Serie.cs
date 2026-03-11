using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Serie : Video
    {
        // Propietats automàtiques públiques

        public int Temporada { get; set; }
        public int Episodi { get; set; }

        // Constructor buit
        public Serie()
            :base("","","",0,null,"",0,0,"")
        { }

        // Constructor amb tots els paràmetres i valors per defecte
        public Serie(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            List<string> etiquetes = null,
            string rutaFitxer = "",
            string resolucio = "",
            int frameRate = 0,
            int durada = 0,
            int temporada = 0,
            int episodi = 0):base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, durada, frameRate, resolucio)
        {
            Id = id;
            Titol = titol;
            Autor = autor;
            AnyCreacio = anyCreacio;
            Etiquetes = etiquetes;
            RutaFitxer = rutaFitxer;
            Resolucio = resolucio;
            FrameRate = frameRate;
            Durada = durada;
            Temporada = temporada;
            Episodi = episodi;
        }

        // Constructor des de línia CSV
        public Serie(string liniaCSV)
            :base("", "", "", 0, null, "", 0, 0, "")
        {
            string[] camps = liniaCSV.Split(';');
            Id = camps[0];
            Titol = camps[1];
            Autor = camps[2];
            AnyCreacio = int.Parse(camps[3]);
            Etiquetes = camps[4].Split('|').ToList();
            RutaFitxer = camps[5];
            // Series.csv format: Id;Titol;Autor;AnyCreacio;Etiquetes;RutaFitxer;Resolucio;FrameRate;DuradaSegons;Temporada;Episodi
            Resolucio = camps[6];
            FrameRate = int.Parse(camps[7]);
            Durada = int.Parse(camps[8]);
            Temporada = int.Parse(camps[9]);
            Episodi = int.Parse(camps[10]);
        }

        // ToString
        public override string ToString() =>
            $"[Serie] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Serie altre && Id == altre.Id;
    }
}
