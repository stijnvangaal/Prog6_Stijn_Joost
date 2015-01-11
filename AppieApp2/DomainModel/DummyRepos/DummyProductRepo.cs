using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyProductRepo  : IProductRepo{
        private List<Product> producten;

        public DummyProductRepo() {
            producten = new List<Product> {
                new Product{ Id = 1, Naam = "Kaas", AfdelingNaam = "Zuivel"},
                new Product{ Id = 2, Naam = "Brood", AfdelingNaam = "Brood"},
                new Product{ Id = 3, Naam = "Bier", AfdelingNaam = "Bier"},
                new Product{ Id = 4, Naam = "MeerBier", AfdelingNaam = "Bier"}
            };
        }

        public IEnumerable<Product> GetAll() {
            return producten;
        }

        public Product GetById(int id) {
            foreach (Product p in producten) {
                if (p.Id == id) { return p; }
            }
            return null;
        }


        public void SaveChanges() {
            throw new NotImplementedException();
        }
    }
}
