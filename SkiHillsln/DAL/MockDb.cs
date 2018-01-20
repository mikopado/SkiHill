using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class MockDb : IDb
    {
        public ISet<Ski> Ski { get; set; }
        public ISet<Boot> Boots { get ;set; }
        public ISet<Helmet> Helmets { get; set; }
        public ISet<Binding> Bindings { get; set; }

        public MockDb()
        {
            Ski = new HashSet<Ski>
            {
                new Ski{Id=1, Brand="Atomic", Length=125, Model="ETL 125 R Ezy2", Category=SkiCategory.AllMountain, Price=260.95M },
                new Ski{Id=2, Brand="Atomic", Length=195, Model="Pro C2", Category=SkiCategory.CrossCountry, Price=144.95M },
                new Ski{Id=3, Brand="Amplid", Length=168, Model="Hill Bill 168", Category=SkiCategory.FreeRide, Price=408.95M },
                new Ski{Id=4, Brand="Völkl", Length=177, Model="Revolt 87", Category=SkiCategory.Freestyle, Price=408.95M },
                new Ski{Id=5, Brand="Head", Length=195, Model="World Cup Rebels iGS RD SW RP", Category=SkiCategory.Race, Price=664.95M },
                new Ski{Id=6, Brand="Armada", Length=178, Model="Invictus 108 TI", Category=SkiCategory.Touring, Price=620.95M }
            };

            Boots = new HashSet<Boot>
            {
                new Boot{Id=1, Brand="Salomon", Size=44, Model="Equipe 7 Classic Prolink", Category= BootCategory.CrossCountry, Price=99M },
                new Boot{Id=2, Brand="Fischer", Size=23, Model="RC4 70 JR Thermoshape", Category=BootCategory.Junior, Price=150M },
                new Boot{Id=3, Brand="Atomic", Size=30, Model="Hawx Ultra 130", Category=BootCategory.Man, Price=499.45M },
                new Boot{Id=4, Brand="Dynafit", Size=24, Model="Liner Neo PX CP", Category= BootCategory.SkiLiners, Price=103.95M },
                new Boot{Id=5, Brand="Lange", Size=27, Model="XT 130 LV Freetour", Category= BootCategory.SkiTouring, Price=498.95M },
                new Boot{Id=6, Brand="Atomic", Size=23, Model="Hawx Prime 90", Category=BootCategory.Woman, Price=323.95M }
            };

            Helmets = new HashSet<Helmet>
            {
                new Helmet{Id=1, Brand="Salewa", Size=62, Model="Vert", Category= HelmetCategory.SkiTouring, Price=121.95M },
                new Helmet{Id=2, Brand="Alpina", Size=55, Model="Carat LX", Category=HelmetCategory.Junior, Price=62.95M },
                new Helmet{Id=3, Brand="Alpina", Size=58, Model="Attelas Visor VHM", Category=HelmetCategory.Man, Price=279.45M },
                new Helmet{Id=4, Brand="Alpina", Size=55, Model="Carat L E Visor HM", Category= HelmetCategory.Woman, Price=118.95M },
                new Helmet{Id=5, Brand="Salomon", Size=56, Model="Mtn Patrol", Category= HelmetCategory.SkiTouring, Price=140.95M },
                new Helmet{Id=6, Brand="Dynafit", Size=62, Model="Dna Helmet", Category=HelmetCategory.SkiTouring, Price=197.95M }
            };

            Bindings = new HashSet<Binding>
            {
                new Binding{Id=1, Brand="Atomic", Size=90, Model="FFG 12++", Category= BindingCategory.Alpine, Price=134.95M },
                new Binding{Id=2, Brand="Head", Size=100, Model="ATTACK 2 11 GW", Category=BindingCategory.Alpine, Price=135M },
                new Binding{Id=3, Brand="Atomic", Size=1, Model="Prolink Pro Classic 85", Category=BindingCategory.CrossCountry, Price=44.95M },
                new Binding{Id=4, Brand="Salomon", Size=1, Model="Prolink Auto", Category= BindingCategory.CrossCountry, Price=35.95M },
                new Binding{Id=5, Brand="Atk", Size=86, Model="Race Raider 12 2.0", Category= BindingCategory.Touring, Price=492.45M },
                new Binding{Id=6, Brand="Diamir", Size=100, Model="Vipec Evo 12", Category=BindingCategory.Touring, Price=436.95M }
            };
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}