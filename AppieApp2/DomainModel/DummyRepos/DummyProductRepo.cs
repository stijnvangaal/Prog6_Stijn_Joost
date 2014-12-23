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
                new Product{ Id = 1, Naam = "Kaas"},
                new Product{ Id = 2, Naam = "Brood"},
                new Product{ Id = 3, Naam = "Bier"},
                new Product{ Id = 4, Naam = "MeerBier"}
            };
        }

        public IEnumerable<Product> GetAll() {
            throw new NotImplementedException();
        }

        public Product GetById(int id) {
            foreach (Product p in producten) {
                if (p.Id == id) { return p; }
            }
            return null;
        }
    }
}
