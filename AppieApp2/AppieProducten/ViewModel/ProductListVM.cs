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
    public class ProductListVM : ViewModelBase{

        // List properties
        public ObservableCollection<ProductVM> Producten { get; set; }

        public ObservableCollection<ProductVM> AllProducten { get; set; }

        public ObservableCollection<ProductVM> ComboBoxProducten { get; set; }

        public ObservableCollection<ProductVM> AfdelingProducten { get; set; }

        // Selected Properties
        private ProductVM _selectedProduct;
        public ProductVM SelectedProduct {
            get {
                return this._selectedProduct;
            }
            set {
                this._selectedProduct = value;
                this.RaisePropertyChanged(()=> SelectedProduct);
            }
        }

        private AfdelingVM _selectedProductAfdeling;
        public AfdelingVM SelectedProductAfdeling {
            get {
                return this._selectedProductAfdeling;
            }
            set {
                this._selectedProductAfdeling = value;
                this.AfdelingProducten = new ObservableCollection<ProductVM>(new EntityAfdelingRepo().GetByName(_selectedProductAfdeling.Naam).Product.ToList().Select(m => new ProductVM(m)));
                this.SelectedAfdelingProduct = null;
                this.SelectedProduct = null;
                this.RaisePropertyChanged(()=> SelectedProductAfdeling);
                this.RaisePropertyChanged(() => AfdelingProducten);
            }
        }

        private ProductVM _selectedAfdelingProduct;
        public ProductVM SelectedAfdelingProduct {
            get {
                return this._selectedAfdelingProduct;
            }
            set {
                this._selectedAfdelingProduct = value;
                this.RaisePropertyChanged(() => SelectedAfdelingProduct);
            }
        }

        // Create Properties
        private string _newProductString;
        public string NewProductString {
            get {
                return this._newProductString;
            }
            set {
                this._newProductString = value;
                this.RaisePropertyChanged(() => NewProductString);
            }
        }

        // Search Properties
        private string _searchProduct;
        public string SearchProduct {
            get {
                return this._searchProduct;
            }
            set {
                this._searchProduct = value;
                this.RaisePropertyChanged(() => SearchProduct);
            }
        }

        private string _searchAfdelingProduct;
        public string SearchAfdelingProduct {
            get {
                return this._searchAfdelingProduct;
            }
            set {
                this._searchAfdelingProduct = value;
                this.RaisePropertyChanged(() => SearchAfdelingProduct);
            }
        }

        // Repo Propertie
        private IProductRepo proRepo;

        // Commands
        public ICommand SearchProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand CreateProductCommand { get; set; }
        public ICommand SearchAfdelingProductCommand { get; set; }
        public ICommand AddAfdelingProductCommand { get; set; }
        public ICommand RemoveAfdelingProductCommand { get; set; }
        public ICommand ToepassenCommand { get; set; }
        public ICommand ToepassenAfProCommand { get; set; }
        public ICommand LeegMakenAfProCommand { get; set; }

        // Constructors
        public ProductListVM() {
            if (ViewModelBase.IsInDesignModeStatic) {
                proRepo = new DummyProductRepo();
            }
            else {
                proRepo = new EntityProductRepo();
            }

            AllProducten = new ObservableCollection<ProductVM>(proRepo.GetAll().ToList().Select(m => new ProductVM(m)));
            Producten = AllProducten;
            ComboBoxProducten = new ObservableCollection<ProductVM>();
            ComboBoxProducten.Add(new ProductVM { Naam = "Leeg" });
            foreach (ProductVM p in Producten) { ComboBoxProducten.Add(p); }

            SearchProduct = "";

            SearchProductCommand = new RelayCommand(ActionSearchProduct);
            UpdateProductCommand = new RelayCommand(ActionUpdateProduct, CanUpdateProduct);
            DeleteProductCommand = new RelayCommand(ActionDeleteProduct, CanDeleteProduct);
            CreateProductCommand = new RelayCommand(ActionCreateProduct, CanCreateProduct);
            SearchAfdelingProductCommand = new RelayCommand(ActionSearchAfdelingProduct);
            AddAfdelingProductCommand = new RelayCommand(ActionAddAfdelingProduct, CanAddAfdelingProduct);
            RemoveAfdelingProductCommand = new RelayCommand(ActionRemoveAfdelingProduct, CanRemoveAfdelingProduct);
            ToepassenCommand = new RelayCommand(ActionToepassen);
            ToepassenAfProCommand = new RelayCommand(ActionToepassenAfPro);
            LeegMakenAfProCommand = new RelayCommand(ActionLeegMakenAfPro);
        }

        private void ActionSearchProduct() {
            var searchedlist = new ObservableCollection<ProductVM>();
            if (SearchProduct == "") {
                searchedlist = AllProducten;
            } else {
                foreach (var item in AllProducten) {
                    if (item.Naam.ToLower().Contains(SearchProduct.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            Producten = searchedlist;
            RaisePropertyChanged(() => Producten);
        }

        private void ActionUpdateProduct() {
            proRepo.Update(SelectedProduct._Product, SelectedProduct.Naam);
            SelectedProduct = new ProductVM();
            AllProducten = new ObservableCollection<ProductVM>(proRepo.GetAll().ToList().Select(m => new ProductVM(m)));
            Producten = AllProducten;
            ActionSearchProduct();
            RaisePropertyChanged(() => SelectedProduct);
        }

        private bool CanUpdateProduct() {
            if (SelectedProduct == null) {
                return false;
            } else if (SelectedProduct.Naam == null) {
                return false;
            } else if (SelectedProduct.Naam.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionDeleteProduct() {
            this.AllProducten.Remove(this.SelectedProduct);
            SelectedProduct = new ProductVM();
            Producten = AllProducten;
            this.ActionSearchProduct();
            RaisePropertyChanged(() => SelectedProduct);
        }

        private bool CanDeleteProduct() {
            if (SelectedProduct == null) {
                return false;
            } else if (SelectedProduct.Naam == null) {
                return false;
            } else if (SelectedProduct.Naam.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionCreateProduct() {
            this.AllProducten.Add(new ProductVM { Naam = this.NewProductString });
            this.NewProductString = "";
            Producten = AllProducten;
            this.ActionSearchProduct();
            RaisePropertyChanged(() => AllProducten);
        }

        private bool CanCreateProduct() {
            if (NewProductString == null) {
                return false;
            } else if (NewProductString.Equals("")) {
                return false;
            } else {
                return true;
            }
        }

        private void ActionSearchAfdelingProduct() {
            var searchedlist = new ObservableCollection<ProductVM>();
            var toSearchList = new ObservableCollection<ProductVM>(new EntityAfdelingRepo().GetByName(_selectedProductAfdeling.Naam).Product.ToList().Select(m => new ProductVM(m)));
            if (SearchAfdelingProduct == "") {
                searchedlist = toSearchList;
            } else {
                foreach (var item in toSearchList) {
                    if (item.Naam.ToLower().Contains(SearchAfdelingProduct.ToLower())) {
                        searchedlist.Add(item);
                    }
                }
            }
            AfdelingProducten = searchedlist;
            RaisePropertyChanged(() => AfdelingProducten);
        }

        private void ActionAddAfdelingProduct() {
            AfdelingProducten.Add(SelectedProduct);
            SelectedProduct.AfdelingNaam = SelectedProductAfdeling.Naam;
            SelectedProduct = new ProductVM();
            RaisePropertyChanged(() => AfdelingProducten);
        }

        private bool CanAddAfdelingProduct() {
            if (SelectedProductAfdeling == null) {
                return false;
            }
            if (SelectedProduct == null) {
                return false;
            } else if (SelectedProduct.AfdelingNaam == null) {
                return true;
            }
            return true;
        }

        private void ActionRemoveAfdelingProduct() {
            AfdelingProducten.Remove(SelectedAfdelingProduct);
            SelectedAfdelingProduct.AfdelingNaam = null;
            SelectedAfdelingProduct = new ProductVM();
            RaisePropertyChanged(() => AfdelingProducten);
        }

        private bool CanRemoveAfdelingProduct() {
            if (SelectedAfdelingProduct == null) {
                return false;
            } else {
                return true;
            }
        }

        public void ActionToepassen() {
            var dbList = proRepo.GetAll().ToList().Select(m => new ProductVM(m)).ToList();
            var myList = AllProducten.ToList();
            List<ProductVM> newDbList = dbList.ToList();
            List<ProductVM> newMyList = myList.ToList();

            foreach (ProductVM dbProduct in dbList) {
                foreach (ProductVM myProduct in myList) {
                    if (dbProduct.Naam == myProduct.Naam) {
                        newDbList.Remove(dbProduct);
                        newMyList.Remove(myProduct);
                        break;
                    }
                }
            }

            foreach (ProductVM dbProduct in newDbList) { proRepo.Delete(dbProduct._Product); }
            foreach (ProductVM myProduct in newMyList) { proRepo.Create(myProduct._Product); }
            proRepo.SaveChanges();
        }

        public void ActionToepassenAfPro() {
            var dbList = proRepo.GetAll().ToList().Where(m => m.AfdelingNaam == SelectedProductAfdeling.Naam).Select(m => new ProductVM(m)).ToList();
            var myList = AfdelingProducten.ToList();
            List<ProductVM> newDbList = dbList.ToList();
            List<ProductVM> newMyList = myList.ToList();

            foreach (ProductVM dbProduct in dbList) {
                foreach (ProductVM myProduct in myList) {
                    if (dbProduct.Naam == myProduct.Naam) {
                        newDbList.Remove(dbProduct);
                        newMyList.Remove(myProduct);
                        break;
                    }
                }
            }

            foreach (ProductVM dbProduct in newDbList) { proRepo.RemoveAfdeling(dbProduct._Product, SelectedProductAfdeling.Naam); }
            foreach (ProductVM myProduct in newMyList) { proRepo.AddAfdeling(myProduct._Product, SelectedProductAfdeling.Naam); }
            proRepo.SaveChanges();
        }

        public void ActionLeegMakenAfPro() {
            var dbList = proRepo.GetAll().ToList().Where(m => m.AfdelingNaam == SelectedProductAfdeling.Naam).Select(m => new ProductVM(m)).ToList();
            foreach (ProductVM dbProduct in dbList) { proRepo.RemoveAfdeling(dbProduct._Product, SelectedProductAfdeling.Naam); }
            proRepo.SaveChanges();
        }

        internal void sort(AfdelingVM value) {
            ComboBoxProducten = new ObservableCollection<ProductVM>();
            ComboBoxProducten.Add(new ProductVM { Naam = "Leeg" });
            if (value.Naam != "Leeg") {
                foreach (ProductVM p in Producten) {
                    if (p.AfdelingNaam == value.Naam) {
                        ComboBoxProducten.Add(p);
                    }
                }
            }
            else {
                foreach (ProductVM p in Producten) { ComboBoxProducten.Add(p); }
            }
            RaisePropertyChanged(() => ComboBoxProducten);
        }
    }
}
