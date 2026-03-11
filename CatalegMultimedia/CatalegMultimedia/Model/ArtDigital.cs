using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class ArtDigital : Bitmap
    {

        public string SoftwareUtilitzat { get; set; }

        // Constructor buit
        public ArtDigital()
            : base("", "", "", 0, null, "", 0, 0, "", 0, "")
        { }

        // Constructor amb tots els paràmetres i valors per defecte
        public ArtDigital(
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
            string softwareUtilitzat = "")
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor, resolucioDPI, tipusCompressio)
        {
            SoftwareUtilitzat = softwareUtilitzat;
        }

        // Constructor des de línia CSV
        public ArtDigital(string liniaCSV)
            : base("","","",0,null,"",0,0,"",0,"")
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
            SoftwareUtilitzat = camps[11].Trim();
        }

        // ToString
        public override string ToString() =>
            $"[ArtDigital] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is ArtDigital altre && Id == altre.Id;
    }
}
