using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyMerkRepo : IMerkRepo{

        private List<Merk> merken;

        public DummyMerkRepo() {
            merken = new List<Merk>() {
                new Merk{ Naam = "Basic"},
                new Merk{ Naam = "Appie"},
                new Merk{ Naam = "Bitchin"},
                new Merk{ Naam = "Hertog Jan"}
            };
        }

        public List<Merk> GetAll() {
            return merken;
        }

        public Merk GetByName(string name) {
            foreach (Merk m in merken) {
                if (m.Naam == name) { return m; }
            }
            return null;
        }

        public void Add(Merk merk) {
            merken.Add(merk);
        }

        public void Delete(Merk merk) {
            merken.Remove(merk);
        }


        public void SaveChanges() {
            throw new NotImplementedException();
        }


        public void Update(Merk merk, string Name) {
            throw new NotImplementedException();
        }
    }
}
