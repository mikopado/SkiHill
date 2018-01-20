using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DAL.Models
{
    public class Ski
    {
        public int Id { get; set; }
        public SkiCategory Category { get; set; }
        public string Brand { get; set; }       
        public string Model { get; set; }        
        public double Length { get; set; }        
        public decimal Price { get; set; }


    }
}