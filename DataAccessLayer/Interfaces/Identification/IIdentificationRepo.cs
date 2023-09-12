using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Identification
{
    public interface IIdentificationRepo
    {
        IEnumerable<Entities.Identification> ListAll();
        Task Add(Entities.Identification model);
        /*Task AddRange(Entities.Identification model);*/
        Task Update(Entities.Identification model);
        Task Delete(int id);
        Entities.Identification SelectById(int id);
    }
}
