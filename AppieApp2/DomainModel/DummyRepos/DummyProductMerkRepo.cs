using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyProductMerkRepo : IProductMerkRepo{

        private List<ProductMerk> producten;

        public DummyProductMerkRepo() {
            producten = new List<ProductMerk>{
                new ProductMerk{ Id = 1, ProductId = 1, MerkNaam = "Basic", Prijs= 5.20},
                new ProductMerk{ Id = 2, ProductId = 2, MerkNaam = "Appie", Prijs= 3.80},
                new ProductMerk{ Id = 3, ProductId = 3, MerkNaam = "Bitchin", Prijs = 0.10},
                new ProductMerk{ Id = 4, ProductId = 3, MerkNaam = "Hertog Jan", Prijs = 1.50},
                new ProductMerk{ Id = 5, ProductId = 4, MerkNaam = "Hertog Jan", Prijs = 1.70}
            };
        }

        public IEnumerable<ProductMerk> GetAll() {
            return producten;
        }

        public ProductMerk GetById(int id) {
            foreach (ProductMerk p in producten) {
                if (p.Id == id) { return p; }
            }
            return null;
        }


        public void SaveChanges() {
            throw new NotImplementedException();
        }


        public void Create(ProductMerk obj) {
            throw new NotImplementedException();
        }

        public void Delete(ProductMerk obj) {
            throw new NotImplementedException();
        }
    }
}
