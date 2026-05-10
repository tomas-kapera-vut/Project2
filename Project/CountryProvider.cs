using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class CountryProvider : IDataProvider
{
    private readonly HttpClient _httpClient;

    public CountryProvider()
    {
        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(10); 
    }

    public async Task<List<Country>> FetchDataAsync()
    {
        string url = "https://restcountries.com/v3.1/all?fields=name,population,area";

        try
        {
            // Asynchronní volání HTTP API
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); 

            string json = await response.Content.ReadAsStringAsync();
            
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<List<Country>>(json, options);

            return result ?? new List<Country>();
        }
        catch (HttpRequestException ex)
        {
            // Zachycení chyb připojení
            throw new Exception($"Chyba připojení k API: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("Vypršel časový limit pro spojení se serverem (Timeout).");
        }
    }
}