using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class KortingVM : ViewModelBase{

        //properties
        private Korting _korting;

        //constructors
        public KortingVM() {
            _korting = new Korting();
        }

        public KortingVM(Korting korting) {
            _korting = korting;
        }

        public int Id {
            get { return _korting.Id; }
            set { 
                _korting.Id = value;
                RaisePropertyChanged(() => Id);
            }
        }
        public string KortingCode {
            get { return _korting.KortingCode; }
            set {
                _korting.KortingCode = value;
                RaisePropertyChanged(() => KortingCode);
            }
        }
        public System.DateTime BeginDatum {
            get { return _korting.BeginDatum; }
            set {
                _korting.BeginDatum = value;
                RaisePropertyChanged(() => BeginDatum);
            }
        }
        public System.DateTime EindDatum {
            get { return _korting.EindDatum; }
            set {
                _korting.EindDatum = value;
                RaisePropertyChanged(() => EindDatum);
            }
        }
        public double Percentage {
            get { return _korting.Percentage; }
            set {
                _korting.Percentage = value;
                RaisePropertyChanged(() => Percentage);
            }
        }
        public int ProductMerkId {
            get { return _korting.ProductMerkId; }
            set {
                _korting.ProductMerkId = value;
                RaisePropertyChanged(() => ProductMerkId);
            }
        }
    }
}
