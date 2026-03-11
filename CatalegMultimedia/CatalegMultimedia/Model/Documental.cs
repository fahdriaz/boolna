using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Documental : Video
    {
        // Propietats automàtiques públiques

        public string Tema { get; set; }

        // Constructor buit
        public Documental()
            :base("","","",0,null,"",0,0,"")
        { }

        // Constructor amb tots els paràmetres i valors per defecte
        public Documental(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            string etiquetes = "",
            string rutaFitxer = "",
            string resolucio = "",
            int frameRate = 0,
            int durada = 0,
            string tema = ""):base(id, titol, autor, anyCreacio, new List<string>(etiquetes.Split(',')), rutaFitxer, durada, frameRate, resolucio)
        {
            Tema = tema;
        }

        // Constructor des de línia CSV
        public Documental(string liniaCSV)
            :base("", "", "", 0, new List<string>(), "", 0, 0, "")
        {
            string[] camps = liniaCSV.Split(';');
            Id = camps[0];
            Titol = camps[1];
            Autor = camps[2];
            AnyCreacio = int.Parse(camps[3]);
            Etiquetes = camps[4].Split('|').ToList();
            RutaFitxer = camps[5];
            Resolucio = camps[6];
            FrameRate = double.Parse(camps[7]);
            Durada = int.Parse(camps[8]);
            Tema = camps[9];
        }

        // ToString
        public override string ToString() =>
            $"[Documental] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Documental altre && Id == altre.Id;
    }
}
