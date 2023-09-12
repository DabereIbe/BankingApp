using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.TransactionHistory
{
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private readonly AppDbContext db;

        public TransactionHistoryRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Entities.TransactionHistory model)
        {
            await db.TransactionHistory.AddAsync(model);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var objFromDB = await db.TransactionHistory.FindAsync(id);
            if (objFromDB.Id > 0)
            {
                db.TransactionHistory.Remove(objFromDB);
                await db.SaveChangesAsync();
            }
        }

        public IEnumerable<Entities.TransactionHistory> ListAll()
        {
            return db.TransactionHistory.ToList();
        }

        public Entities.TransactionHistory SelectById(int id)
        {
            return db.TransactionHistory.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task Update(Entities.TransactionHistory model)
        {
            db.TransactionHistory.Update(model);
            await db.SaveChangesAsync();
        }
    }
}
