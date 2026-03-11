using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public class Gravat : Publicacio
    {


        // Propietats

        public string Tecnica { get; set; }
        public int NumeroSerie { get; set; }
        public string DimensionsFisiques { get; set; }

        // Constructor sense paràmetres (inicialitza tots els camps a valors per defecte)
        public Gravat()
            : base("", "", "", 0, null, "", "", 0, "", "", 0)
        {
            Tecnica = "";
            NumeroSerie = 0;
            DimensionsFisiques = "";
        }

        // Constructor amb tots els paràmetres i valors per defecte
        public Gravat(
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
            string tecnica = "",
            int numeroSerie = 0,
            string dimensionsFisiques = ""):base("", "", "", 0, null, "", "", 0, "", "", 0)
        {

            Tecnica = tecnica;
            NumeroSerie = numeroSerie;
            DimensionsFisiques = dimensionsFisiques;
        }

        // Constructor des de línia CSV
        public Gravat(string liniaCSV)
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
            Tecnica = camps[11];
            NumeroSerie = int.Parse(camps[12]);
            DimensionsFisiques = camps[13];
        }

        // Override ToString
        public override string ToString()
        {
            return $"[Gravat] {Titol} ({AnyCreacio}) - {Autor}";
        }

        // Override Equals
        public override bool Equals(object? obj)
        {
            if (obj is Gravat altre)
            {
                return Id == altre.Id;
            }
            return false;
        }

    }
}
