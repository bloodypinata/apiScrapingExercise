using System;

namespace SwApi.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Starship_class { get; set; }
        public string Manufacturer { get; set; }
        public int Cost_in_credits { get; set; }
        public float Length { get; set; }
        public int Crew { get; set; }
        public int Passengers { get; set; }
        public int Max_atmosphering_speed { get; set; }
        public float Hyperdrive_rating { get; set; }
        public int MGLT { get; set; }
        public int Cargo_capacity { get; set; }
        public int Consumables { get; set; }
        public string[] Films { get; set; }
        public string[] Pilots { get; set; }
        public string Url { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Edited { get; set; }
    }
}
