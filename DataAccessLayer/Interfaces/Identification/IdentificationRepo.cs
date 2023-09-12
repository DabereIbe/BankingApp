using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Identification
{
    class IdentificationRepo : IIdentificationRepo
    {
        private readonly AppDbContext db;

        public IdentificationRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task Add(Entities.Identification model)
        {
            await db.Identification.AddAsync(model);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var objFromDB = await db.Identification.FindAsync(id);
            if (objFromDB.Id > 0)
            {
                db.Identification.Remove(objFromDB);
                await db.SaveChangesAsync();
            }
        }

        public IEnumerable<Entities.Identification> ListAll()
        {
            return db.Identification.ToList();
        }

        public Entities.Identification SelectById(int id)
        {
            return db.Identification.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task Update(Entities.Identification model)
        {
            db.Identification.Update(model);
            await db.SaveChangesAsync();
        }
    }
}
