using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    public class CarinhaQueManipulaOBanco
    {
        private string connectionString;
        public CarinhaQueManipulaOBanco(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Inserir(Contato contato)
        {
            using(var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "INSERT INTO [dbo].[Contato] ([Site],[Telefone]) VALUES (@Site, @Telefone)";
                using (var inserirContato = new SqlCommand(comandoSql, connection))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone;

                    connection.Open();
                    int resultado = inserirContato.ExecuteNonQuery();
                }
            }
        }

        internal IEnumerable<Contato> GetContatos()
        {
            IList<Contato> contatos = new List<Contato>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "SELECT [Site],[Telefone] FROM [TurboRango_dev].[dbo].[Contato] (nolock)";
                using (var lerContatos = new SqlCommand(comandoSql, connection))
                {
                    connection.Open();

                    var reader = lerContatos.ExecuteReader();

                    while (reader.Read())
                    {
                        contatos.Add(new Contato
                        {
                            Site = reader.GetString(0),
                            Telefone = reader.GetString(1),
                        });
                    }
                }
                return contatos;
            }
        }
    }
}
