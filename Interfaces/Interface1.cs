using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Models;


namespace Eish.Interfaces
{
    public interface IRegisterable
    {
        void Add(Patient patient);
        Patient Search(string id);
        void Edit(string id);
        void Delete(string id);
    }


}
