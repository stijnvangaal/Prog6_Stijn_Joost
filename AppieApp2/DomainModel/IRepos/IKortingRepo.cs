using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IKortingRepo {

        IEnumerable<Korting> GetAll();
        Korting GetById(int id);
        void Create(Korting obj);
        void Delete(Korting obj);
        void Update(Korting obj, int id);
    }
}
