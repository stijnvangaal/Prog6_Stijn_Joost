using DomainModel;
using DomainModel.DummyRepos;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppieProducten.ViewModel {
    public class BoodschappenProductVM : ViewModelBase{

        private BoodschappenProduct _BoodschappenProduct;

        private BoodschappenLijst _BoodschappenLijst;

        //constructors
        public BoodschappenProductVM() {
            this._BoodschappenProduct = new BoodschappenProduct();
        }

        public BoodschappenProductVM(BoodschappenProduct product) {
            this._BoodschappenProduct = product;
            this.ProductMerk = new ProductMerkVM(new DummyProductMerkRepo().GetById(product.ProductMerkId));
            this._BoodschappenLijst = new DummyBoodschappenLijstRepo().GetById(product.BoodschappenLijstId);
        }

        //properties
        public int BoodschappenLijstId {
            get { return _BoodschappenProduct.BoodschappenLijstId; }
            set { this._BoodschappenProduct.BoodschappenLijstId = value;
            RaisePropertyChanged(() => BoodschappenLijstId);
            }
        }

        public int ProductMerkId {
            get { return _BoodschappenProduct.ProductMerkId; }
            set {
                this._BoodschappenProduct.ProductMerkId = value;
                RaisePropertyChanged(() => ProductMerkId);
            }
        }

        public int Aantal {
            get { return _BoodschappenProduct.Aantal; }
            set {
                this._BoodschappenProduct.Aantal = value;
                RaisePropertyChanged(() => Aantal);
                RaisePropertyChanged(() => PrijsProducten);
            }
        }

        public ProductMerkVM ProductMerk { get; set; }

        public double PrijsProducten { 
            get { return (ProductMerk.Prijs * Aantal); }
            set { ProductMerk.Prijs = value;
            RaisePropertyChanged(() => PrijsProducten);
            }
        }
    }
}
