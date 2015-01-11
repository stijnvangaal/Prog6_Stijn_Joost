using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityMerkRepo : IMerkRepo{
        AppieDBContainer db = new AppieDBContainer();

        public List<Merk> GetAll() {
            return db.MerkSet.ToList();
        }

        public Merk GetByName(string name) {
            return db.MerkSet.Find(name);
        }

        public void Add(Merk merk) {
            db.MerkSet.Add(merk);
        }

        public void Delete(Merk merk) {
            db.MerkSet.Remove(merk);
        }


        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
