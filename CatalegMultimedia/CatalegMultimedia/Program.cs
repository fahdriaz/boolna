using SugarSyntax;
using SugarSyntax.Model;
using SugarSyntex.Model;
using System;
using System.IO;
using System.Linq;
using static SugarSyntax.TemaPodcast;
using static SugarSyntex.Model.Bitrate;

namespace SugarSyntex
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Crear les 5 llistes separades
            List<Llibre> llibres = new List<Llibre>();
            List<Revista> revistes = new List<Revista>();
            List<Manuscrit> manuscrits = new List<Manuscrit>();
            List<Cartografia> cartografies = new List<Cartografia>();
            List<Gravat> gravats = new List<Gravat>();

            // Llegir llibres.csv
            StreamReader readerLlibres = new StreamReader("llibres.csv");
            readerLlibres.ReadLine(); // Saltar capçalera
            string liniaLlibre;
            while ((liniaLlibre = readerLlibres.ReadLine()) != null)
            {
                Llibre llibre = new Llibre(liniaLlibre);
                llibres.Add(llibre);
            }
            readerLlibres.Close();

            // Llegir revistes.csv
            StreamReader readerRevistes = new StreamReader("revistes.csv");
            readerRevistes.ReadLine(); // Saltar capçalera
            string liniaRevista;
            while ((liniaRevista = readerRevistes.ReadLine()) != null)
            {
                Revista revista = new Revista(liniaRevista);
                revistes.Add(revista);
            }
            readerRevistes.Close();

            // Llegir manuscrits.csv
            StreamReader readerManuscrits = new StreamReader("manuscrits.csv");
            readerManuscrits.ReadLine(); // Saltar capçalera
            string liniaManuscrit;
            while ((liniaManuscrit = readerManuscrits.ReadLine()) != null)
            {
                Manuscrit manuscrit = new Manuscrit(liniaManuscrit);
                manuscrits.Add(manuscrit);
            }
            readerManuscrits.Close();

            // Llegir mapes.csv
            StreamReader readerMapes = new StreamReader("mapes.csv");
            readerMapes.ReadLine(); // Saltar capçalera
            string liniaMapa;
            while ((liniaMapa = readerMapes.ReadLine()) != null)
            {
                Cartografia mapa = new Cartografia(liniaMapa);
                cartografies.Add(mapa);
            }
            readerMapes.Close();

            // Llegir gravats.csv
            StreamReader readerGravats = new StreamReader("gravats.csv");
            readerGravats.ReadLine(); // Saltar capçalera
            string liniaGravat;
            while ((liniaGravat = readerGravats.ReadLine()) != null)
            {
                Gravat gravat = new Gravat(liniaGravat);
                gravats.Add(gravat);
            }
            readerGravats.Close();

            // Imprimir totes les llistes utilitzant la funció genèrica
            Console.WriteLine("=== LLIBRES ===");
            ImprimeixLlista(llibres);

            Console.WriteLine("\n=== REVISTES ===");
            ImprimeixLlista(revistes);

            Console.WriteLine("\n=== MANUSCRITS ===");
            ImprimeixLlista(manuscrits);

            Console.WriteLine("\n=== CARTOGRAFIA ===");
            ImprimeixLlista(cartografies);

            Console.WriteLine("\n=== GRAVATS ===");
            ImprimeixLlista(gravats);

            // ------------------------------------
            //  5 llistes separades del catàleg
            // ------------------------------------

            List<Canco> cancons = new List<Canco>();
            List<Podcast> podcasts = new List<Podcast>();
            List<Audiollibre> audiolliures = new List<Audiollibre>();
            List<Partitura> partitures = new List<Partitura>();
            List<EfecteSonor> efectesSonors = new List<EfecteSonor>();

            // ----- Diccionari de Logotips -----------------------------------------
            Dictionary<string, Logotip> logotips = new Dictionary<string, Logotip>();

            StreamReader srLogotips = new StreamReader("Logos.csv");
            srLogotips.ReadLine(); // saltar capçalera
            string lineaLogotip = srLogotips.ReadLine();
            while (lineaLogotip != null)
            {
                Logotip logotip = new Logotip(lineaLogotip);
                logotips[logotip.Id] = logotip;
                lineaLogotip = srLogotips.ReadLine();
            }
            srLogotips.Close();

            // ---- Diccionari de Diagrames ----------------------------------------
            Dictionary<string, Diagrama> diagrames = new Dictionary<string, Diagrama>();

            StreamReader srDiagrames = new StreamReader("Diagrames.csv");
            srDiagrames.ReadLine(); // saltar capçalera
            string lineaDiagrama = srDiagrames.ReadLine();
            while (lineaDiagrama != null)
            {
                Diagrama diagrama = new Diagrama(lineaDiagrama);
                //{
                //    Id = lineaDiagrama.Split(',')[0],
                //}
                diagrames[diagrama.Id] = diagrama;
                lineaDiagrama = srDiagrames.ReadLine();
            }
            srDiagrames.Close();

            // ----- Diccionari de Fotografies ----------------------------------
            Dictionary<string, Fotografia> fotografies = new Dictionary<string, Fotografia>();

            StreamReader srFotos = new StreamReader("Fotos.csv");
            srFotos.ReadLine(); // saltar capçalera
            string lineaFoto = srFotos.ReadLine();
            while (lineaFoto != null)
            {
                Fotografia foto = new Fotografia(lineaFoto);
                fotografies[foto.Id] = foto;
                lineaFoto = srFotos.ReadLine();
            }
            srFotos.Close();

            // --- Diccionari d'Art Digital -----------------------------------
            Dictionary<string, ArtDigital> artsDigitals = new Dictionary<string, ArtDigital>();

            StreamReader srArtDigital = new StreamReader("ArtDigital.csv");
            srArtDigital.ReadLine(); // saltar capçalera
            string lineaArtDigital = srArtDigital.ReadLine();
            while (lineaArtDigital != null)
            {
                ArtDigital artDigital = new ArtDigital(lineaArtDigital);
                artsDigitals[artDigital.Id] = artDigital;
                lineaArtDigital = srArtDigital.ReadLine();
            }
            srArtDigital.Close();

            // --- Diccionari de Pel·lícules --------------------------------
            Dictionary<string, Pelicula> pelicules = new Dictionary<string, Pelicula>();

            StreamReader srPelicules = new StreamReader("Pelicules.csv");
            srPelicules.ReadLine(); // saltar capçalera
            string lineaPelicula = srPelicules.ReadLine();
            while (lineaPelicula != null)
            {
                Pelicula pelicula = new Pelicula(lineaPelicula);
                pelicules[pelicula.Id] = pelicula;
                lineaPelicula = srPelicules.ReadLine();
            }
            srPelicules.Close();

            // --- Diccionari de Documentals -------------------------------
            Dictionary<string, Documental> documentals = new Dictionary<string, Documental>();

            StreamReader srDocumentals = new StreamReader("Documentals.csv");
            srDocumentals.ReadLine(); // saltar capçalera
            string lineaDocumental = srDocumentals.ReadLine();
            while (lineaDocumental != null)
            {
                Documental documental = new Documental(lineaDocumental);
                documentals[documental.Id] = documental;
                lineaDocumental = srDocumentals.ReadLine();
            }
            srDocumentals.Close();

            // --- Diccionari de Series --------------------------------------
            Dictionary<string, Serie> series = new Dictionary<string, Serie>();

            StreamReader srSeries = new StreamReader("Series.csv");
            srSeries.ReadLine(); // saltar capçalera
            string lineaSerie = srSeries.ReadLine();
            while (lineaSerie != null)
            {
                Serie serie = new Serie(lineaSerie);
                series[serie.Id] = serie;
                lineaSerie = srSeries.ReadLine();
            }
            srSeries.Close();

            // ----------------------------------------------------------------
            //  LECTURA CSV
            // ----------------------------------------------------------------

            StreamReader sr = new StreamReader("Cansons.csv");
            sr.ReadLine(); // Saltar capçalera
            string linia;
            while ((linia = sr.ReadLine()) != null)
                cancons.Add(new Canco(linia));
            sr.Close();
            
            sr = new StreamReader("Podcats.csv");
            sr.ReadLine();
            while ((linia = sr.ReadLine()) != null)
                podcasts.Add(new Podcast(linia));
            sr.Close();
            
            sr = new StreamReader("Audiollibres.csv");
            sr.ReadLine();
            while ((linia = sr.ReadLine()) != null)
                audiolliures.Add(new Audiollibre(linia));
            sr.Close();
            
            sr = new StreamReader("Partitures.csv");
            sr.ReadLine();
            while ((linia = sr.ReadLine()) != null)
                partitures.Add(new Partitura(linia));
            sr.Close();
            
            sr = new StreamReader("Sons.csv");
            sr.ReadLine();
            while ((linia = sr.ReadLine()) != null)
                efectesSonors.Add(new EfecteSonor(linia));
            sr.Close();


            // ---- Afegim dades de prova --------------------------------------------

            //// Cançons
            //cancons.Add(new Canço("c001", "Bohemian Rhapsody", "Queen", 1975,
            //    new List<string> { "Rock", "Opera" }, "/music/bohemian.mp3", "Rock",
            //    Bitrate.Kbps128, new TimeSpan(0, 5, 55), true));

            //cancons.Add(new Canço("c002", "Blinding Lights", "The Weeknd", 2019,
            //    new List<string> { "Synth-pop" }, "/music/blinding.mp3", "Pop",
            //    Bitrate.Kbps192, new TimeSpan(0, 3, 20), true));

            //// Podcasts (amb tema multivalor)
            //podcasts.Add(new Podcast("p001", "Lex Fridman #400", "Lex Fridman", 2024,
            //    new List<string> { "AI", "Filosofia" }, "/pods/lex400.mp3", "Entrevista",
            //    Bitrate.Kbps128, new TimeSpan(2, 30, 0), false,
            //    TemaPodcast.Tecnologia | TemaPodcast.Futur));

            //podcasts.Add(new Podcast("p002", "El Món a RAC1", "Jordi Basté", 2023,
            //    new List<string> { "Actualitat" }, "/pods/mon.mp3", "Informació",
            //    Bitrate.Kbps96, new TimeSpan(1, 0, 0), false,
            //    TemaPodcast.Societat | TemaPodcast.Cultura));

            //// Audiolliures
            //audiolliures.Add(new Audiollibre("a001", "Sapiens", "Yuval Noah Harari", 2011,
            //    new List<string> { "Història", "Ciència" }, "/audio/sapiens.mp3", "No-ficció",
            //    Bitrate.Kbps128, new TimeSpan(15, 17, 0), false, "Derek Perkins", 20));

            //// Partitures
            //partitures.Add(new Partitura("pt001", "Moonlight Sonata", "Beethoven", 1801,
            //    new List<string> { "Clàssic" }, "/partituras/moonlight.pdf", "Clàssic",
            //    Bitrate.Kbps64, new TimeSpan(0, 15, 0), false, "Piano", 12));

            //// Efectes sonors
            //efectesSonors.Add(new EfecteSonor("e001", "Tro d'estiu", "SoundLib", 2020,
            //    new List<string> { "Natura", "Ambient" }, "/sfx/tro.wav", "Ambient",
            //    Bitrate.Kbps192, new TimeSpan(0, 0, 8), true, "Natura", false));

            //efectesSonors.Add(new EfecteSonor("e002", "Foc de llar", "SoundLib", 2021,
            //    new List<string> { "Natura", "Loop" }, "/sfx/foc.wav", "Ambient",
            //    Bitrate.Kbps192, new TimeSpan(0, 1, 0), true, "Natura", true));

            
            // -- Imprimir totes les llistes -------------------------------------
            Console.WriteLine("\n=== Catàleg complet ===");
            ImprimirLlista(cancons);
            ImprimirLlista(podcasts);
            ImprimirLlista(audiolliures);
            ImprimirLlista(partitures);
            ImprimirLlista(efectesSonors);

            // --------- Imprimir els 4 diccionaris -------------------------------
            Console.WriteLine("=== LOGOTIPS ===");
            ImprimirDiccionari(logotips);

            Console.WriteLine("\n=== DIAGRAMES ===");
            ImprimirDiccionari(diagrames);

            Console.WriteLine("\n=== FOTOGRAFIES ===");
            ImprimirDiccionari(fotografies);

            Console.WriteLine("\n=== ART DIGITAL ===");
            ImprimirDiccionari(artsDigitals);

            Console.WriteLine("\n=== PEL·LICULES ===");
            ImprimirDiccionari(pelicules);

            Console.WriteLine("\n=== DOCUMENTALS ===");
            ImprimirDiccionari(documentals);

            Console.WriteLine("\n=== SERIES ===");
            ImprimirDiccionari(series);




        }

        // Funció genèrica per imprimir qualsevol llista
        static void ImprimeixLlista<T>(List<T> llista)
        {
            if (llista.Count == 0)
            {
                Console.WriteLine("  (Llista buida)");
                return;
            }

            foreach (T element in llista)
            {
                Console.WriteLine($"  {element}");
            }
        }

        /// <summary>
        /// Imprimeix qualsevol llista genèrica fent servir ToString() de cada element.
        /// T no té restriccions: funciona amb Canco, Podcast, Audiollibre, Partitura, EfecteSonor…
        /// </summary>
        static void ImprimirLlista<T>(List<T> llista)
        {
            Console.WriteLine($"\n── Llista ({llista.Count} elements) ──");
            foreach (T element in llista)
            {
                Console.WriteLine($"  {element}");
            }
        }

        /// <summary>
        /// Muestra en la consola el número total d'elements, les claus i els valors de un diccionari especificat.
        /// </summary>
        /// <remarks>El metodo imprimex primer el recompte total de elements, seguit de totes las claus
        /// i després tots els valors.
        /// </remarks>
        /// <typeparam name="T">El tipo dels valors emmagatzemats en els diccionaris.</typeparam>
        /// <param name="diccionari">El diccionari dels quals les seves claus i valors s'imprimeixen. No pot ser null.</param>

        static void ImprimirDiccionari<T>(Dictionary<string, T> diccionari)
        {
            Console.WriteLine($"Total elements: {diccionari.Count}");

            Console.WriteLine("-- Claus --");
            foreach (string clau in diccionari.Keys)
            {
                Console.WriteLine(diccionari[clau]); // 
            }

            Console.WriteLine("-- Valors --");
            foreach (T valor in diccionari.Values)
            {
                Console.WriteLine(valor);
            }
        }
    }
}
