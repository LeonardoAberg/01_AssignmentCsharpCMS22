using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AssignmentCsharpCMS22.Services
{
    // Klass för min filhantering
    // Spara/skriva och hämta/läs-funktion, save och read.
    // Gör den static då ingen instansiering krävs. Skall endast köras/göra det de ska.
    // Adderar try-catch som förhindrar felmeddelanden och att programmet crashar. Catch-del 1: omöjligt att hitta, Catch-del 2: tom array/lista
    // Skapar en metod för att spara till ett json-dokument och en för att läsa från json-dokumentet.

    internal class FileManager
    {
        internal static void Save(string filePath, string text)

        {
            try
            {
                using var sw = new StreamWriter(filePath);
                sw.WriteLine(text);
            }

            catch
            {
                Console.WriteLine("Omöjligt att hitta");
                Console.ReadKey();
            }
        }
        internal static string Read(string filePath)
        {
            try
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }

            catch { }
            return "[]";
        }
    }
}
