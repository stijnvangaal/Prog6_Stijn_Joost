using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityBoodschappenProductRepo : IBoodschappenProductRepo {
        AppieDBContainer db = new AppieDBContainer();
        public IEnumerable<BoodschappenProduct> GetAllById(int id) {
            List<BoodschappenProduct> temp = new List<BoodschappenProduct>();
            foreach (BoodschappenProduct b in db.BoodschappenProductSet) {
                if (b.BoodschappenLijstId == id) { temp.Add(b); }
            }
            return temp;
        }
    }
}
