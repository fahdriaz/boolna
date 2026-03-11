using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Pelicula : Video
    {
        // Propietats automàtiques públiques

        public string Director { get; set; }
        public string ClassificacioEdat { get; set; }

        // Constructor buit
        public Pelicula() 
            : base("", "", "", 0, null, "", 0, 0, "")
        { 

        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Pelicula(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            List<string> etiquetes = null,
            string rutaFitxer = "",
            int durada = 0,
            string resolucio = "",
            int frameRate = 0,
            string director = "",
            string classificacioEdat = ""): base(id,titol, autor, anyCreacio, etiquetes, rutaFitxer, durada, frameRate, resolucio)
        {
            Director = director;
            ClassificacioEdat = classificacioEdat;
        }

        // Constructor des de línia CSV
        public Pelicula(string liniaCSV)
            : base("", "", "", 0, null, "", 0, 0, "")
        {
            string[] camps = liniaCSV.Split(';');
            Id = camps[0];
            Titol = camps[1];
            Autor = camps[2];
            AnyCreacio = int.Parse(camps[3]);
            Etiquetes = camps[4].Split('|').ToList();
            RutaFitxer = camps[5];
            Resolucio = camps[6];
            FrameRate = int.Parse(camps[7]);
            Durada = int.Parse(camps[8]);
            Director = camps[9];
            ClassificacioEdat = camps[10];
        }

        // ToString
        public override string ToString() =>
            $"[Pelicula] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Pelicula altre && Id == altre.Id;
    }
}
