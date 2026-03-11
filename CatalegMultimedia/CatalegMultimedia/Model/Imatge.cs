using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Imatge : Mitja
    {
        public int Alcada { get; set; }
        public int Amplada { get; set; }
        public string EspaiColor { get; set; }

        public Imatge(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            int alcada,
            int amplada,
            string espaiColor) :base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer)
        {     
            Alcada = alcada;
            Amplada = amplada;
            EspaiColor = espaiColor;
        }
    }
}
