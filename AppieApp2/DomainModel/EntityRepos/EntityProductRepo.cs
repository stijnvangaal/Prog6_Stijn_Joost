using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityProductRepo : IProductRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<Product> GetAll() {
            return db.ProductSet;
        }

        public Product GetById(int id) {
            return db.ProductSet.Find(id);
        }

        public void Create(Product obj) {
            db.ProductSet.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Product obj) {
            var productmerken = db.ProductSet.Find(obj.Naam).ProductMerk.ToList();

            foreach (var item in productmerken) {
                db.ProductMerkSet.Remove(item);
            }

            db.ProductSet.Find(obj.Naam).ProductMerk.Clear();
            db.ProductSet.Remove(obj);
            db.SaveChanges();
        }

        public void Update(Product obj, string Name) {
            db.Entry(obj).Property(u => u.Naam).CurrentValue = Name;
            db.SaveChanges();
        }

        public void SaveChanges() {
            db.SaveChanges();
        }


        public void AddAfdeling(Product obj, string afName) {
            db.Entry(obj).Property(u => u.AfdelingNaam).CurrentValue = afName;
            db.AfdelingSet.Find(afName).Product.Add(obj);
            db.SaveChanges();
        }

        public void RemoveAfdeling(Product obj, string afName) {
            db.Entry(obj).Property(u => u.AfdelingNaam).CurrentValue = null;
            db.AfdelingSet.Find(afName).Product.Remove(obj);
            db.SaveChanges();
        }
    }
}
