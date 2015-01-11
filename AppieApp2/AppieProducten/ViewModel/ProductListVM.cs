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
                this.RaisePropertyChanged("_selectedProduct");
            }
        }

        private string _afdelingNaam;
        public string AfdelingNaam {
            get {
                return this._afdelingNaam;
            }
            set {
                this._afdelingNaam = value;
                if (ViewModelBase.IsInDesignModeStatic) {
                    this.AfdelingProducten = new ObservableCollection<ProductVM>(new DummyAfdelingRepo().GetByName(_afdelingNaam).Product.ToList().Select(m => new ProductVM(m)));
                }
                else {
                    this.AfdelingProducten = new ObservableCollection<ProductVM>(new EntityAfdelingRepo().GetByName(_afdelingNaam).Product.ToList().Select(m => new ProductVM(m)));
                }
                this.RaisePropertyChanged("_afdelingNaam");
            }
        }

        private ProductVM _selectedAfdelingProduct;
        public ProductVM SelectedAfdelingProduct {
            get {
                return this._selectedAfdelingProduct;
            }
            set {
                this._selectedAfdelingProduct = value;
                this.RaisePropertyChanged("_selectedAfdelingProduct");
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
                this.RaisePropertyChanged("_newProductString");
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
                this.RaisePropertyChanged("_searchProduct");
            }
        }

        private string _searchAfdelingProduct;
        public string SearchAfdelingProduct {
            get {
                return this._searchAfdelingProduct;
            }
            set {
                this._searchAfdelingProduct = value;
                this.RaisePropertyChanged("_searchAfdelingProduct");
            }
        }

        // Repo Propertie
        private IProductRepo proRepo;

        // Commands
        public ICommand SearchProductCommand { get; set; }
        public ICommand SearchAfdelingProductCommand { get; set; }

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
            SearchProductCommand = new RelayCommand(ActionSearchProduct);
            SearchAfdelingProductCommand = new RelayCommand(ActionSearchAfdelingProduct);
        }

        private void ActionSearchProduct() {
            throw new NotImplementedException("no product search");
        }

        private void ActionSearchAfdelingProduct() {
            throw new NotImplementedException("no afdeling product search");
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
