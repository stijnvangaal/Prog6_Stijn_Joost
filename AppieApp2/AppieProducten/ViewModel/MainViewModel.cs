using DomainModel;
using DomainModel.DummyRepos;
using DomainModel.IRepos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppieProducten.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        //ViewModels
        public ProductMerkListVM productMerkListVM { get; set; }
        public AfdelingLijstVM afdelingLijstVM { get; set; }
        public ProductListVM productListVM { get; set; }
        public MerkListVM merkListVM { get; set; }
        public BoodschappenSchermVM BoodschappenSchermVM { get; set; }

        //Commands
        public ICommand AddProduct { get; set; }

        public MainViewModel(BoodschappenSchermVM boodschappen)
        {
            this.productMerkListVM = new ProductMerkListVM();
            this.afdelingLijstVM = new AfdelingLijstVM();
            this.productListVM = new ProductListVM();
            this.merkListVM = new MerkListVM();
            this.BoodschappenSchermVM = boodschappen;

            AddProduct = new RelayCommand(AddSelectedProduct);
        }

        public AfdelingVM selectedAfdeling {
            get { return productMerkListVM.selectedAfdeling; }
            set { productMerkListVM.selectedAfdeling = value;
            productListVM.sort(value);
            }
        }

        public void AddSelectedProduct() {
            BoodschappenSchermVM.BoodschappenProductLijstVM.addProduct(productMerkListVM.SelectedProductMerk);
            RaisePropertyChanged(() => BoodschappenSchermVM.BoodschappenProductLijstVM.BoodschappenLijst);
        }
    }
}