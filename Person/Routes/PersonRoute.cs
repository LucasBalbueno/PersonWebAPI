using Microsoft.EntityFrameworkCore;
using Person.DataAccess;
using Person.Models;

namespace Person.Routes;

// Nesse arquivo ficará todas as rotas e métodos HTTPS da nossa aplicação;
// Essa classe pode ser static pois não iremos instanciar ela;
public static class PersonRoute
{
    // Quando a classe é static os métodos dela também devem ser
    // Aqui usamos Extension Methods
    public static void PersonRoutes(this WebApplication app)
    {
        // Usando as minimals apis temos acesso ao map group, onde podemos controlar diversas rotas
        var route = app.MapGroup("person");
        
        // Criando o método POST
        route.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.name);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });
        
        // Criando método GET
        route.MapGet("", async (PersonContext context) =>
        {
            var people = await context.People.ToListAsync();
            return Results.Ok((people));
        }); 
        
        // Criando método Put
        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null) return Results.NotFound();
            
            person.ChangeName(req.name);
            await context.SaveChangesAsync();

            return Results.Ok(person);
        });
        
        // Criando método Delete
        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null) return Results.NotFound();

            person.SetInactive();
            await context.SaveChangesAsync();
            return Results.Ok(person);
        });
    }
}