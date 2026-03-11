using System.Collections.Generic;
using System.Linq;

namespace SugarSyntex.Model
{
    public class Revista : Publicacio
    {
        // Només propietats pròpies de Revista
        public string Periodicitat { get; set; }
        public int NumeroVolum { get; set; }
        public int NumeroExemplar { get; set; }
        public string Mes { get; set; }

        // Constructor sense paràmetres
        public Revista()
            : base("", "", "", 0, null, "", "", 0, "", "", 0)
        {
            Periodicitat = "";
            NumeroVolum = 0;
            NumeroExemplar = 0;
            Mes = "";
        }

        // Constructor amb tots els paràmetres
        public Revista(
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
            string periodicitat = "",
            int numeroVolum = 0,
            int numeroExemplar = 0,
            string mes = "")
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, idioma, nombreParaules, editorial, isbn_issn, pagines)
        {
            Periodicitat = periodicitat;
            NumeroVolum = numeroVolum;
            NumeroExemplar = numeroExemplar;
            Mes = mes;
        }

        // Constructor des de línia CSV
        public Revista(string liniaCSV)
            : base("", "", "", 0, null, "", "", 0, "", "", 0)
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
            Periodicitat = camps[11];
            NumeroVolum = int.Parse(camps[12]);
            NumeroExemplar = int.Parse(camps[13]);
            Mes = camps[14];
        }

        public override string ToString()
        {
            return $"[Revista] {Titol} ({AnyCreacio}) - {Autor}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Revista altra)
                return Id == altra.Id;
            return false;
        }
    }
}