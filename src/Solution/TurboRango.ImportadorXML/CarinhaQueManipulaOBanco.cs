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

        private int InserirContato(Contato contato)
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

        private int InserirLocalizacao(Localizacao localizacao)
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

        internal void Remover(int id)
        {
            int contatoId = this.GetContatoId(id);
            int localizacaoId = this.GetLocalizacaoId(id);
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "DELETE FROM [dbo].[Restaurante] WHERE [Id] = @Id";
                using (var excluirRestaurante = new SqlCommand(comandoSql, connection))
                {
                    excluirRestaurante.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    connection.Open();

                    excluirRestaurante.ExecuteNonQuery();
                }
            }
            RemoverContato(contatoId);
            RemoverLocalizacao(localizacaoId);
        }

        private void RemoverContato(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "DELETE FROM [dbo].[Contato] WHERE [Id] = @Id";
                using (var excluirContato = new SqlCommand(comandoSql, connection))
                {
                    excluirContato.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    connection.Open();

                    excluirContato.ExecuteNonQuery();
                }
            }
        }

        private void RemoverLocalizacao(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "DELETE FROM [dbo].[Localizacao] WHERE [Id] = @Id";
                using (var excluirLocalizacao = new SqlCommand(comandoSql, connection))
                {
                    excluirLocalizacao.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    connection.Open();

                    excluirLocalizacao.ExecuteNonQuery();
                }
            }
        }

        internal IEnumerable<Restaurante> GetRestaurantes()
        {
            IList<Restaurante> restaurantes = new List<Restaurante>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "SELECT r.Capacidade, r.Nome, r.Categoria, c.Site, c.Telefone, l.Bairro, l.Logradouro, l.Latitude, l.Longitude FROM Restaurante r inner join Contato c ON r.Id = c.Id inner join Localizacao l ON r.Id = l.Id";
                using (var lerRestaurantes = new SqlCommand(comandoSql, connection))
                {
                    connection.Open();

                    var reader = lerRestaurantes.ExecuteReader();

                    while (reader.Read())
                    {
                        restaurantes.Add(new Restaurante
                        {
                            Capacidade = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Categoria = (Categoria)Enum.Parse(typeof(Categoria), reader.GetString(2), ignoreCase: true),
                            Contato = new Contato
                            {
                                Site = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Telefone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            },
                            Localizacao = new Localizacao
                            {
                                Bairro = reader.GetString(5),
                                Logradouro = reader.GetString(6),
                                Latitude = reader.GetDouble(7),
                                Longitude = reader.GetDouble(8),
                            },
                        });
                    }
                }
                return restaurantes;
            }
        }

        internal void Atualizar(int id, Restaurante restaurante)
        {
            int contatoId = this.GetContatoId(id);
            int localizacaoId = this.GetLocalizacaoId(id);
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "UPDATE [dbo].[Restaurante] SET [Capacidade] = @Capacidade, [Nome] = @Nome, [Categoria] = @Categoria WHERE [Id] = @Id";
                using (var atualizarRestaurante = new SqlCommand(comandoSql, connection))
                {
                    atualizarRestaurante.Parameters.Add("@Capacidade", SqlDbType.NVarChar).Value = restaurante.Capacidade;
                    atualizarRestaurante.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = restaurante.Nome;
                    atualizarRestaurante.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = restaurante.Categoria;
                    atualizarRestaurante.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    
                    connection.Open();
                    int resultado = atualizarRestaurante.ExecuteNonQuery();
                }
            }
            AtualizarContato(contatoId, restaurante);
            AtualizarLocalizacao(localizacaoId, restaurante);
        }

        private void AtualizarContato(int contatoId, Restaurante restaurante)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "UPDATE [dbo].[Contato] SET [Site] = @Site,[Telefone] = @Telefone WHERE [Id] = @Id";
                using (var atualizarContato = new SqlCommand(comandoSql, connection))
                {
                    atualizarContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = restaurante.Contato.Site;
                    atualizarContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = restaurante.Contato.Telefone;
                    atualizarContato.Parameters.Add("@Id", SqlDbType.Int).Value = contatoId;

                    connection.Open();
                    atualizarContato.ExecuteNonQuery();
                }
            }
        }
        private void AtualizarLocalizacao(int localizacaoId, Restaurante restaurante)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "UPDATE [dbo].[Localizacao] SET [Bairro] = @Bairro,[Logradouro] = @Logradouro,[Latitude] = @Latitude,[Longitude] = @Longitude WHERE [Id] = @Id";
                using (var atualizarContato = new SqlCommand(comandoSql, connection))
                {
                    atualizarContato.Parameters.Add("@Bairro", SqlDbType.NVarChar).Value = restaurante.Localizacao.Bairro;
                    atualizarContato.Parameters.Add("@Logradouro", SqlDbType.NVarChar).Value = restaurante.Localizacao.Logradouro;
                    atualizarContato.Parameters.Add("@Latitude", SqlDbType.NVarChar).Value = restaurante.Localizacao.Latitude;
                    atualizarContato.Parameters.Add("@Longitude", SqlDbType.NVarChar).Value = restaurante.Localizacao.Longitude;
                    atualizarContato.Parameters.Add("@Id", SqlDbType.Int).Value = localizacaoId;

                    connection.Open();
                    atualizarContato.ExecuteNonQuery();
                }
            }
        }

        private int GetContatoId(int id)
        {
            int contatoId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "SELECT [ContatoId] FROM [TurboRango_dev].[dbo].[Restaurante] WHERE [Id] = @id";
                using(var lerContatoId = new SqlCommand(comandoSql, connection))
                {
                    lerContatoId.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    connection.Open();

                    contatoId = Convert.ToInt32(lerContatoId.ExecuteScalar());
                }
                return contatoId;
            }
            
        }

        private int GetLocalizacaoId(int id)
        {
            int localizacaoId;
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "SELECT [LocalizacaoId] FROM [TurboRango_dev].[dbo].[Restaurante] WHERE [Id] = @id";
                using (var lerLocalizacaoId = new SqlCommand(comandoSql, connection))
                {
                    lerLocalizacaoId.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    connection.Open();

                    localizacaoId = Convert.ToInt32(lerLocalizacaoId.ExecuteScalar());
                }
                return localizacaoId;
            }
        }
    }
}
