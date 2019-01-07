using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.Map
{
    public class Club
    {
        public int Id { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}