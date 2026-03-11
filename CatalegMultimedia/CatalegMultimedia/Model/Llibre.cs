using System.Collections.Generic;
using System.Linq;

namespace SugarSyntex.Model
{
    public class Llibre : Publicacio
    {
        // Només propietats pròpies de Llibre (la resta ja estan a Mitja, Text i Publicacio)
        public string GenereLiterari { get; set; }
        public bool TapaDura { get; set; }

        // Constructor sense paràmetres
        public Llibre()
            : base("", "", "", 0, null, "", "", 0, "", "", 0)
        {
            GenereLiterari = "";
            TapaDura = false;
        }

        // Constructor amb tots els paràmetres
        public Llibre(
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
            string genereLiterari = "",
            bool tapaDura = false)
            : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, idioma, nombreParaules, editorial, isbn_issn, pagines)
        {
            GenereLiterari = genereLiterari;
            TapaDura = tapaDura;
        }

        // Constructor des de línia CSV
        public Llibre(string liniaCSV)
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
            GenereLiterari = camps[11];
            TapaDura = bool.Parse(camps[12]);
        }

        public override string ToString()
        {
            return $"[Llibre] {Titol} ({AnyCreacio}) - {Autor}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Llibre altre)
                return Id == altre.Id;
            return false;
        }
    }
}
