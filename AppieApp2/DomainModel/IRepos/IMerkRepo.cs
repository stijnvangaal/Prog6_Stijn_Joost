using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IMerkRepo {

        List<Merk> GetAll();
        Merk GetByName(string name);
        void Add(Merk merk);
        void Delete(Merk merk);
    }
}
