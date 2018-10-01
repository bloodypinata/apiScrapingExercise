using SwApi.Models;

namespace SwApi.BusinessLogic
{
    public static class Calculations
    {
        public static int GetResupplyCount(int distance, Ship ship)
        {
            // it uses it's total of consumables each time it travels this distance
            float efficency = ship.Consumables * ship.MGLT;

            // divide the distance by the efficency to find out how many times it is required to stop to resupply
            return (int)(distance / efficency);
        }
    }
}
