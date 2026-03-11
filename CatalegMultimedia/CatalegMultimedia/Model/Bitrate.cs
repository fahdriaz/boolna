using System;
using System.Collections.Generic;
using System.Text;

namespace SugarSyntex.Model
{
    /// <summary>
    /// Enumeració de valor únic per als bitrates d'àudio.
    /// S'utilitza a les classes: Canço, Podcast, Audiollibre i EfecteSonor.
    /// </summary>
    /// 
    public enum Bitrate
    {
        Kbps64,
        Kbps96,
        Kbps128,
        Kbps192,
        Kbps360
    }

}
