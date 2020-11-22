using _01_ReadCustomSectionConsoleApp.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace _01_ReadCustomSectionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Read Custom Section from appsettings.json");
			Console.WriteLine();

			var builder = new ConfigurationBuilder();
			
			builder.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", false);

			IConfigurationRoot configuration = builder.Build();

			var starwarsConfig = new StarwarsConfig();

			IConfigurationSection section = configuration.GetSection("Starwars");

			section.Bind(starwarsConfig);

			Console.WriteLine($"Section Starwars");
			Console.WriteLine($"	|_ Side = {starwarsConfig.Side}");
			Console.WriteLine($"	|_ Quote = {starwarsConfig.Quote}");

			Console.WriteLine();
			Console.WriteLine($"Press any key to continue...");
			Console.ReadKey();


			
        }
    }
}
