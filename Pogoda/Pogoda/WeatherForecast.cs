using System;
using System.IO;
using System.Net;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string miasto = "Warszawa";
        string apiKey = "TWÓJ_API_KEY"; // Tutaj wprowadŸ swój klucz API OpenWeatherMap

        try
        {
            double temperatura = PobierzTemperature(miasto, apiKey);
            Console.WriteLine($"Aktualna temperatura w {miasto} wynosi {temperatura} stopni Celsiusza.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wyst¹pi³ b³¹d: {ex.Message}");
        }
    }

    static double PobierzTemperature(string miasto, string apiKey)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={miasto}&appid={apiKey}&units=metric";

        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();

        using (Stream dataStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            dynamic danePogodowe = JsonSerializer.Deserialize<dynamic>(responseFromServer);
            double temperatura = Convert.ToDouble(danePogodowe["main"]["temp"]);
            return temperatura;
        }
    }
}