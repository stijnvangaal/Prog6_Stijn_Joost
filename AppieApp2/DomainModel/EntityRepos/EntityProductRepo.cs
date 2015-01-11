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


        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
