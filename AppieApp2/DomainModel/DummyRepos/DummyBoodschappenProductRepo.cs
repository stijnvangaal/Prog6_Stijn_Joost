using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyBoodschappenProductRepo : IBoodschappenProductRepo{

        private List<BoodschappenProduct> boodschappen;

        public DummyBoodschappenProductRepo() {
            boodschappen = new List<BoodschappenProduct>{
                new BoodschappenProduct{ BoodschappenLijstId = 1, ProductMerkId = 1, Aantal = 1},
                new BoodschappenProduct{ BoodschappenLijstId = 1, ProductMerkId = 2, Aantal = 1},
                new BoodschappenProduct{ BoodschappenLijstId = 1, ProductMerkId = 3, Aantal = 2}
            };
        }

        public IEnumerable<BoodschappenProduct> GetAllById(int id) {
            List<BoodschappenProduct> temp = new List<BoodschappenProduct>();
            foreach (BoodschappenProduct b in boodschappen) {
                if (b.BoodschappenLijstId == id) { temp.Add(b); }
            }
            return temp;
        }
    }
}
