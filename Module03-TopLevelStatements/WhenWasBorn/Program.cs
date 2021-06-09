using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

if (args.Length != 1)
{
    PrintHelp();
}

void PrintHelp()
{
    Console.WriteLine("Searches for Star Wars characters by using the Star Wars API.");
    Console.WriteLine("Usage:");
    Console.WriteLine("\tWhenWasBorn.exe <NAME>");
    Console.WriteLine("\tSearches for the character with the name NAME and prints out their name and birth year.");
    Environment.Exit(0);
} 

using HttpClient client = new HttpClient();
var requestUri = $"https://swapi.dev/api/people/?search={args[0]}";
var response = await client.GetFromJsonAsync<PersonsDTO>(requestUri);

if (response?.Count != 1)
    Console.WriteLine("There is no single answer to your question!");
else
{
    var person = response.Results.Single();
    Console.WriteLine($"{person.Name} was born {person.Birth_Year}.");
}

record PersonDTO(string Name, string Birth_Year);
record PersonsDTO(int Count, List<PersonDTO> Results);