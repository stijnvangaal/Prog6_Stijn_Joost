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
            db.SaveChanges();
        }

        public void Delete(Merk merk) {
            db.MerkSet.Remove(merk);
        }

        public void Update(Merk obj, string Name) {

            if (db.MerkSet.Find(obj.Naam).ProductMerk != null) {
                var productMerken = db.MerkSet.Find(obj.Naam).ProductMerk.ToList();
                db.MerkSet.Add(new Merk { Naam = Name });
                foreach (var item in productMerken) {
                    item.Merk = db.MerkSet.Find(Name);
                    item.MerkNaam = Name;
                }
                db.MerkSet.Find(Name).ProductMerk = productMerken;
            }


            db.MerkSet.Find(obj.Naam).ProductMerk.Clear();
            db.MerkSet.Remove(obj);

            db.SaveChanges();
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
