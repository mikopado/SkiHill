using System;

namespace DAL
{
    public interface IDb : IDisposable
    {        
        int SaveChanges();
    }
}
