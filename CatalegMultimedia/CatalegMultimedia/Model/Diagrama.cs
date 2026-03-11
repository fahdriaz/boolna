using SugarSyntex.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax.Model
{
    public class Diagrama : Vectorial
    {
        // Propietats automàtiques públiques
        public string TipusDiagrama { get; set; }
        public string SoftwareCreacio { get; set; }

        // Constructor buit
        public Diagrama()
            : base("", "", "", 0, null, "", 0, 0, "", 0, false, "")
        {
            TipusDiagrama = "";
            SoftwareCreacio = string.Empty;
        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Diagrama(
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
            string tipusDiagrama = "",
            string softwareCreacio = "")
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor, nombreVectors, teFonsTransparent, versioSVG)
        {
            TipusDiagrama = tipusDiagrama;
            SoftwareCreacio = softwareCreacio;
        }

        // Constructor des de línia CSV
        public Diagrama(string liniaCSV)
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
            TipusDiagrama = camps[12].Trim();
            SoftwareCreacio = camps[13].Trim();

        }

        // ToString
        public override string ToString() =>
            $"[Diagrama] {Titol} ({AnyCreacio}) - {Autor}";

        // Equals
        public override bool Equals(object? obj) =>
            obj is Diagrama altre && Id == altre.Id;
    }
}
