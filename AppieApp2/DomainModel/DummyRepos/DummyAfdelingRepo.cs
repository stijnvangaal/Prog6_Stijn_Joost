using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    class DummyAfdelingRepo : IAfdelingRepo {
        private List<Afdeling> afdelingen;

        public DummyAfdelingRepo() {
            afdelingen = new List<Afdeling> {
                new Afdeling{ Naam = "Zuivel"},
                new Afdeling{ Naam = "Brood"},
                new Afdeling{ Naam = "Bier"}
            };
        }


        public IEnumerable<Afdeling> GetAll() {
            return afdelingen;
        }

        public Afdeling GetByName(string Name) {
            foreach (Afdeling a in afdelingen) {
                if (a.Naam == Name) { return a; }
            }
            return null;
        }

        public void Create(Afdeling obj) {
            afdelingen.Add(obj);
        }

        public void Delete(Afdeling obj) {
            afdelingen.Remove(obj);
        }

        public void Update(Afdeling obj, string Name) {
            afdelingen.Remove(obj);
            afdelingen.Add(new Afdeling { Naam = Name });
        }
    }
}
