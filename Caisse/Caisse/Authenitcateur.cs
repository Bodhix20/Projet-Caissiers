using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse
{
    internal class DataImport
    {
        /// <summary>
        /// Lien vers le document à decoder
        /// </summary>
        private string source;

        public DataImport() { }

        /// <summary>
        /// Constructeur de l'objet de décodage
        /// </summary>
        /// <param name="source"></param>
        public DataImport(string source)
        {
            this.source = source;
        }

        /// <summary>
        /// Renvoie le texte décodé vers le dictionnaire spécifié
        /// </summary>
        /// <param name="someDictionnary">Un dictionnaire</param>
        public void writeData(Dictionary<string, string> someDictionnary)
        {

            using (var reader = new StreamReader(this.source))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    for (int i = 0; i < values.Count(); i += 2)
                    {
                        someDictionnary.Add(values[i], values[i + 1]);
                    }
                }
            }


        }

        public void setSource(string newSource)
        {
            this.source = newSource;
        }
    }
}
