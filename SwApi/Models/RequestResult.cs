using System.Collections.Generic;

namespace SwApi.Models
{
    class RequestResult
    {
        public string count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<ShipDTO> results { get; set; }
    }
}
