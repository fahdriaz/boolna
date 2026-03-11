using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Video : Mitja
    {
        public int Durada { get; set; }
        public double FrameRate { get; set; }
        public string Resolucio { get; set; }

        public Video(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            int durada,
            double frameRate,
            string resolucio) : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer)
        {
            Durada = durada;
            FrameRate = frameRate;
            Resolucio = resolucio;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Durada: {Durada} s, Framerate: {FrameRate} fps, Resolució: {Resolucio}";
        }
    }
}
