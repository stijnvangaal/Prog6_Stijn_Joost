using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IReceptRepo {

        IEnumerable<Recept> GetAll();
        void Create(string name);
        void delete(int id);
        void Update(Recept obj);
        void SaveChanges();
    }
}
