using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class MerkVM : ViewModelBase {

        private Merk _Merk;

        public MerkVM() {
            _Merk = new Merk();
        }

        public MerkVM(Merk merk) {
            _Merk = merk;
        }

        public string Naam {
            get { return _Merk.Naam; }
            set {
                _Merk.Naam = value;
                RaisePropertyChanged("Naam");
            }
        }
    }
}
