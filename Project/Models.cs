using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// Třída pro jméno státu 
public class CountryName
{
    [JsonPropertyName("common")]
    public string Common { get; set; }
}

// Třída stát
public class Country
{
    [JsonPropertyName("name")]
    public CountryName Name { get; set; }

    [JsonPropertyName("population")]
    public long Population { get; set; }

    [JsonPropertyName("area")]
    public double Area { get; set; }
}

public interface IDataProvider
{
    Task<List<Country>> FetchDataAsync();
}