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
        app.MapGet("person", () => new PersonModel("Lucas"));
    }
}