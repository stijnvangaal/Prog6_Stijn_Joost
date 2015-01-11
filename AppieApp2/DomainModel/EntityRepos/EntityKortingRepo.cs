using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityKortingRepo : IKortingRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<Korting> GetAll() {
            return db.KortingSet;
        }

        public Korting GetById(int id) {
            return db.KortingSet.Find(id);
        }

        public void Create(Korting obj) {
            db.KortingSet.Add(obj);
        }

        public void Delete(Korting obj) {
            db.KortingSet.Remove(obj);
        }

        public void Update(Korting obj, int id) {
            throw new NotImplementedException();
        }


        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
