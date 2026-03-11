using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Logotip : Vectorial
    {

        public string Empresa { get; set; }
        public string ManualIdentitatUrl { get; set; }

        // Constructor buit
        public Logotip()
            : base("", "", "", 0, null, "", 0, 0, "", 0, false, "")
        { 
            Empresa = "";
            ManualIdentitatUrl = string.Empty;
        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Logotip(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            List<string> etiquetes = null,
            string rutaFitxer = "",
            int alcada = 0,
            int amplada = 0,
            string espaiColor = "",
            int nombreVectors = 0,
            bool teFonsTransparent = false,
            string versioSVG = "",
            string empresa = "",
            string manualIdentitatUrl = "")
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor, nombreVectors, teFonsTransparent, versioSVG)
        {
            Empresa = empresa;
            ManualIdentitatUrl = manualIdentitatUrl;
        }

        // Constructor des de línia CSV
        public Logotip(string liniaCSV)
            : base("", "", "", 0, null, "", 0, 0, "", 0, false, "")
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
            VersioSVG = camps[9].Trim();
            NombreVectors = int.Parse(camps[10].Trim());
            TeFonsTransparent = bool.Parse(camps[11].Trim());
            Empresa = camps[12].Trim();
            ManualIdentitatUrl = camps[13].Trim();
        }

        // ToString
        public override string ToString() =>
            $"[Logotip] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Logotip altre && Id == altre.Id;
    }
}
