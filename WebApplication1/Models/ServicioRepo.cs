using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ServicioRepo : ITServicioRepo
    {
        private static ConcurrentDictionary<string,Servicio> _todos =  new ConcurrentDictionary<string, Servicio>();

        public ServicioRepo()
        {
            Add(new Servicio { id = "1" , descripcion = "servicio", costo="45", IdCte="1" });
        }


        public IEnumerable<Servicio> GetAll()
        {
            return _todos.Values;
        }


        public void Add(Servicio item)
        {
            item.id = Guid.NewGuid().ToString();
            _todos[item.id] = item;
        }

        public Servicio Find(string key)
        {
            Servicio item;
            _todos.TryGetValue(key, out item);
            return item;
        }

       

        public Servicio Remove(string key)
        {
            Servicio item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(Servicio item)
        {
            _todos[item.id] = item;
        }
    }
}