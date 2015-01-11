using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IReceptRepo {

        IEnumerable<Recept> GetAll();
        Recept GetById(int id);
        void Add(string name);
        void delete(int id);
        void Update(Recept obj, string Name);
        void SaveChanges();
    }
}
