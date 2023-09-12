using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.TransactionHistory
{
    public interface ITransactionHistoryRepo
    {
        IEnumerable<Entities.TransactionHistory> ListAll();
        Task Add(Entities.TransactionHistory model);
        /*Task AddRange(Entities.Identification model);*/
        Task Update(Entities.TransactionHistory model);
        Task Delete(int id);
        Entities.TransactionHistory SelectById(int id);
    }
}
