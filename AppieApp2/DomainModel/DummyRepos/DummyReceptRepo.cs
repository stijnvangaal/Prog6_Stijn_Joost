using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyReceptRepo : IReceptRepo{
        List<Recept> recepten;

        public DummyReceptRepo() {
            recepten = new List<Recept>(){
                new Recept{ Id = 1, Naam = "BierPakket"},
                new Recept{ Id = 2, Naam = "Broodje Kaas"}
            };
        }

        public IEnumerable<Recept> GetAll() {
            return recepten;
        }

        public void Create(string name) {
            throw new NotImplementedException();
        }

        public void delete(int id) {
            throw new NotImplementedException();
        }

        public void Update(Recept obj) {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            throw new NotImplementedException();
        }
    }
}
