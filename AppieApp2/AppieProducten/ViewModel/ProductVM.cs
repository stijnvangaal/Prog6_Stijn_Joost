using DomainModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ProductVM : ViewModelBase{
        public Product _Product;

        public ProductVM() {
            _Product = new Product();
        }

        public ProductVM(Product product) {
            _Product = product;
        }

        public int Id {
            get { return _Product.Id; }
            set { _Product.Id = value;
            this.RaisePropertyChanged("Id");
            }
        }

        public string Naam {
            get { return _Product.Naam; }
            set { _Product.Naam = value;
            this.RaisePropertyChanged("Naam");
            }
        }

        public string AfdelingNaam {
            get { return _Product.AfdelingNaam; }
            set { _Product.AfdelingNaam = value;
            this.RaisePropertyChanged("AfdelingNaam");
            }
        }
    }
}
