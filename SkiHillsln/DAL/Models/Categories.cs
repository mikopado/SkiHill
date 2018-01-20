using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public enum SkiCategory
    {
        
        AllMountain,
        FreeRide,
        Freestyle,
        Race,
        Touring,
        CrossCountry
    }

    public enum BindingCategory
    {
        Touring,
        Alpine,
        CrossCountry
    }

    public enum BootCategory
    {
        CrossCountry,
        SkiTouring,
        SkiLiners,
        Man,
        Junior,
        Woman
    }

    public enum HelmetCategory
    {
        Man,
        Woman,
        Junior,
        SkiTouring        
    }
    
}