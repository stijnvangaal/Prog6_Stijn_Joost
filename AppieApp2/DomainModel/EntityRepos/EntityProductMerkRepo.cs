using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityProductMerkRepo : IProductMerkRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<ProductMerk> GetAll() {
            return db.ProductMerkSet;
        }

        public ProductMerk GetById(int id) {
            return db.ProductMerkSet.Find(id);
        }


        public void SaveChanges() {
            db.SaveChanges();
        }


        public void Create(ProductMerk obj) {
            db.ProductMerkSet.Add(obj);
            db.SaveChanges();
        }

        public void Delete(ProductMerk obj) {
            db.MerkSet.Find(obj.MerkNaam).ProductMerk.Remove(obj);
            db.ProductSet.Find(obj.ProductId).ProductMerk.Remove(obj);
            db.ProductMerkSet.Remove(obj);
            db.SaveChanges();
        }
    }
}
