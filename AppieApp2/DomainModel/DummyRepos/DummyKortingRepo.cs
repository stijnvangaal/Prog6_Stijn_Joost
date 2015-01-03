using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyKortingRepo : IKortingRepo{

        private List<Korting> kortingen;

        public DummyKortingRepo() {
            kortingen = new List<Korting>() {
                new Korting{ Id = 1, KortingCode="bier", Percentage = 0.5, ProductMerkId = 4, BeginDatum = new DateTime(2014,12,30), EindDatum = new DateTime(2015,2,5)},
                new Korting{ Id = 1, KortingCode="kaas", Percentage = 0.2, ProductMerkId = 1, BeginDatum = new DateTime(2014,12,30), EindDatum = new DateTime(2015,2,5)},
                new Korting{ Id = 1, KortingCode="baas", Percentage = 0.1, ProductMerkId = 4, BeginDatum = new DateTime(2014,2,11), EindDatum = new DateTime(2014,2,12)}
            };
        }

        public IEnumerable<Korting> GetAll() {
            return kortingen;
        }

        public Korting GetById(int id) {
            foreach (Korting k in kortingen) {
                if (k.Id == id) { return k; }
            }
            return null;
        }

        public void Create(Korting obj) {
            kortingen.Add(obj);
        }

        public void Delete(Korting obj) {
            kortingen.Remove(obj);
        }

        public void Update(Korting obj, int id) {
            throw new NotImplementedException();
        }
    }
}
