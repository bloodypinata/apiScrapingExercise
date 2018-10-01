using System;
using System.Text.RegularExpressions;
using SwApi.Models;

namespace SwApi.BusinessLogic
{
    class ShipDTOToShipMapper
    {
        static readonly int hoursInAYear = 8766;
        static readonly int hoursInAMonth = 730;
        static readonly int hoursInAWeek = 168;
        static readonly int hoursInADay = 24;
        public Ship Map(ShipDTO ship)
        {
            try {
                return new Ship
                {
                    Cargo_capacity = int.TryParse(ship.Cargo_capacity, out int resultCap) ? resultCap : 0,
                    Consumables = getConsumables(ship.Consumables),
                    Cost_in_credits = int.TryParse(ship.Cost_in_credits, out int resultCost) ? resultCost : 0,
                    Created = DateTimeOffset.Parse(ship.Created),
                    Crew = int.TryParse(ship.Crew, out int resultCrew) ? resultCrew : 0,
                    Edited = DateTimeOffset.Parse(ship.Edited),
                    Films = ship.Films,
                    Hyperdrive_rating = float.TryParse(ship.Hyperdrive_rating, out float resultHypRate) ? resultHypRate : 0.0f,
                    Length = float.TryParse(ship.Length, out float resultLength) ? resultLength : 0.0f,
                    Manufacturer = ship.Manufacturer,
                    Max_atmosphering_speed = getAtmosphereSpeed(ship.Max_atmosphering_speed),
                    MGLT = int.TryParse(ship.MGLT, out int resultMGLT) ? resultMGLT : 0,
                    Model = ship.Model,
                    Name = ship.Name,
                    Passengers = int.TryParse(ship.Passengers, out int resultPass) ? resultCap : 0,
                    Pilots = ship.Pilots,
                    Starship_class = ship.Starship_class,
                    Url = ship.Url
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Ship();
            }
        }

        private int getConsumables(string cons)
        {
            var consumable = cons.Split(" ");
            if (consumable.Length == 2)
            {
                switch (consumable[1])
                {
                    case "year":
                    case "years":
                        return int.Parse(consumable[0]) * hoursInAYear;

                    case "month":
                    case "months":
                        return int.Parse(consumable[0]) * hoursInAMonth;

                    case "week":
                    case "weeks":
                        return int.Parse(consumable[0]) * hoursInAWeek;

                    case "day":
                    case "days":
                        return int.Parse(consumable[0]) * hoursInADay;

                    case "hour":
                    case "hours":
                        return int.Parse(consumable[0]);

                    default:
                        return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private int getAtmosphereSpeed(string speed)
        {
            var aS = speed.Split(" ");
            if (aS.Length == 2)
            {
                return int.Parse(aS[0]);
            }
            else
            {
                return int.TryParse(Regex.Replace(speed, @"\D", ""), out int result) ? result : 0;
            }
        }
    }
}
