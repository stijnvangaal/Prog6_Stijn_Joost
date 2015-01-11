using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AppieProducten.ViewModel {
    public class ProductMerkListVM : ViewModelBase {

        public ObservableCollection<ProductMerkVM> allProducten { get; set; }

        public ObservableCollection<ProductMerkVM> SortedProducten { get; set; }

        public ObservableCollection<ProductMerkVM> ProductMerken { get; set; }

        // Selected Properties
        public ProductMerkVM SelectedProduct { get; set; }

        private int _selectedProductId;
        public int SelectedProductId {
            get {
                return this._selectedProductId;
            }
            set {
                this._selectedProductId = value;
                this.ProductMerken = new ObservableCollection<ProductMerkVM>(new DummyProductRepo().GetById(_selectedProductId).ProductMerk.ToList().Select(m => new ProductMerkVM(m)));
                this.RaisePropertyChanged("_afdelingNaam");
            }
        }

        // Repo Propertie
        private IProductMerkRepo PMRepo;

        // Command Properties
        public ICommand Sort { get; set; }
        public ICommand SearchProductMerkCommand { get; set; }

        //sorteerStrings
        public string AfdelingNaam { get; set; }
        public string ProductNaam { get; set; }
        public string MerkNaam { get; set; }

        // Prijs Propertie
        //public double ProductMerkPrijs {
        //    get {
        //        return this.SelectedProduct.Prijs;
        //    }
        //    set {
        //        this.SelectedProduct.Prijs = value;
        //        this.RaisePropertyChanged("ProductMerkPrijs");
        //    }
        //}

        // Search Properties
        private string _searchProductMerk;
        public string SearchProductMerk {
            get {
                return this._searchProductMerk;
            }
            set {
                this._searchProductMerk = value;
                this.RaisePropertyChanged("_searchProductMerk");
            }
        }

        public ProductMerkListVM() {
            PMRepo = new DummyProductMerkRepo();

            allProducten = new ObservableCollection<ProductMerkVM>(PMRepo.GetAll().ToList().Select(m => new ProductMerkVM(m)));
            SortedProducten = allProducten;
            ProductMerken = allProducten;

            Sort = new RelayCommand(sortAll);
            SearchProductMerkCommand = new RelayCommand(ActionSearchProductMerk);
        }


        public void sortAll() {
            //sorteer op afdeling
            ObservableCollection<ProductMerkVM> afdelingList = new ObservableCollection<ProductMerkVM>();

            if (AfdelingNaam != null && AfdelingNaam != "Leeg") {
                foreach (ProductMerkVM p in allProducten) {
                    if (this.getAfdeling(p.ProductId) == this.AfdelingNaam) {
                        afdelingList.Add(p);
                    }
                }
            }
            else { afdelingList = allProducten; }

            //sorteer op product
            ObservableCollection<ProductMerkVM> productList = new ObservableCollection<ProductMerkVM>();

            if (ProductNaam != null && ProductNaam != "Leeg") {
                foreach (ProductMerkVM p in afdelingList) {
                    if (this.getProductName(p.ProductId) == this.ProductNaam) {
                        productList.Add(p);
                    }
                }
            }
            else { productList = afdelingList; }

            //sorteer op merk
            ObservableCollection<ProductMerkVM> merkList = new ObservableCollection<ProductMerkVM>();

            if (MerkNaam != null && MerkNaam != "Leeg") {
                foreach (ProductMerkVM p in productList) {
                    if (p.MerkNaam == this.MerkNaam) {
                        merkList.Add(p);
                    }
                }
            }
            else { merkList = productList; }

            this.SortedProducten = merkList;
            RaisePropertyChanged("SortedProducten");
        }

        public String getAfdeling(int productId) {
            return new DummyProductRepo().GetById(productId).AfdelingNaam;
        }

        public String getProductName(int productId) {
            return new DummyProductRepo().GetById(productId).Naam;
        }

        private void ActionSearchProductMerk() {
            throw new NotImplementedException();
        }
    }
}
