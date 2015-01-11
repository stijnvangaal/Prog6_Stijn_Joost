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
            var producten = db.AfdelingSet.Find(obj.Naam).Product.ToList();

            foreach (var item in producten) {
                item.Afdeling = null;
                item.AfdelingNaam = null;
            }

            db.AfdelingSet.Find(obj.Naam).Product.Clear();
            db.AfdelingSet.Remove(obj);
            db.SaveChanges();
        }

        public void Update(Afdeling obj, string Name) {

            if (db.AfdelingSet.Find(obj.Naam).Product != null) {
                var producten = db.AfdelingSet.Find(obj.Naam).Product.ToList();
                db.AfdelingSet.Add(new Afdeling { Naam = Name });
                foreach (var item in producten) {
                    item.Afdeling = db.AfdelingSet.Find(Name);
                    item.AfdelingNaam = Name;
                }
                db.AfdelingSet.Find(Name).Product = producten;
            }


            db.AfdelingSet.Find(obj.Naam).Product.Clear();
            db.AfdelingSet.Remove(obj);

            db.SaveChanges();
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
