using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var apiKeyObj = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey");

            while (true)
            {
                Console.WriteLine("Give me your zip code or perish...");

                var zip = Console.ReadLine();

                var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

                var response = client.GetStringAsync(url).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                var temp = JObject.Parse(formattedResponse).GetValue("temp");

                Console.WriteLine($"The degrees of current are {temp} and that is in Fahrenheit of course, like who uses Celcius");
                Console.WriteLine();
                Console.WriteLine("Are you bored yet and want to leave me? I demand an answer!");
                Console.WriteLine();
                var input = Console.ReadLine();

                if (input.ToLower() == "yes")
                {
                    break;
                }
                if (input.ToLower() == "no")
                {
                    Console.WriteLine("How lovely, now give me a zip code you weirdo!");
                    Console.WriteLine();
                }


            }


        }
    }
}