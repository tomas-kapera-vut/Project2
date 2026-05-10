using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("--- Analyzátor států světa ---");
        
        // Využití polymorfismu
        IDataProvider dataProvider = new CountryProvider();
        CountryAnalyzer analyzer = new CountryAnalyzer();

        Console.WriteLine("\nStahuji data o všech státech z API. Prosím čekejte...");

        try
        {
            // Await asynchronní operace
            List<Country> countries = await dataProvider.FetchDataAsync();

            if (countries.Count == 0)
            {
                Console.WriteLine("Nepodařilo se stáhnout žádná data.");
                return;
            }

            Console.WriteLine($"Úspěšně staženo {countries.Count} států.\n");

            // Zpracování dat
            double avgPopulation = analyzer.CalculateAveragePopulation(countries);
            var largest = analyzer.GetLargestCountryByArea(countries);
            var smallest = analyzer.GetSmallestCountryByArea(countries);

            // Výpis výsledků
            Console.WriteLine("--- Výsledky analýzy ---");
            Console.WriteLine($"Průměrná populace státu: {Math.Round(avgPopulation):N0} obyvatel");
            
            if (largest != null)
                Console.WriteLine($"Největší rozloha: {largest.Name.Common} ({largest.Area:N0} km²)");
            
            if (smallest != null)
                Console.WriteLine($"Nejmenší rozloha: {smallest.Name.Common} ({smallest.Area:N0} km²)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[CHYBA APLIKACE]: {ex.Message}");
        }

        Console.WriteLine("\nStiskněte libovolnou klávesu pro ukončení...");
        Console.ReadKey();
    }
}