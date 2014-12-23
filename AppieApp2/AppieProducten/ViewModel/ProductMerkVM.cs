using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;

namespace AppieProducten.ViewModel {
    class ProductMerkVM : ViewModelBase {

        private ProductMerk _ProductMerk;

        public ProductMerkVM() {
            _ProductMerk = new ProductMerk();
        }

        public ProductMerkVM(ProductMerk product) {
            _ProductMerk = product;
        }

        public int Id {
            get { return _ProductMerk.Id; }
            set {
                _ProductMerk.Id = value;
                RaisePropertyChanged(null);
            }
        }

        public int ProductId {
            get { return _ProductMerk.ProductId; }
            set {
                _ProductMerk.ProductId = value;
                RaisePropertyChanged(null);
            }
        }

        public string MerkNaam {
            get { return _ProductMerk.MerkNaam; }
            set {
                _ProductMerk.MerkNaam = value;
                RaisePropertyChanged(null);
            }
        }

        public double Prijs {
            get { return _ProductMerk.Prijs; }
            set {
                _ProductMerk.Prijs = value;
                RaisePropertyChanged(null);
            }
        }
    }
}
