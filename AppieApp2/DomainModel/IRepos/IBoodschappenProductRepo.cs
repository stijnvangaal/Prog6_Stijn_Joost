using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IBoodschappenProductRepo {

        IEnumerable<BoodschappenProduct> GetAllById(int id);
    }
}
