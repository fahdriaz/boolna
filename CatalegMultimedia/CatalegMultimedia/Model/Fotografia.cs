using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Fotografia : Bitmap
    {

        public string ModelCamera { get; set; }
        public string OberturaDiafragma { get; set; }
        public int ISO { get; set; }

        // Constructor buit
        public Fotografia()
            :base("", "", "", 0, null, "", 0, 0, "", 0, "")
        { 
            ModelCamera = string.Empty;
            OberturaDiafragma = string.Empty;
            ISO = 0;
        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Fotografia(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            List<string> etiquetes = null,
            string rutaFitxer = "",
            int alcada = 0,
            int amplada = 0,
            string espaiColor = "",
            int resolucioDPI = 0,
            string tipusCompressio = "",
            string modelCamera = "",
            string oberturaDiafragma = "",
            int iso = 0)
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor, resolucioDPI, tipusCompressio)
        {
            ModelCamera = modelCamera;
            OberturaDiafragma = oberturaDiafragma;
            ISO = iso;
        }

        // Constructor des de línia CSV
        public Fotografia(string liniaCSV)
            : base("", "", "", 0, null, "", 0, 0, "", 0, "")
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
            Alcada = int.Parse(camps[6].Trim());
            Amplada = int.Parse(camps[7].Trim());
            EspaiColor = camps[8].Trim();
            ResolucioDPI = int.Parse(camps[9].Trim());
            TipusCompressio = camps[10].Trim();
            ModelCamera = camps[11].Trim();
            OberturaDiafragma = camps[12].Trim();
            ISO = int.Parse(camps[13].Trim());
        }

        // ToString
        public override string ToString() =>
            $"[Fotografia] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Fotografia altre && Id == altre.Id;
    }
}
