using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ReceptVM : ViewModelBase{

        public Recept _Recept;

        public ReceptVM() {
            _Recept = new Recept();
        }

        public ReceptVM(Recept obj) {
            _Recept = obj;
        }

        public int Id {
            get { return _Recept.Id; }
            set {
                _Recept.Id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Naam {
            get { return _Recept.Naam; }
            set { 
                _Recept.Naam = value;
                RaisePropertyChanged(() => Naam);
            }
        }
    }
}
