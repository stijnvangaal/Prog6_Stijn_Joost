using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ReceptProductVM : ViewModelBase{

        private ReceptProduct _ReceptProduct;

        public ReceptProductVM() {
            _ReceptProduct = new ReceptProduct();
        }

        public ReceptProductVM(ReceptProduct obj) {
            _ReceptProduct = obj;
        }

        public int ReceptId {
            get { return _ReceptProduct.ReceptId; }
            set { 
                _ReceptProduct.ReceptId = value;
                RaisePropertyChanged(() => ReceptId);
            }
        }

        public int ProductId {
            get { return _ReceptProduct.ProductMerkId; }
            set {
                _ReceptProduct.ProductMerkId = value;
                RaisePropertyChanged(() => ProductId);
            }
        }

        public int Aantal {
            get { return _ReceptProduct.Aantal; }
            set {
                _ReceptProduct.Aantal = value;
                RaisePropertyChanged(() => Aantal);
            }
        }
        public ProductMerk ProductMerk {
            get { return _ReceptProduct.ProductMerk; }
            set { _ReceptProduct.ProductMerk = value;
            RaisePropertyChanged(() => ProductMerk);
            }
        }

        public double Total {
            get { return ProductMerk.Prijs * Aantal; }
        }
    }
}
