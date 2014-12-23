using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IProductMerkRepo {

        IEnumerable<ProductMerk> GetAll();

        ProductMerk GetById(int id);
    }
}
