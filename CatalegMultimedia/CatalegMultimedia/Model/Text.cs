using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Text : Mitja
    {
        public string Idioma { get; set; }
        public int NombreParaules { get; set; }

        public Text(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            string idioma,
            int nombreParaules):base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer)
        {
            Idioma = idioma;
            NombreParaules = nombreParaules;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Idioma: {Idioma}, Paraules: {NombreParaules}";
        }
    }
}
