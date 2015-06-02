using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    public class RestaurantesXML
    {
        public string NomeArquivo { get; private set; }
        IEnumerable<XElement> restaurantes;

        /// <summary>
        /// Constrói RestaurantesXML a partir de um nome de arquivo.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo XML a ser manipulado.</param>
        public RestaurantesXML(string nomeArquivo)
        {
            this.NomeArquivo = nomeArquivo;
        }


        public IList<string> ObterNomes()
        {
            //var resultado = new List<string>();

            //var nodos = XDocument.Load(NomeArquivo).Descendants("restaurante");

            //foreach (var item in nodos)
            //{
            //    resultado.Add(item.Attribute("nome").Value);
            //}

            //return resultado;

            return XDocument.Load(NomeArquivo).Descendants("restaurante").Select(n => n.Attribute("nome").Value).OrderBy(n => n).ToList();
        }

        public double CapacidadeMedia()
        {
            return (
                from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
                select Convert.ToInt32(n.Attribute("capacidade").Value)
            ).Average();
        }

        public double CapacidadeMaxima()
        {
            return (
                from n in XDocument.Load(NomeArquivo).Descendants("restaurante")
                select Convert.ToInt32(n.Attribute("capacidade").Value)
            ).Max();
        }

        public IList<Restaurante> AgruparPorCategoria()
        {
            throw new NotImplementedException();
        }
    }
}
