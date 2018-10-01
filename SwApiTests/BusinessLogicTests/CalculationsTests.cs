using Xunit;
using SwApi.Models;
using SwApi.BusinessLogic;

namespace SwApiTests.BusinessLogicTests
{
    public class CalculationsTests
    {
        [Fact]
        public void ValidateCalculations()
        {
            var ship = new Ship {
                Consumables = 10,
                MGLT = 10
            };
            var distance = 1000;

            var result = Calculations.GetResupplyCount(distance, ship);

            Assert.Equal(10, result);

        }
    }
}
