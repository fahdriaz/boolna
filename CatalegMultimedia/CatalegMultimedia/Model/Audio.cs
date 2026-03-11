using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Audio : Mitja
    {
        public string Genere { get; set; }

        public Audio(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            string genere) : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer)
        {
            Genere = genere;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Gènere: {Genere}";
        }
    }
}
