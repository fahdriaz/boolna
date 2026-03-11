using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    public abstract class Mitja  // Abstract class significa que no es pot instanciar directament, només a través de les seves subclasses
    {
        public string Id { get; set; }
        public string Titol { get; set; }
        public string Autor { get; set; }
        public int AnyCreacio { get; set; }
        public List<string> Etiquetes { get; set; }
        public string RutaFitxer { get; set; }


        public Mitja(
            string id,
            string titol,
            string autor,
            int anyCreacio,
            List<string> etiquetes,
            string rutaFitxer)
        {
            Id = id;
            Titol = titol;
            Autor = autor;
            AnyCreacio = anyCreacio;
            Etiquetes = etiquetes ?? new List<string>();
            RutaFitxer = rutaFitxer;
        }

        public override string ToString()
        {
            return $"[{Id}] {Titol} ({Autor}, {AnyCreacio})";
        }
    }
}
