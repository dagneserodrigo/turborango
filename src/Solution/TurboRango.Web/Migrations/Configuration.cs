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
                    Nome = "GARF�O RESTAURANTE E PIZZARIA",
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
                        Nome = "Buffet livre",
                        Valor = 12,
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Grande variedade de comidas."
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
                        Nome = "Pizza de tofu e quiche de espinafre",
                        Valor = 6,
                        Ingredientes = "Tofu, queijo e epinafre",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Lanche vegetariano."
                    }
                },

                new Restaurante
                {
                    Nome = "OL� ARMAZ�M MEXICANO",
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
                        Nome = "Mojito",
                        Valor = 5,
                        Ingredientes = "Rum, suco de lim�o, hortl� e �gua com g�s",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Mi casa su casa"
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
                        Nome = "Espeto corrido",
                        Valor = 18,
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Grande variedade de carnes."
                    }
                },

                new Restaurante
                {
                    Nome = "TAKESHI",
                    Capacidade = 35,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Bairro = "P�tria Nova",
                        Logradouro = "Rua Confraterniza��o, 792",
                        Latitude = -29.698669,
                        Longitude = -51.130195
                    },
                    Contato = new Contato
                    {
                        Telefone = "3066-6660"
                    },
                    PratoDoDia = new PratoDoDia
                    {
                        Nome = "Yakisoba",
                        Valor = 8,
                        Ingredientes = "Macarr�o japones e legumes",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Macarr�o japon�s frito com legumes"
                    }
                },

                new Restaurante
                {
                    Nome = "HAI SAIK�",
                    Capacidade = 75,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Bairro = "Mau�",
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
                        Nome = "Missoshiro",
                        Valor = 4,
                        Ingredientes = "soja",
                        DataAtualizacao = DateTime.Now,
                        Descricao = "Sopa de soja."
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
                        Logradouro = "Rua: Jos� do Patroc�nio, 880",
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
                        Nome = "Xis fil� com fritas",
                        Valor = 10,
                        Ingredientes = "Hamburguer, alface, queijo, molho especial, cebola, picles em um p�o sem gergelim",
                        DataAtualizacao = DateTime.Now,
                    }
                }
            );
        }
    }
}
