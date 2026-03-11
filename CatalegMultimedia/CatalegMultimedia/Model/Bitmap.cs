using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Bitmap : Imatge
    {
        public int ResolucioDPI { get; set; }
        public string TipusCompressio { get; set; }

        public Bitmap(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            int alcada,
            int amplada,
            string espaiColor,
            int resolucioDPI,
            string tipusCompressio) : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, alcada, amplada, espaiColor)
        {
            ResolucioDPI = resolucioDPI;
            TipusCompressio = tipusCompressio;
        }

        public override string ToString()
        {
            return base.ToString() + $" | DPI: {ResolucioDPI}, Compressió: {TipusCompressio}";
        }
    }
}
