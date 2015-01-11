using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IProductRepo {
        IEnumerable<Product> GetAll();

        Product GetById(int id);
        void SaveChanges();
    }
}
