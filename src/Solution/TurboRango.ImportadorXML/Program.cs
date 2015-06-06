using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exemplos

            Restaurante restaurante = new Restaurante();

            //restaurante.
            //Console.Write(restaurante.Contato.Site);
            Console.WriteLine(
                restaurante.Capacidade.HasValue ?
                    restaurante.Capacidade.Value.ToString() :
                    "oi"
                );

            restaurante.Nome = string.Empty + " ";

            Console.WriteLine(restaurante.Nome ?? "Nulo!!!");

            Console.WriteLine(!string.IsNullOrEmpty(restaurante.Nome.Trim()) ? "tem valor" : "não tem valor");

            var oQueEuGosto = "bacon";

            // var texto = String.Format("Eu gosto de \{oQueEuGosto}");
            var texto = String.Format("Eu gosto de {0}", oQueEuGosto);

            StringBuilder pedreiro = new StringBuilder();
            pedreiro.AppendFormat("Eu gosto de {0}", oQueEuGosto);
            pedreiro.Append("!!!!!!");

            object obj = "1";
            int a = Convert.ToInt32(obj);
            int convertido = 10;
            bool conseguiu = Int32.TryParse("1gdfgfd", out convertido);
            int res = 12 + a;

            Console.WriteLine(pedreiro);

            #endregion

            #region LINQ
            const string nomeArquivo = "restaurantes.xml";

            var restaurantesXML = new RestaurantesXML(nomeArquivo);
            var nomesAsc = restaurantesXML.OrdenarPorNomeAsc();
            var capacidadeMedia = restaurantesXML.CapacidadeMedia();
            var porCategoria = restaurantesXML.AgruparPorCategoria();
            var site = restaurantesXML.ObterSites();
            var apenasComUmRestaurante = restaurantesXML.ApenasComUmRestaurante();
            var todosRestaurantes = restaurantesXML.TodosRestaurantes().ToList();

            //var nomes = restaurantesXML.ObterNomes();
            //var capacidadeMedia = restaurantesXML.CapacidadeMedia();
            //var capacidadeMaxima = restaurantesXML.CapacidadeMaxima();

            #endregion

            #region ADO.NEt
            var connString = @"Data Source=.;Initial Catalog=TurboRango_dev;Integrated Security=True";
            var acessoAoBanco = new CarinhaQueManipulaOBanco(connString);

            acessoAoBanco.Inserir(new Contato { 
                Site = "www.dogao.gif",
                Telefone = "1234456789"
            });

            IEnumerable<Contato> contatos = acessoAoBanco.GetContatos();
            #endregion
        }
    }
}
