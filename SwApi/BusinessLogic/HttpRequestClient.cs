using Newtonsoft.Json;
using SwApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwApi.BusinessLogic
{
    public static class HttpRequestClient
    {
        public static async Task<Ship[]> GetShipAsync(string path, HttpClient client)
        {
            List<ShipDTO> shipsDTO = new List<ShipDTO>();
            bool continueRequests = true;
            try
            {
                while (continueRequests)
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {

                        var testShips = await response.Content.ReadAsStringAsync();

                        var result = new RequestResult();
                        try
                        {
                            result = JsonConvert.DeserializeObject<RequestResult>(testShips);
                            // Add ships to the array
                            result.results.ForEach(s => shipsDTO.Add(s));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                            Console.ReadLine();
                        }
                        // Evaluate the need to make another query
                        continueRequests = result.next != null;
                        if (result.next != null)
                        {
                            path = result.next.Replace("https://swapi.co/", "");
                        }
                    }
                    else
                    {
                        continueRequests = false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ShipDTOToShipMapper mapper = new ShipDTOToShipMapper();
            List<Ship> ships = new List<Ship>();
            foreach (var ship in shipsDTO)
            {
                ships.Add(mapper.Map(ship));
            }

            return ships.ToArray();
        }
    }
}
