using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntax;


[Flags]

/// <summary>
/// Enumeració multivalor (Flags) per als temes d'un podcast.
/// Permet combinar diversos temes amb l'operador |
/// Exemple: TemaPodcast.Tecnologia | TemaPodcast.Futur
/// </summary>

public enum TemaPodcast
{
    Caps = 0,   // 0
    Hàbits = 1 << 0,   // 1
    Tecnologia = 1 << 1,   // 2
    Benestar = 1 << 2,   // 4
    Creativitat = 1 << 3,   // 8
    Futur = 1 << 4,   // 16
    Negocis = 1 << 5,   // 32
    Cultura = 1 << 6,   // 64
    Psicologia = 1 << 7,   // 128
    Productivitat = 1 << 8, // 256
    Societat = 1 << 9    // 512
}

