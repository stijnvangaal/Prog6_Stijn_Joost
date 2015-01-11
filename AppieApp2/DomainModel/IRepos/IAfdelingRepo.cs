using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IAfdelingRepo {
        IEnumerable<Afdeling> GetAll();
        Afdeling GetByName(string Name);
        void Create(Afdeling obj);
        void Delete(Afdeling obj);
        void Update(Afdeling obj, string Name);
        void SaveChanges();
    }
}
