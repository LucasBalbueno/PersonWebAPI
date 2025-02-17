using Microsoft.AspNetCore.Mvc;

namespace Person.Models;

// Nesse arquivo iremos configurar um modelo do nosso Banco de Dados, ou seja, aqui iremos modelar o Banco de dados
public class PersonModel
{
    // Iremos inserir as propriedades do nosso Banco de Dados

    public PersonModel(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    
    // O Guid é uma tipo de Identificador unico que contem 23 caracteres e é básicamente impossível de se repetir, entretanto consome mais memória de processamento
    // O init ao invés do Set significa que quando chamarmos essa classe só iremos poder alterar essa propriedade uma unica vez
    public Guid Id { get; init; }
    
    // O string.Empty serve para já inicializarmos a propriedade Name como vazia, para não dar o aviso NullAble de propriedade nula
    // public string Name { get; private set; } = string.Empty;
    
    // O private set serve para apenas o model poder alterar/setar a propriedade.
    public string Name { get; private set; }
}