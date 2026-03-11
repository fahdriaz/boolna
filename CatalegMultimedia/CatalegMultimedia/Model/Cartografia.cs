using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public class Cartografia : Publicacio
    {
        // Propietats
        public string TipusProjeccio { get; set; }
        public string Escala { get; set; }
        public string RegioGeografica { get; set; }
        public string DimensionsFisiques { get; set; }

        // Constructor sense paràmetres (inicialitza tots els camps a valors per defecte)
        public Cartografia()
            : base("", "", "", 0, null, "", "", 0, "", "", 0)
        {
            Id = "";
            Titol = "";
            Autor = "";
            AnyCreacio = 0;
            Etiquetes = new List<string>();
            RutaFitxer = "";
            Idioma = "";
            NombreParaules = 0;
            Editorial = "";
            ISBN_ISSN = "";
            Pagines = 0;
            TipusProjeccio = "";
            Escala = "";
            RegioGeografica = "";
            DimensionsFisiques = "";
        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Cartografia(
            string id = "",
            string titol = "",
            string autor = "",
            int anyCreacio = 0,
            List<string> etiquetes = null,
            string rutaFitxer = "",
            string idioma = "",
            int nombreParaules = 0,
            string editorial = "",
            string isbn_issn = "",
            int pagines = 0,
            string tipusProjeccio = "",
            string escala = "",
            string regioGeografica = "",
            string dimensionsFisiques = ""):base("", "", "", 0, null, "", "", 0, "", "", 0)
        {

            TipusProjeccio = tipusProjeccio;
            Escala = escala;
            RegioGeografica = regioGeografica;
            DimensionsFisiques = dimensionsFisiques;
        }

        // Constructor des de línia CSV
        public Cartografia(string liniaCSV)
            :base("", "", "", 0, null, "", "", 0, "", "", 0)
        {
            string[] camps = liniaCSV.Split(';');

            Id = camps[0];
            Titol = camps[1];
            Autor = camps[2];
            AnyCreacio = int.Parse(camps[3]);
            Etiquetes = camps[4].Split('|').ToList();
            RutaFitxer = camps[5];
            Idioma = camps[6];
            NombreParaules = int.Parse(camps[7]);
            Editorial = camps[8];
            ISBN_ISSN = camps[9];
            Pagines = int.Parse(camps[10]);
            TipusProjeccio = camps[11];
            Escala = camps[12];
            RegioGeografica = camps[13];
            DimensionsFisiques = camps[14];
        }

        // Override ToString
        public override string ToString()
        {
            return $"[Cartografia] {Titol} ({AnyCreacio}) - {Autor}";
        }

        // Override Equals
        public override bool Equals(object? obj)
        {
            if (obj is Cartografia altra)
            {
                return Id == altra.Id;
            }
            return false;
        }

    }
}
