using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.DummyRepos {
    public class DummyReceptProductRepo : IReceptProductRepo{
        List<ReceptProduct> lijst;

        public DummyReceptProductRepo() {
            lijst = new List<ReceptProduct>(){
                new ReceptProduct{ ReceptId = 1, ProductMerkId = 3, Aantal = 3, ProductMerk = new ProductMerk{ MerkNaam ="stuff1", Product = new Product{ Naam = "Bier"}, Prijs = 3.0}},
                new ReceptProduct{ ReceptId = 1, ProductMerkId = 4, Aantal = 2, ProductMerk = new ProductMerk{ MerkNaam ="stuff1", Product = new Product{ Naam = "Bier"}, Prijs = 1.5}},
                new ReceptProduct{ ReceptId = 1, ProductMerkId = 5, Aantal = 2, ProductMerk = new ProductMerk{ MerkNaam ="stuff2", Product = new Product{ Naam = "Bier"}, Prijs = 1.0}},
                new ReceptProduct{ ReceptId = 2, ProductMerkId = 1, Aantal = 1, ProductMerk = new ProductMerk{ MerkNaam ="stuff3", Product = new Product{ Naam = "Brood"}, Prijs = 0.75}},
                new ReceptProduct{ ReceptId = 2, ProductMerkId = 2, Aantal = 2, ProductMerk = new ProductMerk{ MerkNaam ="stuff4", Product = new Product{ Naam = "Kaas"}, Prijs = 1.0}}
            };
        }

        public IEnumerable<ReceptProduct> GetAll(int receptId) {
            List<ReceptProduct> temp = new List<ReceptProduct>();
            foreach (ReceptProduct r in lijst) {
                if (r.ReceptId == receptId) { temp.Add(r); }
            }
            return temp;
        }

        public void Create(int receptId, int productId, int aantal) {
            throw new NotImplementedException();
        }

        public void Delete(int receptId, int productId) {
            throw new NotImplementedException();
        }

        public void update(int receptId, int productId, int aantal) {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            throw new NotImplementedException();
        }
    }
}
