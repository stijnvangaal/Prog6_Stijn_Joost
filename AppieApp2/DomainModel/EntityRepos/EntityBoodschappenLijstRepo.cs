using DomainModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.EntityRepos {
    public class EntityBoodschappenLijstRepo : IBoodschappenLijstRepo {
        AppieDBContainer db = new AppieDBContainer();
        public BoodschappenLijst GetById(int id) {
            return db.BoodschappenLijstSet.Find(id);
        }
    }
}
