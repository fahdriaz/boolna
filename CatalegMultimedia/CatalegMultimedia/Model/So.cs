using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class So : Audio
    {
        public Bitrate BitrateKbps { get; set; }
        public TimeSpan Durada { get; set; }
        public bool EsStereo { get; set; }

        public So(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer,
            string genere,
            Bitrate bitrateKbps,
            TimeSpan durada,
            bool esStereo) : base(id, titol, autor, anyCreacio, etiquetes, rutaFitxer, genere)
        {
            BitrateKbps = bitrateKbps;
            Durada = durada;
            EsStereo = esStereo;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Bitrate: {BitrateKbps} kbps, Durada: {Durada} s, Stereo: {EsStereo}";
        }
    }
}
