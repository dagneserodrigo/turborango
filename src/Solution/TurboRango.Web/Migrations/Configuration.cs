namespace TurboRango.Web.Migrations
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TurboRango.Dominio;

    internal sealed class Configuration : DbMigrationsConfiguration<TurboRango.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TurboRango.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(TurboRango.Web.Models.ApplicationDbContext context)
        {
            context.Restaurantes.AddOrUpdate(
                p => p.Nome,
                new Restaurante
                {
                    Nome = "GARFÃO RESTAURANTE E PIZZARIA",
                    Capacidade = 100,
                    Categoria = Categoria.Comum,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Liberdade",
                        Logradouro = "Rua Sete de Setembro, 1045 - Liberdade",
                        Latitude = -29.712571,
                        Longitude = -51.13636
                    },
                    Contato = new Contato
                    {
                        Site = "www.garfao.com",
                        Telefone = "(51) 3587-7700"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Pizza de calabresa",
                        Valor = 8,
                        Ingredientes = "mollho de tomate, queijo, calabresa",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "SEMENTE",
                    Capacidade = 40,
                    Categoria = Categoria.CozinhaNatural,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Centro",
                        Logradouro = "Rua: Joaquim Pedro Soares, 633",
                        Latitude = -29.6812707,
                        Longitude = -51.1272292
                    },
                    Contato = new Contato
                    {
                        Telefone = "3595-5258"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Semente",
                        Valor = 8,
                        Ingredientes = "nasce arvore",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "OLÉ ARMAZÉM MEXICANO",
                    Capacidade = 30,
                    Categoria = Categoria.CozinhaMexicana,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Centro",
                        Logradouro = "Rua Gomes Portinho, 448",
                        Latitude = -29.682078,
                        Longitude = -51.125199
                    },
                    Contato = new Contato
                    {
                        Telefone = "3279-8828"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Taco",
                        Valor = 8,
                        Ingredientes = "pimenta",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "CHURRASCARIA PRIMAVERA",
                    Capacidade = 110,
                    Categoria = Categoria.Churrascaria,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Primavera",
                        Logradouro = "BR 116, 2554, Km 31",
                        Latitude = -29.693741,
                        Longitude = -51.144554
                    },
                    Contato = new Contato
                    {
                        Site = "www.grupoprimaveranh.com.br",
                        Telefone = "3595-8081"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Picanha",
                        Valor = 8,
                        Ingredientes = "assada pelo nunes",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "TAKESHI",
                    Capacidade = 35,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Pátria Nova",
                        Logradouro = "Rua Confraternização, 792",
                        Latitude = -29.698669,
                        Longitude = -51.130195
                    },
                    Contato = new Contato
                    {
                        Telefone = "3066-6660"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Sushi",
                        Valor = 8,
                        Ingredientes = "peixe cru",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "HAI SAIKÔ",
                    Capacidade = 75,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Mauá",
                        Logradouro = "Rua Gomes Portinho, 730",
                        Latitude = -29.684873,
                        Longitude = -51.122252
                    },
                    Contato = new Contato
                    {
                        Site = "www.haisaiko.com.br",
                        Telefone = "3593-5757"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Sushi",
                        Valor = 8,
                        Ingredientes = "peixe cru",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },

                new Restaurante
                {
                    Nome = "PICA-PAU LANCHES",
                    Capacidade = 30,
                    Categoria = Categoria.FastFood,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Rio Branco",
                        Logradouro = "Rua: José do Patrocínio, 880",
                        Latitude = -29.68339,
                        Longitude = -51.135376
                    },
                    Contato = new Contato
                    {
                        Site = "www.picapaulanches.com",
                        Telefone = "(51) 3593-8079"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "xis salda",
                        Valor = 20,
                        Ingredientes = "pão, queijo, hamburguer",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },
                new Restaurante
                {
                    Nome = "Teste",
                    Capacidade = 100,
                    Categoria = Categoria.Comum,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Liberdade",
                        Logradouro = "Rua Sete de Setembro, 1045 - Liberdade",
                        Latitude = -29.712571,
                        Longitude = -51.13636
                    },
                    Contato = new Contato
                    {
                        Site = "www.garfao.com",
                        Telefone = "(51) 3587-7700"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "asdas",
                        Valor = 5,
                        Ingredientes = "dsfsdf",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                },
                new Restaurante
                {
                    Nome = "Tesqwerqwrqwerte",
                    Capacidade = 100,
                    Categoria = Categoria.Comum,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Liberdade",
                        Logradouro = "Rua Sete de Setembro, 1045 - Liberdade",
                        Latitude = -29.712571,
                        Longitude = -51.13636
                    },
                    Contato = new Contato
                    {
                        Site = "www.garfao.com",
                        Telefone = "(51) 3587-7700"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "asdas",
                        Valor = 5,
                        Ingredientes = "dsfsdf",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lorem ipsum dolor sit amet"
                    }
                }
            );
        }
    }
}
