using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum AbonementType { HalfYearly, Yearly, Family, Gift}

    public class Abonement : Base<Abonement>
    {
        public string Number;
        public AbonementType Type;
        public double Price;
        public DateTime EndData;
    }
}
