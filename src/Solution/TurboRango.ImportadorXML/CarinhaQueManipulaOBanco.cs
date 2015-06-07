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

        internal int InserirContato(Contato contato)
        {
            int ultimoId;
            using(var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "INSERT INTO [dbo].[Contato] ([Site],[Telefone]) output INSERTED.ID VALUES (@Site, @Telefone)";
                using (var inserirContato = new SqlCommand(comandoSql, connection))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site ?? (object)DBNull.Value;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone ?? (object)DBNull.Value;

                    connection.Open();
                    ultimoId = Convert.ToInt32(inserirContato.ExecuteScalar());
                }
                return ultimoId;
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

        internal int InserirLocalizacao(Localizacao localizacao)
        {
            int ultimoId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "INSERT INTO [dbo].[Localizacao] ([Bairro],[Logradouro],[Latitude],[Longitude]) output INSERTED.ID VALUES (@Bairro, @Logradouro, @Latitude, @Longitude)";
                using (var inserirLocalizacao = new SqlCommand(comandoSql, connection))
                {
                    inserirLocalizacao.Parameters.Add("@Bairro", SqlDbType.NVarChar).Value = localizacao.Bairro;
                    inserirLocalizacao.Parameters.Add("@Logradouro", SqlDbType.NVarChar).Value = localizacao.Logradouro;
                    inserirLocalizacao.Parameters.Add("@Latitude", SqlDbType.Float).Value = localizacao.Latitude;
                    inserirLocalizacao.Parameters.Add("@Longitude", SqlDbType.Float).Value = localizacao.Longitude;

                    connection.Open();
                    ultimoId = Convert.ToInt32(inserirLocalizacao.ExecuteScalar());
                }
                return ultimoId;
            }
        }

        internal void InserirRestaurante(Restaurante restaurante)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "INSERT INTO [dbo].[Restaurante] ([Capacidade],[Nome],[Categoria],[ContatoId],[LocalizacaoId]) output INSERTED.ID VALUES (@Capacidade, @Nome, @Categoria, @ContatoId, @LocalizacaoId)";
                using (var inserirRestaurante = new SqlCommand(comandoSql, connection))
                {
                    inserirRestaurante.Parameters.Add("@Capacidade", SqlDbType.Int).Value = restaurante.Capacidade;
                    inserirRestaurante.Parameters.Add("Nome", SqlDbType.NVarChar).Value = restaurante.Nome;
                    inserirRestaurante.Parameters.Add("Categoria", SqlDbType.NVarChar).Value = restaurante.Categoria;
                    inserirRestaurante.Parameters.Add("@ContatoId", SqlDbType.Int).Value = this.InserirContato(restaurante.Contato);
                    inserirRestaurante.Parameters.Add("@LocalizacaoId", SqlDbType.Int).Value = this.InserirLocalizacao(restaurante.Localizacao);

                    connection.Open();
                    int rowsResult = inserirRestaurante.ExecuteNonQuery();
                }
            }
            
        }
    }
}
