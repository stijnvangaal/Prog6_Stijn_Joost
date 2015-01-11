using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityReceptRepo : IReceptRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<Recept> GetAll() {
            return db.ReceptSet.ToList();
        }
        public Recept GetById(int id) {
            return db.ReceptSet.Find(id);
        }

        public void Add(string name) {
            db.ReceptSet.Add(new Recept { Naam = name });
            db.SaveChanges();
        }

        public void delete(int id) {
            db.ReceptSet.Remove(db.ReceptSet.Find(id));
        }
        public void Update(Recept obj, string Name) {
            if (db.ReceptSet.Find(obj.Naam).ReceptProduct != null) {
                var productRecepten = db.ReceptSet.Find(obj.Naam).ReceptProduct.ToList();
                db.ReceptSet.Add(new Recept { Naam = Name });
                foreach (var item in productRecepten) {
                    item.Recept = db.ReceptSet.Find(Name);
                    item.ReceptId = db.ReceptSet.Find(Name).Id;
                }
                db.ReceptSet.Find(Name).ReceptProduct = productRecepten;
            }


            db.ReceptSet.Find(obj.Naam).ReceptProduct.Clear();
            db.ReceptSet.Remove(obj);

            db.SaveChanges();
        }
       

        public void SaveChanges() {
            db.SaveChanges();
        }
        
    }
}
