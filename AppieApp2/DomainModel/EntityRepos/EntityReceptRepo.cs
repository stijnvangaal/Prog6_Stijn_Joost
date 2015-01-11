using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityReceptRepo : IReceptRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<Recept> GetAll() {
            return db.ReceptSet;
        }

        public void Create(string name) {
            db.ReceptSet.Add(new Recept { Naam = name });
        }

        public void delete(int id) {
            db.ReceptSet.Remove(db.ReceptSet.Find(id));
        }

        public void Update(Recept obj) {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
