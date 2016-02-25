using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Base<T> where T:Base<T>
    {
        public static Dictionary<Guid, T> Items = new Dictionary<Guid,T>();

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
            Items.Add(Id,(T)this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
