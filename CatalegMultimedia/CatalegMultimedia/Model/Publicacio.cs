using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Publicacio : Text
    {
        public string Editorial { get; set; }
        public string ISBN_ISSN { get; set; }
        public int Pagines { get; set; }

        public Publicacio(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            string idioma,
            int nombreParaules,
            string editorial,
            string isbn_issn,
            int pagines):base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, idioma, nombreParaules)
        {
            Editorial = editorial;
            ISBN_ISSN = isbn_issn;
            Pagines = pagines;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Editorial: {Editorial}, ISBN/ISSN: {ISBN_ISSN}, Pàgines: {Pagines}";
        }
    }
}
