using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class AfdelingVM : ViewModelBase{

        private Afdeling _Afdeling;

        public string Naam {
            get { return _Afdeling.Naam; }
            set { _Afdeling.Naam = value;
            this.RaisePropertyChanged("Naam");
            } 
        }

        public AfdelingVM() {
            _Afdeling = new Afdeling();
        }

        public AfdelingVM(Afdeling af) {
            _Afdeling = af;
        }
    }
}
