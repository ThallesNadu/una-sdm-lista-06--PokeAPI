using System;
using System.Net;
using System.Net.Http.Json;
public sealed record Pokemon(
    int Id,
    string Name,
    int Height,
    int Weight
);

Console.Write("Digite o nome do Pokemon: ");

var input = (Console.ReadLine() ?? string.Empty)
    .Trim()
    .ToLowerInvariant();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Nome inválido.");
    return;
}

using var httpClient = new HttpClient()
{
    BaseAddress = new Uri("https://pokeapi.co/api/v2/")
};

try
{
    var response = await httpClient.GetAsync($"pokemon/{input}");

    if (response.StatusCode == HttpStatusCode.NotFound)
    {
        Console.WriteLine("Pokémon não encontrado.");
        return;
    }

    response.EnsureSuccessStatusCode();

    var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();

    if (pokemon is null)
    {
        Console.WriteLine("Erro ao desserializar.");
        return;
    }

    Console.WriteLine("\n=== Dados do Pokémon ===");
    Console.WriteLine($"Id: {pokemon.Id}");
    Console.WriteLine($"Nome: {pokemon.Name}");
    Console.WriteLine($"Altura: {pokemon.Height}");
    Console.WriteLine($"Peso: {pokemon.Weight}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}