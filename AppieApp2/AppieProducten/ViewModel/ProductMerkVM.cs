using DomainModel;
using DomainModel.DummyRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;

namespace AppieProducten.ViewModel {
    public class ProductMerkVM : ViewModelBase {

        private ProductMerk _ProductMerk;

        //constructors
        public ProductMerkVM() {
            _ProductMerk = new ProductMerk();
        }

        public ProductMerkVM(ProductMerk product) {
            _ProductMerk = product;
            this.Product = new ProductVM(new DummyProductRepo().GetById(product.Id));
        }


        //properties

        public ProductVM Product { get; set; }

        public MerkVM Merk { get; set; }

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
