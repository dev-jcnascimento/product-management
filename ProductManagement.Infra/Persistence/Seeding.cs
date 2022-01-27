using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enum;
using ProductManagement.Domain.ValueObject;
using ProductManagement.Infra.Persistence;

public static class DbInitializer
{
    public static void Initialize(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ProductManagementContext>();
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }
            var user1 = new User(
                    new Name("Usuário1", "Teste1"),
                    new Email("teste1@teste1.com.br"),
                    new Password("123456"),
                    Roles.Admin);

            var user2 = new User(
                    new Name("Usuário2", "Teste2"),
                    new Email("teste2@teste2.com.br"),
                    new Password("123456"),
                    Roles.Employee);

            var user3 = new User(
                    new Name("Usuário3", "Teste3"),
                    new Email("teste3@teste3.com.br"),
                    new Password("123456"),
                    Roles.User);

            var product1 = new Product("Product Teste1", "Breve Descrição do Produto Teste 1", "Modelo Teste 1", "Marca Teste 1");
            var product2 = new Product("Product Teste2", "Breve Descrição do Produto Teste 2", "Modelo Teste 2", "Marca Teste 2");
            var product3 = new Product("Product Teste3", "Breve Descrição do Produto Teste 3", "Modelo Teste 3", "Marca Teste 3");

            var stock1 = new Stock(product1.Id, 7, StatusStock.Entrada, user2.Id);
            var stock2 = new Stock(product1.Id, 9, StatusStock.Entrada, user2.Id);
            var stock3 = new Stock(product1.Id, 5, StatusStock.Entrada, user1.Id);
            var stock4 = new Stock(product1.Id, 25, StatusStock.Entrada, user2.Id);
            var stock5 = new Stock(product1.Id, 15, StatusStock.Saida, user1.Id);
            var stock6 = new Stock(product1.Id, 8, StatusStock.Saida, user2.Id);
            var stock7 = new Stock(product2.Id, 2, StatusStock.Entrada, user1.Id);

            context.AddRangeAsync(user1, user2, user3, product1, product2, product3,
                                  stock1, stock2, stock3, stock4, stock5, stock6, stock7);
            context.SaveChanges();
        }
    }
}