using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IMan
    {
        string Surname { get; set; }
        string PatronymicName { get; set; }
        GenderType Gender { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        int Age { get; set; }
    }
}
