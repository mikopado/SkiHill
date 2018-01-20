using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Helmet
    {
        public int Id { get; set; }
        public HelmetCategory Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }   
        
    }
}