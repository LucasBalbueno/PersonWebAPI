using Microsoft.EntityFrameworkCore;
using Person.Models;

namespace Person.DataAccess;

// Db Context é a classe com todos os métodos para configurar o banco de dados através de código C#, sem precisar manipular o banco de dados manualmente
public class PersonContext : DbContext
{
    // O DbSet serve para criarmos a tabela, com base o Person Model chamada People
    public DbSet<PersonModel> People { get; set; }

    // Aqui criaremos a conexão com nosso banco de dados, nesse caso o SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Aqui iremos inserir a connection string de acordo com o banco de dados
        optionsBuilder.UseSqlite("Data Source=person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}