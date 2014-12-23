using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppieProducten.ViewModels {
    public class ProductMerkVM : ViewModelBase{

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
                RaisePropertyChanged();
            }
        }
    }
}
