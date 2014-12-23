using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.IRepos {
    public interface IBoodschappenLijstRepo {
        BoodschappenLijst GetById(int id);
    }
}
