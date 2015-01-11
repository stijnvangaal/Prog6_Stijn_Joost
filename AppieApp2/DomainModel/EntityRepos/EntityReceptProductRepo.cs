using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityReceptProductRepo : IReceptProductRepo{
        AppieDBContainer db = new AppieDBContainer();

        public IEnumerable<ReceptProduct> GetAll(int receptId) {
            List<ReceptProduct> temp = new List<ReceptProduct>();
            foreach (ReceptProduct r in db.ReceptProductSet) {
                if (r.ReceptId == receptId) { temp.Add(r); }
            }
            return temp;
        }

        public void Create(int receptId, int productId, int aantal) {
            db.ReceptProductSet.Add(new ReceptProduct { ReceptId = receptId, ProductMerkId = productId, Aantal = aantal });
        }

        public void Delete(int receptId, int productId) {
            db.ReceptProductSet.Remove(db.ReceptProductSet.Find(receptId, productId));
        }

        public void update(int receptId, int productId, int aantal) {
            throw new NotImplementedException();         
        }

        public void SaveChanges() {
            db.SaveChanges();
        }
    }
}
