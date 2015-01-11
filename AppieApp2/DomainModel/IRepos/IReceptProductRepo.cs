using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IReceptProductRepo {

        IEnumerable<ReceptProduct> GetAll(int receptId);
        void Create(int receptId, int productId, int aantal);
        void Delete(int receptId, int productId);
        void update(int receptId, int productId, int aantal);
        void SaveChanges();
    }
}
