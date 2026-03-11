using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Vectorial : Imatge
    {
        public int NombreVectors { get; set; }
        public bool TeFonsTransparent { get; set; }
        public string VersioSVG { get; set; }

        public Vectorial(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            int alcada,
            int amplada,
            string espaiColor,
            int nombreVectors,
            bool teFonsTransparent,
            string versioSVG) : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor)

        {
            NombreVectors = nombreVectors;
            TeFonsTransparent = teFonsTransparent;
            VersioSVG = versioSVG;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Vectors: {NombreVectors}, FonsTransp: {TeFonsTransparent}, SVG: {VersioSVG}";
        }
    }
}
