using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityAfdelingRepo : IAfdelingRepo {
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<Afdeling> GetAll() {
            return db.AfdelingSet.ToList();
        }

        public Afdeling GetByName(string Name) {
            return db.AfdelingSet.Find(Name);
        }

        public void Create(Afdeling obj) {
            db.AfdelingSet.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Afdeling obj) {
            db.AfdelingSet.Remove(obj);
            db.SaveChanges();
        }

        public void Update(Afdeling obj, string Name) {
            db.Entry(obj).Property(u => u.Naam).CurrentValue = Name;
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
