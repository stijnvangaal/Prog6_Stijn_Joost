using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IProductRepo {
        IEnumerable<Product> GetAll();

        Product GetById(int id);
        void Create(Product obj);
        void AddAfdeling(Product obj, string afName);
        void Delete(Product obj);
        void RemoveAfdeling(Product obj, string afName);
        void Update(Product obj, string Name);
        void SaveChanges();
    }
}
