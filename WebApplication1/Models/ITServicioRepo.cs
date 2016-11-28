using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface ITServicioRepo
    {

        void Add(Servicio item);
        IEnumerable<Servicio> GetAll();
        Servicio Find(string key);
        Servicio Remove(string key);
        void Update(Servicio item);

    }
}