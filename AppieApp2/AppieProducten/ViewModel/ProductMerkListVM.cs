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

        private ProductMerkVM _SelectedProductMerk;
        public ProductMerkVM SelectedProductMerk {
            get { return _SelectedProductMerk; }
            set { _SelectedProductMerk = value; }
        }

        // Repo Propertie

        private IProductMerkRepo PMRepo;

        // Command Properties
        public ICommand Sort { get; set; }
        public ICommand SearchProductMerkCommand { get; set; }

        private AfdelingVM _selectedAfdeling;
        private ProductVM _selectedProduct;
        private MerkVM _selectedMerk;

        public AfdelingVM selectedAfdeling {
            get { return _selectedAfdeling; }
            set { this._selectedAfdeling = value;
            _SelectedProductMerk = null;
            sortAll();
            }
        }
        public ProductVM selectedProduct {
            get { return _selectedProduct; }
            set { _selectedProduct = value;
            _SelectedProductMerk = null;
            sortAll();
            }
        }
        public MerkVM selectedMerk {
            get { return _selectedMerk; }
            set { _selectedMerk = value;
            _SelectedProductMerk = null;
            sortAll();
            } 
        }


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

            _selectedAfdeling = new AfdelingVM { Naam = "Leeg" };
            _selectedProduct = new ProductVM { Naam = "Leeg" };
            _selectedMerk = new MerkVM { Naam = "Leeg" };


            allProducten = new ObservableCollection<ProductMerkVM>(PMRepo.GetAll().ToList().Select(m => new ProductMerkVM(m)));
            SortedProducten = allProducten;
            ProductMerken = allProducten;

            Sort = new RelayCommand(sortAll);
            SearchProductMerkCommand = new RelayCommand(ActionSearchProductMerk);
        }


        public void sortAll() {
            //sorteer op afdeling
            ObservableCollection<ProductMerkVM> afdelingList = new ObservableCollection<ProductMerkVM>();
            if (selectedAfdeling != null) {
                if (selectedAfdeling.Naam != "Leeg") {
                foreach (ProductMerkVM p in allProducten) {
                        if (this.getAfdeling(p.ProductId) == _selectedAfdeling.Naam) {
                        afdelingList.Add(p);
                    }
                }
            }
            else { afdelingList = allProducten; }
            }
            else { afdelingList = allProducten; }

            //sorteer op product
            ObservableCollection<ProductMerkVM> productList = new ObservableCollection<ProductMerkVM>();
            if (selectedProduct != null) {
                if (selectedProduct.Naam != "Leeg") {
                foreach (ProductMerkVM p in afdelingList) {
                        if (this.getProductName(p.ProductId) == _selectedProduct.Naam) {
                        productList.Add(p);
                    }
                }
                }
                else { productList = afdelingList; }
            }
            else { productList = afdelingList; }

            //sorteer op merk
            ObservableCollection<ProductMerkVM> merkList = new ObservableCollection<ProductMerkVM>();
            if (selectedMerk != null) {
                if (selectedMerk.Naam != "Leeg") {
                foreach (ProductMerkVM p in productList) {
                        if (p.MerkNaam ==_selectedMerk.Naam) {
                        merkList.Add(p);
                    }
                }
                }
                else { merkList = productList; }
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
