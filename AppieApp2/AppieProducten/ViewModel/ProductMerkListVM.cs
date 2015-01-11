using DomainModel.DummyRepos;
using DomainModel.EntityRepos;
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

        // List Properties
        public ObservableCollection<ProductMerkVM> allProductMerken { get; set; }

        public ObservableCollection<ProductMerkVM> SortedProducten { get; set; }

        public ObservableCollection<ProductMerkVM> ProductMerken { get; set; }



        // Selected Properties
        private ProductVM _selectedProductId;
        public ProductVM SelectedProductId {
            get {
                return this._selectedProductId;
            }
            set {
                this._selectedProductId = value;
                this.ProductMerken = new ObservableCollection<ProductMerkVM>(new EntityProductRepo().GetById(_selectedProductId.Id).ProductMerk.ToList().Select(m => new ProductMerkVM(m)));
                this.selectedMerk = null;
                this.RaisePropertyChanged(() => SelectedProductId);
                this.RaisePropertyChanged(() => ProductMerken);
            }
        }

        private MerkVM _selectedMerkList;
        public MerkVM SelectedMerkList {
            get {
                return this._selectedMerkList;
            }
            set {
                this._selectedMerkList = value;
                RaisePropertyChanged(() => SelectedMerkList);
            }
        }


        private ProductMerkVM _SelectedProductMerk;
        public ProductMerkVM SelectedProductMerk {
            get { return _SelectedProductMerk; }
            set { _SelectedProductMerk = value;
            RaisePropertyChanged(() => SelectedProductMerk);
            }
        }

        // Repo Propertie

        private IProductMerkRepo PMRepo;

        // Command Properties
        public ICommand Sort { get; set; }
        public ICommand SearchProductMerkCommand { get; set; }
        public ICommand AddProductMerkCommand { get; set; }
        public ICommand RemoveProductenCommand { get; set; }
        public ICommand ToepassenCommand { get; set; }
        public ICommand LeegMakenCommand { get; set; }


        // HoofdScherm Selection Properties
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
        private double _productMerkPrijs;
        public double ProductMerkPrijs {
            get {
                return this._productMerkPrijs;
            }
            set {
                this._productMerkPrijs = value;
                this.RaisePropertyChanged(()=> ProductMerkPrijs);
            }
        }

        // Search Properties
        private string _searchProductMerk;
        public string SearchProductMerk {
            get {
                return this._searchProductMerk;
            }
            set {
                this._searchProductMerk = value;
                this.RaisePropertyChanged(()=> SearchProductMerk);
            }
        }

        public ProductMerkListVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                PMRepo = new DummyProductMerkRepo();
            }
            else {
                PMRepo = new EntityProductMerkRepo();
            }

            _selectedAfdeling = new AfdelingVM { Naam = "Leeg" };
            _selectedProduct = new ProductVM { Naam = "Leeg" };
            _selectedMerk = new MerkVM { Naam = "Leeg" };


            allProductMerken = new ObservableCollection<ProductMerkVM>(PMRepo.GetAll().ToList().Select(m => new ProductMerkVM(m)));
            SortedProducten = allProductMerken;
            ProductMerken = allProductMerken;

            Sort = new RelayCommand(sortAll);
            SearchProductMerkCommand = new RelayCommand(ActionSearchProductMerk);
            AddProductMerkCommand = new RelayCommand(ActionAddProductMerk, CanAddProductMerk);
            RemoveProductenCommand = new RelayCommand(ActionRemoveProductMerk, CanRemoveProductMerk);
            ToepassenCommand = new RelayCommand(ActionToepassen);
            LeegMakenCommand = new RelayCommand(ActionLeegMaken, CanLeegMaken);
        }


        public void sortAll() {
            //sorteer op afdeling
            ObservableCollection<ProductMerkVM> afdelingList = new ObservableCollection<ProductMerkVM>();
            if (selectedAfdeling != null) {
                if (selectedAfdeling.Naam != "Leeg") {
                foreach (ProductMerkVM p in allProductMerken) {
                        if (this.getAfdeling(p.ProductId) == _selectedAfdeling.Naam) {
                        afdelingList.Add(p);
                    }
                }
            }
            else { afdelingList = allProductMerken; }
            }
            else { afdelingList = allProductMerken; }

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
            if (ViewModelBase.IsInDesignModeStatic) {
                return new DummyProductRepo().GetById(productId).AfdelingNaam;
            }
            else {
                return new EntityProductRepo().GetById(productId).AfdelingNaam;
            }
        }

        public String getProductName(int productId) {
            if (ViewModelBase.IsInDesignModeStatic) {
                return new DummyProductRepo().GetById(productId).Naam;
            }
            else {
                return new EntityProductRepo().GetById(productId).Naam;
            }
        }

        private void ActionSearchProductMerk() {
            var searchedlist = new ObservableCollection<ProductMerkVM>();
            if (SearchProductMerk == "") {
                searchedlist = allProductMerken;
            } else {
                foreach (var item in allProductMerken) {
                    if (item.MerkNaam.ToLower().Contains(SearchProductMerk.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            ProductMerken = searchedlist;
            RaisePropertyChanged(() => ProductMerken);
        }

        private void ActionAddProductMerk() {
            ProductMerkVM temp = new ProductMerkVM { ProductId = SelectedProductId.Id, MerkNaam = SelectedMerkList.Naam, Prijs = ProductMerkPrijs };
            allProductMerken.Add(temp);
            ProductMerken.Add(temp);
            RaisePropertyChanged(() => ProductMerken);
        }

        private bool CanAddProductMerk() {
            if (SelectedProductId == null) {
                return false;
            } else if (SelectedMerkList == null) {
                return false;
            } else if (SelectedProductId._Product.ProductMerk.Count() != 0) {
                if (SelectedMerkList._Merk.ProductMerk.Count() != 0) {
                    return false;
                }
                return true;
            }
            else {
                return true;
            }
        }

        private void ActionRemoveProductMerk() {
            allProductMerken.Remove(SelectedProductMerk);
            ProductMerken.Remove(SelectedProductMerk);
            SelectedProductMerk = new ProductMerkVM();
            RaisePropertyChanged(() => ProductMerken);
        }

        private bool CanRemoveProductMerk() {
            if (SelectedProductMerk == null) {
                return false;
            } else {
                return true;
            }
        }

        public void ActionToepassen() {
            var dbList = PMRepo.GetAll().ToList().Select(m => new ProductMerkVM(m)).ToList();
            var myList = allProductMerken.ToList();
            List<ProductMerkVM> newDbList = dbList.ToList();
            List<ProductMerkVM> newMyList = myList.ToList();

            foreach (ProductMerkVM dbProductMerk in dbList) {
                foreach (ProductMerkVM myProductMerk in myList) {
                    if (dbProductMerk.Id == myProductMerk.Id) {
                        newDbList.Remove(dbProductMerk);
                        newMyList.Remove(myProductMerk);
                        break;
                    }
                }
            }

            foreach (ProductMerkVM dbProductMerk in newDbList) { PMRepo.Delete(dbProductMerk._ProductMerk); }
            foreach (ProductMerkVM myProductMerk in newMyList) { PMRepo.Create(myProductMerk._ProductMerk); }
            PMRepo.SaveChanges();
        }

        public void ActionLeegMaken() {
            var dbList = PMRepo.GetAll().ToList().Where(m => m.MerkNaam == SelectedMerkList.Naam && m.ProductId == SelectedProductId.Id).Select(m => new ProductMerkVM(m)).ToList();
            foreach (ProductMerkVM dbProductMerk in dbList) { PMRepo.Delete(dbProductMerk._ProductMerk); }
            PMRepo.SaveChanges();
        }

        private bool CanLeegMaken() {
            if (SelectedProductId == null) {
                return false;
            }
            if (SelectedMerkList == null) {
                return false;
            } else {
                return true;
            }
        }
        
    }
}
