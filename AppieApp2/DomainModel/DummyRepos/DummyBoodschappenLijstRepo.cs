using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyBoodschappenLijstRepo : IBoodschappenLijstRepo{
        private List<BoodschappenLijst> boodschappenLijsten;

        public DummyBoodschappenLijstRepo() {
            boodschappenLijsten = new List<BoodschappenLijst> {
                new BoodschappenLijst{ Id = 1, TotaalPrijs = 19}
            };
        }

        public BoodschappenLijst GetById(int id) {
            foreach (BoodschappenLijst b in boodschappenLijsten) {
                if (b.Id == id) { return b; }
            }
            return null;
        }
    }
}
