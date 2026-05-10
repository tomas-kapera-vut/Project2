using System.Collections.Generic;
using System.Linq;

public class CountryAnalyzer
{
    // Výpočet průměrné populace
    public double CalculateAveragePopulation(List<Country> countries)
    {
        if (countries == null || countries.Count == 0) return 0;
        return countries.Average(c => c.Population);
    }

    // Vyhledání největšího státu 
    public Country GetLargestCountryByArea(List<Country> countries)
    {
        if (countries == null || countries.Count == 0) return null;
        return countries.OrderByDescending(c => c.Area).First();
    }

    // Vyhledání nejmenšího státu 
    public Country GetSmallestCountryByArea(List<Country> countries)
    {
        if (countries == null || countries.Count == 0) return null;
        return countries.Where(c => c.Area > 0).OrderBy(c => c.Area).First();
    }
}