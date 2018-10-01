using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwApi.BusinessLogic;
using SwApi.Models;

namespace SwApi
{
    class Program
    {
        static int megaLights = 0;
        static HttpClient client = new HttpClient();
        static bool verboseOperation = false;
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                RunApp(args[0]);
            }
            else if (args.Length == 2)
            {
                if (args[1].Equals("-v"))
                {
                    verboseOperation = true;
                    RunApp(args[0]);
                }
                else
                {
                    Console.WriteLine("Please see README.txt for usage\nInvalid input");
                }
            }
            else
            {
                Console.WriteLine("Please see README.txt for usage\nNo input");
            }
            Console.ReadLine();
        }

        static void RunApp(string arg)
        {
            if (int.TryParse(arg, out int input) && input > 0)
            {
                megaLights = input;
                client.BaseAddress = new Uri("https://swapi.co/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                RunAsync().GetAwaiter().GetResult();
            }
            else if (input <= 0)
            {
                Console.WriteLine("Please see README.txt for usage\nShips cannot travel a negative distance");
            }
            else
            {
                Console.WriteLine("Please see README.txt for usage\nFailed to parse input");
            }
        }

        static async Task RunAsync()
        {
            var shipsUnableToCalc = new List<string>();
            try
            {
                Ship[] ships = await HttpRequestClient.GetShipAsync("api/starships/?format=json", client);
                if (ships.Length > 0)
                {
                    foreach(var ship in ships)
                    {
                        if (ship.MGLT > 0)
                        {
                            Console.WriteLine(ship.Name + ": " +  Calculations.GetResupplyCount(megaLights, ship));
                        }
                        else
                        {
                            shipsUnableToCalc.Add(ship.Name);
                        }
                    }

                    if (verboseOperation)
                    {
                        Console.WriteLine("\nUnable to calculate resupply frequence for the following ships:");
                        foreach (var s in shipsUnableToCalc)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
                else
                {
                    throw new Exception("No Ships were found\nMove along");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //private static async Task<Ship[]> GetShipAsync(string path)
        //{
        //    List<ShipDTO> shipsDTO = new List<ShipDTO>();
        //    bool continueRequests = true;
        //    try
        //    {
        //        while (continueRequests)
        //        {
        //            HttpResponseMessage response = await client.GetAsync(path);
        //            if (response.IsSuccessStatusCode)
        //            {

        //                var testShips = await response.Content.ReadAsStringAsync();

        //                var result = new RequestResult();
        //                try
        //                {
        //                    result = JsonConvert.DeserializeObject<RequestResult>(testShips);
        //                    // Add ships to the array
        //                    result.results.ForEach(s => shipsDTO.Add(s));
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine(e.Message);

        //                    Console.ReadLine();
        //                }
        //                // Evaluate the need to make another query
        //                continueRequests = result.next != null;
        //                if (result.next != null)
        //                {
        //                    path = result.next.Replace("https://swapi.co/", "");
        //                }
        //            }
        //            else
        //            {
        //                continueRequests = false;
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    ShipDTOToShipMapper mapper = new ShipDTOToShipMapper();
        //    List<Ship> ships = new List<Ship>();
        //    foreach (var ship in shipsDTO)
        //    {
        //        ships.Add(mapper.Map(ship));
        //    }

        //    return ships.ToArray();
        //}
    }
}
